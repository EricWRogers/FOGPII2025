using UnityEngine;

public class Shotgun : Weapon
{
    public override void Use()
    {
        Debug.Log("Shot Buck Shot?");
    }

    public void Equiped()
    {
        Debug.Log("Equiped: " + gameObject.name);
    }
}
