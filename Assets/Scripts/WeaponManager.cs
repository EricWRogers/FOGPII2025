using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(WeaponManager))]
public class WeaponManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        WeaponManager wm = (WeaponManager)target;

        if (GUILayout.Button("Prev"))
        {
            wm.PrevWeapon();
        }

        if (GUILayout.Button("Use"))
        {
            wm.Use();
        }
    }
}
#endif
public class WeaponManager : MonoBehaviour
{
    public List<Weapon> weapons;
    public Weapon currentWeapon;
    public Transform firePoint;

    public void Start()
    {
        if (!currentWeapon)
            Debug.LogError("GameObject: " + gameObject.name + " variable currentWeapon is not assigned.");

        if (weapons.Count == 0)
            Debug.LogError("GameObject: " + gameObject.name + " List weapons is empty.");

        if (!firePoint)
            Debug.LogError("GameObject: " + gameObject.name + " variable firePoint is not assigned.");
    }

    public void Use()
    {
        if (currentWeapon)
            currentWeapon.Use(firePoint);
    }

    public void Update()
    {
        if (Input.mouseScrollDelta.y > 0.0f)
            NextWeapon();

        if (Input.mouseScrollDelta.y < 0.0f)
            PrevWeapon();
    }

    public void PrevWeapon()
    {
        if (weapons.Count <= 1)
            return;

        int weaponIndex = GetCurrentIndex();

        if (weaponIndex == -1)
        {
            Debug.LogError("GameObject: " + gameObject.name + " weapon not found is not found.");
            return;
        }

        weaponIndex--;

        if (weaponIndex < 0)
            weaponIndex = weapons.Count - 1;

        currentWeapon = weapons[weaponIndex];
        currentWeapon.equiped.Invoke();
    }

    public void NextWeapon()
    {
        if (weapons.Count <= 1)
            return;
        
        int weaponIndex = GetCurrentIndex();

        if (weaponIndex == -1)
        {
            Debug.LogError("GameObject: " + gameObject.name + " weapon not found is not found.");
            return;
        }

        weaponIndex++;

        if (weaponIndex >= weapons.Count)
            weaponIndex = 0;

        currentWeapon = weapons[weaponIndex];
        currentWeapon.equiped.Invoke();
    }

    private int GetCurrentIndex()
    {
        for (int i = 0; i < weapons.Count; i++)
            if (weapons[i] == currentWeapon)
                return i;
        
        return -1;
    }
}
