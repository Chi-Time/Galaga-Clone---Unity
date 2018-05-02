using UnityEngine;

namespace Assets.Code.Classes.Weapons
{
    [RequireComponent (typeof (AudioSource))]
    abstract class Weapon : MonoBehaviour
    {
        [Tooltip ("The delay before the weapon fires each projectile.")]
        [SerializeField] protected float _FireRate = 0.25f;
        [Tooltip ("The prefab bullet to shoot when firing the weapon.")]
        [SerializeField] protected GameObject _BulletPrefab = null;
        [SerializeField] protected AudioClip _ShootSFX = null;

        protected float _Timer = 0.0f;
        protected AudioSource _AudioSource = null;

        protected virtual void Awake ()
        {
            AssignReferences ();
            SetupAudioSource ();
        }

        protected void AssignReferences ()
        {
            _AudioSource = GetComponent<AudioSource> ();
        }

        private void SetupAudioSource ()
        {
            _AudioSource.loop = false;
            _AudioSource.mute = false;
            _AudioSource.spatialBlend = 0f;
            _AudioSource.playOnAwake = false;
        }

        protected virtual void Update ()
        {
            _Timer += Time.deltaTime;
        }

        public void Fire ()
        {
            if (CanFire ())
            {
                Shoot ();
                _AudioSource.pitch = Random.Range (0.9f, 1.1f);
                _AudioSource.PlayOneShot (_ShootSFX);
            }
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

        public virtual void Enable ()
        {
            this.enabled = true;
        }

        public virtual void Disable ()
        {
            _Timer -= _Timer;
            this.enabled = false;
        }
    }
}
