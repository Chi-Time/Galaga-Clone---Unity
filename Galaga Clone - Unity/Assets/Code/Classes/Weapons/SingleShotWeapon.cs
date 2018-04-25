using UnityEngine;

namespace Assets.Code.Classes.Weapons
{
    class SingleShotWeapon : Weapon
    {
        protected override void Shoot ()
        {
            Instantiate (_BulletPrefab, transform.position + new Vector3 (0f, 1f, 0f), Quaternion.identity);
        }

        public override void Enable () { }

        public override void Disable () { }
    }
}
