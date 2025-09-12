using UnityEngine;

public class Shotgun : Weapon
{
    public GameObject projectile;
    public int pelletCount;

    void Awake()
    {
        if (!projectile)
            Debug.LogError("GameObject: " + gameObject.name + " variable projectile is not assigned.");
    }
    public override void Use(Transform _firePoint)
    {
        GameObject[] pellets = new GameObject[pelletCount];

        for (int i = 0; i < pelletCount; i++)
        {
            pellets[i] = Instantiate(projectile, _firePoint.position, _firePoint.rotation);
            pellets[i].transform.Rotate(new Vector3(0.0f, 0.0f, Random.Range(-20.0f, 20.0f)));
        }
    }

    public void Equiped()
    {
        Debug.Log("Equiped: " + gameObject.name);
    }
}
