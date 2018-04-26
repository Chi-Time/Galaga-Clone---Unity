using System.Collections;
using UnityEngine;

namespace Assets.Code.Classes.Pickups
{
    class MultiplierPickup : TimedPickup
    {
        [SerializeField] protected uint _MultiplierAmount = 2;

        protected override void Collected (Collider2D other)
        {
            FindObjectOfType<GameController> ().Multiplier = _MultiplierAmount;
        }

        protected override void PickupEnded ()
        {
            FindObjectOfType<GameController> ().Multiplier = 1;

            base.PickupEnded ();
        }
    }
}
