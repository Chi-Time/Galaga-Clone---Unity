using UnityEngine;

namespace Assets.Code.Classes.Enemies
{
    [RequireComponent(typeof (Rigidbody2D), typeof (Collider2D))]
    abstract class Enemy : MonoBehaviour
    {
        [Tooltip ("The speed at which the enemy will fall.")]
        [SerializeField] protected float _FallSpeed = 0f;
        [Tooltip ("The Y-Axis boundary at which the enemy will be culled.")]
        [SerializeField] protected float _CullBound = 0f;

        protected Vector2 _Velocity = Vector2.zero;
        protected Transform _Transform = null;
        protected Rigidbody2D _Rigidbody2D = null;

        protected virtual void Awake ()
        {
            AssignReferences ();
            SetupRigidbody ();
        }

        protected virtual void AssignReferences ()
        {
            _Transform = GetComponent<Transform> ();
            _Rigidbody2D = GetComponent<Rigidbody2D> ();
            GetComponent<Collider2D> ().isTrigger = true;
        }

        protected void SetupRigidbody ()
        {
            _Rigidbody2D.isKinematic = false;
            _Rigidbody2D.gravityScale = 0f;
            _Rigidbody2D.freezeRotation = true;
        }

        protected virtual void FixedUpdate ()
        {
            Move ();

            if (HasHitCullBound ())
                Destroy (this.gameObject);
        }

        protected abstract void Move ();

        protected bool HasHitCullBound ()
        {
            if (_Transform.position.y <= _CullBound)
                return true;

            return false;   
        }
    }
}
