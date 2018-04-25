using UnityEngine;

namespace Assets.Code.Classes.Pickups
{
    class WeaponPickup : Pickup
    {
        [Tooltip ("The weapon type that this pickup will give to the player.")]
        [SerializeField] protected Enums.WeaponType _WeaponType = Enums.WeaponType.Default;
        [Tooltip ("The weapon prefab to spawn for the player.")]
        [SerializeField] protected Weapons.TimedWeapon _Weapon = null;

        protected override void Collected (Collider2D other)
        {
            //var weapon = Instantiate (_Weapon, other.transform.position, Quaternion.identity);
            //weapon.transform.SetParent (other.transform);
            other.GetComponent<PlayerController> ().SwitchWeapon (_WeaponType);
        }
    }
}
