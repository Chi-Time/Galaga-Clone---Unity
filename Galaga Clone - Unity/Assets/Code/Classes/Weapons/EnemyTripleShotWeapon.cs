﻿using UnityEngine;

namespace Assets.Code.Classes.Weapons
{
    class EnemyTripleShotWeapon : Weapon
    {
        protected override void Shoot ()
        {
            Instantiate (_BulletPrefab, transform.position + new Vector3 (0f, -1f, 0f), Quaternion.identity);
            Instantiate (_BulletPrefab, transform.position + new Vector3 (.5f, -1f, 0f), Quaternion.Euler (new Vector3 (0f, 0f, -15f)));
            Instantiate (_BulletPrefab, transform.position + new Vector3 (-.5f, -1f, 0f), Quaternion.Euler (new Vector3 (0f, 0f, 15f)));
        }
    }
}