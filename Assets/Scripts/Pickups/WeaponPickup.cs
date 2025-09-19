using UnityEngine;

public class WeaponPickup : Pickup
{
    public GameObject weaponPrefab;
    public override void Use(GameObject _player)
    {
        base.Use(_player);

        Player player = _player.GetComponent<Player>();

        GameObject go = Instantiate(weaponPrefab, player.weaponManager.transform);
        player.weaponManager.weapons.Add(go.GetComponent<Weapon>());
    }
}
