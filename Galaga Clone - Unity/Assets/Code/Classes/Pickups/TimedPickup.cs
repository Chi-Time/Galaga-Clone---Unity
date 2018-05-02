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
                Collected (other);
                Invoke ("PickupEnded", _Length);
                this.gameObject.SetActive (false);
                AudioSource.PlayClipAtPoint (_CollectionSFX, Camera.main.transform.position, 1.0f);
            }
        }

        protected virtual void PickupEnded ()
        {
            Destroy (this.gameObject);
        }
    }
}
