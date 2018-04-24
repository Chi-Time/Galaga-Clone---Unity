using UnityEngine;

namespace Assets.Code.Classes
{
    [RequireComponent (typeof (Rigidbody2D), typeof (BoxCollider2D))]
    class PlayerController : MonoBehaviour
    {
        [Tooltip ("The speed of the player's movement in the world.")]
        [SerializeField] private float _MovementSpeed = 1000f;

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
    }
}
