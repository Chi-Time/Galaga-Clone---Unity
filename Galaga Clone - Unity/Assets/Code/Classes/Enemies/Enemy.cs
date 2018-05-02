using UnityEngine;
using Assets.Code.Enums;

namespace Assets.Code.Classes.Enemies
{
    [RequireComponent (typeof (Rigidbody2D), typeof (Collider2D))]
    abstract class Enemy : MonoBehaviour
    {
        public EnemyType EnemyType { get { return _EnemyType; } }

        [Tooltip ("The amount added to the score when this enemy is killed.")]
        [SerializeField] protected uint _Score = 20;
        [Tooltip ("The speed at which the enemy will fall.")]
        [SerializeField] protected float _FallSpeed = 200f;
        [Tooltip ("The Y-Axis boundary at which the enemy will be culled.")]
        [SerializeField] protected float _CullBound = -2.5f;
        [SerializeField] protected EnemyType _EnemyType = 0;
        [SerializeField] protected Pickups.Pickup[] _PickupPrefabs = null;
        [Tooltip ("The sound clip played when the enemy dies.")]
        [SerializeField] protected AudioClip _DeathSFX = null;

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
            {
                GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().RemoveLives (1);
                Destroy (this.gameObject);
            }
        }

        protected abstract void Move ();

        protected bool HasHitCullBound ()
        {
            if (_Transform.position.y <= _CullBound)
                return true;

            return false;   
        }

        private void OnTriggerEnter2D (Collider2D other)
        {
            if (other.CompareTag ("Player"))
            {
                other.GetComponent<PlayerController> ().Hit ();
                Destroy (this.gameObject);
            }
            else if (other.CompareTag ("Bullet"))
            {
                Killed ();
                Destroy (this.gameObject);
                Destroy (other.gameObject);
            }
        }

        protected virtual void Killed ()
        {
            SpawnPickup ();
            AudioSource.PlayClipAtPoint (_DeathSFX, Camera.main.transform.position, 1.0f);
            GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().IncreaseScore (_Score);
        }

        protected void SpawnPickup ()
        {
            int choice = Random.Range (0, 35);

            if (choice < _PickupPrefabs.Length)
                Instantiate (_PickupPrefabs[choice], _Transform.position, Quaternion.identity);
        }
    }
}
