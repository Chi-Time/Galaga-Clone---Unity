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

        private Rigidbody2D _Rigidbody2D = null;

        private void Awake ()
        {
            AssignReferences ();
            SetupRigidbody ();
        }

        private void AssignReferences ()
        {
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
            _Rigidbody2D.AddForce (transform.up * _Speed, ForceMode2D.Impulse);
            Destroy (this.gameObject, _Range / _Speed);
        }

        private void OnTriggerEnter2D (Collider2D other)
        {
            if (other.CompareTag ("Enemy"))
            {
                Destroy (other.gameObject);
                Destroy (this.gameObject);
            }
        }
    }
}
