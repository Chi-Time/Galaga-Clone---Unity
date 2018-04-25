using UnityEngine;
using System.Collections;

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
                StartCoroutine (PickupEnded (other));
                Destroy (this.gameObject);
            }
        }

        protected virtual IEnumerator PickupEnded (Collider2D other)
        {
            yield return new WaitForSeconds (_Length);
            

        }
    }
}
