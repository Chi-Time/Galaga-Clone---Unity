using UnityEngine;

namespace Assets.Code.Classes
{
    class EnemyBullet : Bullet
    {
        protected override void Start ()
        {
            _Rigidbody2D.AddForce (-transform.up * _Speed, ForceMode2D.Impulse);
            Destroy (this.gameObject, _Range / _Speed);
        }

        protected virtual void OnTriggerEnter2D (Collider2D other)
        {
            if (other.CompareTag ("Player"))
            {
                other.GetComponent<PlayerController> ().Hit ();
                Destroy (this.gameObject);
            }
        }
    }
}
