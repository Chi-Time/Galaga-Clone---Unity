using UnityEngine;

namespace Assets.Code.Classes
{
    [RequireComponent (typeof (Rigidbody2D), typeof (Collider2D))]
    class Bullet : MonoBehaviour
    {
        /// <summary>The speed of the bullet in the world.</summary>
        [SerializeField] private float _Speed = 17.5f;
        /// <summary>The range of the bullet before it's destroyed.</summary>
        [SerializeField] private float _Range = 15f;

        private Transform _Transform = null;
        private Rigidbody2D _Rigidbody2D = null;

        private void Awake ()
        {
            AssignReferences ();
            SetupRigidbody ();
        }

        private void AssignReferences ()
        {
            _Transform = GetComponent<Transform> ();
            _Rigidbody2D = GetComponent<Rigidbody2D> ();
            GetComponent<Collider2D> ().isTrigger = true;
        }

        private void SetupRigidbody ()
        {
            _Rigidbody2D.isKinematic = false;
            _Rigidbody2D.gravityScale = 0f;
            _Rigidbody2D.freezeRotation = true;
        }

        private void Start ()
        {
            _Rigidbody2D.AddForce (Vector2.up * _Speed, ForceMode2D.Impulse);
            Destroy (this.gameObject, _Range / _Speed);
        }
    }
}
