using System;
using UnityEngine;

public class Player : Tank
{
    public Transform turret;
    void Start()
    {
        GameManager.instance.player = this;

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

        turret.transform.eulerAngles = new Vector3(0.0f, 0.0f, Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg);

        //Debug.Log("Dir Right: " + turret.transform.right);
    }

    void UpdateMovement()
    {

    }
}
