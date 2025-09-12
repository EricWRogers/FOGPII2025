using UnityEngine;

public class Pistol : Weapon
{
    public GameObject projectile;

    void Awake()
    {
        if (!projectile)
            Debug.LogError("GameObject: " + gameObject.name + " variable projectile is not assigned.");
    }
    public override void Use(Transform _firePoint)
    {
        Instantiate(projectile, _firePoint.position, _firePoint.rotation);
    }

    public void Equiped()
    {
        Debug.Log("Equiped: " + gameObject.name);
    }
}
