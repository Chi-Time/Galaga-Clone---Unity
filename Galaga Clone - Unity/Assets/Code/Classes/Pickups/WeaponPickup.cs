using UnityEngine;

namespace Assets.Code.Classes.Pickups
{
    class WeaponPickup : Pickup
    {
        [Tooltip ("The weapon type that this pickup will give to the player.")]
        [SerializeField] protected Enums.WeaponType _WeaponType = Enums.WeaponType.Default;

        protected override void Collected (Collider2D other)
        {
            other.GetComponent<PlayerController> ().SwitchWeapon (_WeaponType);
        }
    }
}
