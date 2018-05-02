using UnityEngine;

namespace Assets.Code.Classes.Pickups
{
    [RequireComponent (typeof (Rigidbody2D), typeof (Collider2D), typeof (Rotator))]
    abstract class Pickup : MonoBehaviour
    {
        [Tooltip ("The amount added to the score when this pickup is collected.")]
        [SerializeField] protected uint _Score = 20;
        [Tooltip ("How fast the object falls down the screen.")]
        [SerializeField] protected float _FallSpeed = 15.0f;
        [Tooltip ("The sound effect to play for this object when collected.")]
        [SerializeField] protected AudioClip _CollectionSFX = null;

        /// <summary>Reference to this gameobjects Rigigbody2D component.</summary>
        protected Rigidbody2D _Rigidbody2D = null;

        protected virtual void Awake ()
        {
            AssignReferences ();
            SetupRigidbody ();
        }

        protected void AssignReferences ()
        {
            _Rigidbody2D = GetComponent<Rigidbody2D> ();
            GetComponent<Collider2D> ().isTrigger = true;
        }

        protected void SetupRigidbody ()
        {
            _Rigidbody2D.isKinematic = false;
            _Rigidbody2D.gravityScale = 0f;
            _Rigidbody2D.freezeRotation = false;
        }

        protected void Start ()
        {
            _Rigidbody2D.AddForce (Vector2.down * _FallSpeed, ForceMode2D.Impulse);
        }

        protected virtual void OnTriggerEnter2D (Collider2D other)
        {
            if (other.CompareTag ("Player"))
            {
                Collected (other);
                AudioSource.PlayClipAtPoint (_CollectionSFX, Camera.main.transform.position, 1.0f);
                Destroy (this.gameObject);
                GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().IncreaseScore (_Score);
            }
        }

        protected abstract void Collected (Collider2D other);
    }
}
