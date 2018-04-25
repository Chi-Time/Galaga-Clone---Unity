using UnityEngine;

namespace Assets.Code.Classes
{
    class BasicWeaponPickup : MonoBehaviour
    {
        public Weapons.TripleShotWeapon Weapon = null;

        private void OnTriggerEnter2D (Collider2D collision)
        {
            if (collision.CompareTag ("Player"))
            {
                var weapon = Instantiate (Weapon, collision.transform.position, Quaternion.identity);
                weapon.transform.parent = collision.transform;
                collision.GetComponent<PlayerController> ().SwitchWeapon (Enums.WeaponType.TripleShot);
                Destroy (this.gameObject);
            }
        }
    }
}
