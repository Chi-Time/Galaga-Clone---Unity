using UnityEngine;

namespace Assets.Code.Classes.Enemies
{
    class Snowflake : Enemy
    {
        [Tooltip ("The speed at which the enemy will move diagonally.")]
        [SerializeField] protected float _DiagonalSpeed = 350f;
        [Tooltip ("The minimum left bound before the enemy will change direction.")]
        [SerializeField] protected float _LeftBound = -10f;
        [Tooltip ("The maximum right bound before the enemy will change direction.")]
        [SerializeField] protected float _RightBound = 10f;

        protected override void Awake ()
        {
            base.Awake ();

            _Velocity = new Vector2 (_DiagonalSpeed, -_FallSpeed) * Time.deltaTime;
        }

        protected override void Move ()
        {
            if (HasHitLeftBound ())
                _Velocity = new Vector2 (_DiagonalSpeed, -_FallSpeed) * Time.deltaTime;
            else if (HasHitRightBound ())
                _Velocity = new Vector2 (-_DiagonalSpeed, -_FallSpeed) * Time.deltaTime;

            _Rigidbody2D.velocity = _Velocity;
        }

        protected bool HasHitRightBound ()
        {
            if (_Transform.position.x >= _RightBound)
                return true;

            return false;
        }

        protected bool HasHitLeftBound ()
        {
            if (_Transform.position.x <= _LeftBound)
                return true;

            return false;
        }
    }
}
