using UnityEngine;

namespace Assets.Code.Classes.Pickups
{
    class OneUpPickup : Pickup
    {
        [Tooltip ("The number of lives given to the player upon collection.")]
        [SerializeField] protected int _Lives = 1;

        protected override void Collected (Collider2D other)
        {
            other.GetComponent<PlayerController> ().AddLives (_Lives);
        }
    }
}
