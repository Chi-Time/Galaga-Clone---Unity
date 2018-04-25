using UnityEngine;

namespace Assets.Code.Classes.Weapons
{
    abstract class Weapon : MonoBehaviour
    {
        [Tooltip ("The delay before the weapon fires each projectile.")]
        [SerializeField] protected float _FireRate = 0.25f;
        [Tooltip ("The prefab bullet to shoot when firing the weapon.")]
        [SerializeField] protected Bullet _BulletPrefab = null;

        protected float _Timer = 0.0f;

        protected virtual void Update ()
        {
            _Timer += Time.deltaTime;
        }

        public void Fire ()
        {
            if (CanFire ())
                Shoot ();
        }

        protected bool CanFire ()
        {
            if (_Timer >= _FireRate)
            {
                _Timer -= _Timer;
                return true;
            }

            return false;
        }

        protected abstract void Shoot ();

        public abstract void Enable ();
        public abstract void Disable ();
    }
}
