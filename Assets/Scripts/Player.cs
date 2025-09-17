using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Tank
{
    public Transform turret;
    public float speed = 10.0f;
    public float turningSpeed = 180.0f;

    Rigidbody2D rigidbody;

    void Start()
    {
        GameManager.instance.player = this;

        rigidbody = GetComponent<Rigidbody2D>();

        if (!turret)
            Debug.LogError("GameObject: " + gameObject.name + " variable turret is not assigned.");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTurret();
        UpdateMovement();
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
        //rigidbody.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;

        rigidbody.MoveRotation(transform.eulerAngles.z + -Input.GetAxisRaw("Horizontal") * turningSpeed * Time.deltaTime);

        Vector2 targetPosition =    transform.position +
                                    transform.right *
                                    Input.GetAxisRaw("Vertical") *
                                    speed *
                                    Time.deltaTime;

        rigidbody.MovePosition(targetPosition);
    }
}
