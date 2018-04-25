using UnityEngine;
using Assets.Code.Enums;
using Assets.Code.Classes.Weapons;

namespace Assets.Code.Classes
{
    [RequireComponent (typeof (Rigidbody2D), typeof (BoxCollider2D))]
    class PlayerController : MonoBehaviour
    {
        [Tooltip ("The number of lives the player has before the game ends.")]
        [SerializeField] private int _Lives = 3;
        [Tooltip ("The speed of the player's movement in the world.")]
        [SerializeField] private float _MovementSpeed = 1000f;
        [Tooltip ("The player's currently firing weapon.")]
        [SerializeField] private Weapon _CurrentWeapon = null;

        private const int _MaxLives = 5;
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

            _CurrentWeapon = GetComponent<SingleShotWeapon> ();
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
                    _CurrentWeapon.Disable ();
                    _CurrentWeapon = GetComponent<SingleShotWeapon> ();
                    _CurrentWeapon.Enable ();
                    break;
                case WeaponType.ForkShot:
                    _CurrentWeapon.Disable ();
                    _CurrentWeapon = GetComponent<ForkShot> ();
                    _CurrentWeapon.Enable ();
                    break;
                case WeaponType.TripleShot:
                    _CurrentWeapon.Disable ();
                    _CurrentWeapon = GetComponent<TripleShotWeapon> ();
                    _CurrentWeapon.Enable ();
                    break;
                case WeaponType.HelixShot:
                    _CurrentWeapon.Disable ();
                    _CurrentWeapon = GetComponent<HelixShotWeapon> ();
                    _CurrentWeapon.Enable ();
                    break;
                case WeaponType.ScatterShot:
                    _CurrentWeapon.Disable ();
                    _CurrentWeapon = GetComponent<ScatterShotWeapon> ();
                    _CurrentWeapon.Enable ();
                    break;
            }
        }

        public void Hit ()
        {
            ResetPosition ();
            RemoveLives (1);
        }

        private void ResetPosition ()
        {
            _Rigidbody2D.MovePosition (Vector3.zero);
        }

        public void AddLives (int lives)
        {
            _Lives += lives;

            if (_Lives >= _MaxLives)
                _Lives = _MaxLives;
        }

        public void RemoveLives (int lives)
        {
            _Lives -= lives;

            if (_Lives < 0)
                Kill ();
        }

        private void Kill ()
        {
            Destroy (this.gameObject);
            Time.timeScale = 0.0f;
        }
    }
}
