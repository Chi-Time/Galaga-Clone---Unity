using UnityEngine;

namespace Assets.Code.Classes.Weapons
{
    class ForkShot : TimedWeapon
    {
        protected override void Shoot ()
        {
            Instantiate (_BulletPrefab, transform.position + new Vector3 (.5f, 1f, 0f), Quaternion.Euler (new Vector3 (0f, 0f, 15f)));
            Instantiate (_BulletPrefab, transform.position + new Vector3 (-.5f, 1f, 0f), Quaternion.Euler (new Vector3 (0f, 0f, -15f)));
        }
    }
}
