using UnityEngine;

namespace Assets.Code.Classes.Weapons
{
    class EnemyScatterShotWeapon : Weapon
    {
        protected override void Shoot ()
        {
            Instantiate (_BulletPrefab, transform.position + new Vector3 (0f, -1f, 0f), Quaternion.identity);
            Instantiate (_BulletPrefab, transform.position + new Vector3 (1f, -.75f, 0f), Quaternion.Euler (new Vector3 (0f, 0f, GetRandomRotation ())));
            Instantiate (_BulletPrefab, transform.position + new Vector3 (1.25f, -.5f, 0f), Quaternion.Euler (new Vector3 (0f, 0f, GetRandomRotation ())));
            Instantiate (_BulletPrefab, transform.position + new Vector3 (-1.25f, -.5f, 0f), Quaternion.Euler (new Vector3 (0f, 0f, GetRandomRotation ())));
            Instantiate (_BulletPrefab, transform.position + new Vector3 (-1f, -.75f, 0f), Quaternion.Euler (new Vector3 (0f, 0f, GetRandomRotation ())));
        }

        protected float GetRandomRotation ()
        {
            return Random.Range (-25f, 25f);
        }
    }
}
