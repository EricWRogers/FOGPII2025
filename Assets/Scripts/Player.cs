using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Tank
{
    public Transform turret;
    public WeaponManager weaponManager;
    public float speed = 10.0f;
    public float turningSpeed = 180.0f;
    public InputActionReference move;
    public InputActionReference attack;

    private Vector2 m_moveDirection;
    private Rigidbody2D m_rigidbody;

    void OnEnable()
    {
        attack.action.started += Attack;
    }

    void OnDisable()
    {
        attack.action.started -= Attack;
    }

    void Start()
    {
        GameManager.instance.player = this;


        m_rigidbody = GetComponent<Rigidbody2D>();

        if (!turret)
            Debug.LogError("GameObject: " + gameObject.name + " variable turret is not assigned.");

        if (!weaponManager)
            Debug.LogError("GameObject: " + gameObject.name + " variable weaponManager is not assigned.");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
        UpdateTurret();
        UpdateMovement();

        // simple new input manager
        if (Mouse.current.leftButton.isPressed)
        {
            Debug.Log("leftButton isPressed");
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("eKey wasPressedThisFrame");
        }
    }

    void UpdateInput()
    {
        m_moveDirection = move.action.ReadValue<Vector2>();
    }

    void UpdateTurret()
    {
        Vector3 direction = MathHelper.ZeroZ(Camera.main.ScreenToWorldPoint(Input.mousePosition)) - transform.position;

        if (direction == Vector3.zero)
            return;

        direction = Vector3.Normalize(direction);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        turret.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void UpdateMovement()
    {
        //m_rigidbody.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;

        m_rigidbody.MoveRotation(transform.eulerAngles.z + -m_moveDirection.x * turningSpeed * Time.deltaTime);

        Vector2 targetPosition = transform.position +
                                    transform.right *
                                    Input.GetAxisRaw("Vertical") *
                                    speed *
                                    Time.deltaTime;

        m_rigidbody.MovePosition(targetPosition);
    }

    // attack
    void Attack(InputAction.CallbackContext _context)
    {
        weaponManager.Use();
    }
}
