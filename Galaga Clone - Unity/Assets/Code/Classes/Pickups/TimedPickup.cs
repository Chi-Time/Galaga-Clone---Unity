using UnityEngine;

namespace Assets.Code.Classes.Pickups
{
    abstract class TimedPickup : Pickup
    {
        [Tooltip ("How long the pickup lasts for.")]
        [SerializeField] protected float _Length = 1.0f;

        protected override void OnTriggerEnter2D (Collider2D other)
        {
            if (other.CompareTag ("Player"))
            {
                Collected ();
                Invoke ("PickupEnded", _Length);
                Destroy (this.gameObject);
            }
        }

        protected abstract void PickupEnded ();
    }
}
