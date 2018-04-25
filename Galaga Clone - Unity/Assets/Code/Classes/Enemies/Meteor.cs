using UnityEngine;

namespace Assets.Code.Classes.Enemies
{
    class Meteor : Enemy
    {
        [Tooltip ("The minimum speed at which the meteor can fall.")]
        [SerializeField] protected float _MinFallSpeed = 200f;
        [Tooltip ("The maximum speed at which the meteor can fall.")]
        [SerializeField] protected float _MaxFallSpeed = 300f;

        protected override void AssignReferences ()
        {
            base.AssignReferences ();

            _FallSpeed = Random.Range (_MinFallSpeed, _MaxFallSpeed);
        }

        protected override void Move ()
        {
            _Velocity = new Vector2 (_Rigidbody2D.velocity.x, -_FallSpeed) * Time.deltaTime;

            _Rigidbody2D.velocity = _Velocity;
        }
    }
}
