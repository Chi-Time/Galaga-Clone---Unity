using UnityEngine;
using Assets.Code.Enums;
using Assets.Code.Classes.Weapons;

namespace Assets.Code.Classes
{
    [RequireComponent (typeof (Rigidbody2D), typeof (BoxCollider2D))]
    class PlayerController : MonoBehaviour
    {
        [Tooltip ("The speed of the player's movement in the world.")]
        [SerializeField] private float _MovementSpeed = 1000f;
        [Tooltip ("The player's currently firing weapon.")]
        [SerializeField] private Weapon _CurrentWeapon = null;

        private Vector2 _Velocity = Vector2.zero;
        private Rigidbody2D _Rigidbody2D = null;

        private void Awake ()
        {
            AssignReferences ();
            SetupRigidbody ();
        }

        private void AssignReferences ()
        {
            _Rigidbody2D = GetComponent<Rigidbody2D> ();
            GetComponent<Collider2D> ().isTrigger = false;
        }

        private void SetupRigidbody ()
        {
            _Rigidbody2D.isKinematic = false;
            _Rigidbody2D.gravityScale = 0f;
            _Rigidbody2D.freezeRotation = true;
        }

        private void Update ()
        {
            GetInput ();
            Move ();
        }

        private void GetInput ()
        {
            _Velocity = new Vector2 (Input.GetAxis ("Horizontal"), 0f);

            if (Input.GetButton ("Fire1") && _CurrentWeapon != null)
                _CurrentWeapon.Fire ();
        }

        private void Move ()
        {
            ApplyDrag ();
            _Rigidbody2D.velocity = _Velocity * _MovementSpeed * Time.deltaTime;
        }

        private void ApplyDrag ()
        {
            const float dragAmount = 0.1f;
            _Velocity -= _Velocity * dragAmount;
        }

        public void SwitchWeapon (WeaponType weapon)
        {
            switch (weapon)
            {
                case WeaponType.Default:
                    _CurrentWeapon = GetComponentInChildren<SingleShotWeapon> ();
                    break;
                case WeaponType.ForkShot:
                    _CurrentWeapon = GetComponentInChildren<ForkShot> ();
                    break;
                case WeaponType.TripleShot:
                    _CurrentWeapon = GetComponentInChildren<TripleShotWeapon> ();
                    break;
                case WeaponType.HelixShot:
                    _CurrentWeapon = GetComponentInChildren<HelixShotWeapon> ();
                    break;
                case WeaponType.ScatterShot:
                    _CurrentWeapon = GetComponentInChildren<ScatterShotWeapon> ();
                    break;
            }
        }
    }
}
