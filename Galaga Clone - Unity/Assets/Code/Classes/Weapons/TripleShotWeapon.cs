﻿using UnityEngine;

namespace Assets.Code.Classes.Weapons
{
    class TripleShotWeapon : TimedWeapon
    {
        protected override void Shoot ()
        {
            Instantiate (_BulletPrefab, transform.parent.position + new Vector3 (0f, 1f, 0f), Quaternion.identity);
            Instantiate (_BulletPrefab, transform.parent.position + new Vector3 (.5f, 1f, 0f), Quaternion.Euler (new Vector3 (0f, 0f, -15f)));
            Instantiate (_BulletPrefab, transform.parent.position + new Vector3 (-.5f, 1f, 0f), Quaternion.Euler (new Vector3 (0f, 0f, 15f)));
        }
    }
}
