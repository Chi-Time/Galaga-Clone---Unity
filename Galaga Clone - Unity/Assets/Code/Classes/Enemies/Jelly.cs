using UnityEngine;

namespace Assets.Code.Classes.Enemies
{
    class Jelly : Enemy
    {
        [Tooltip ("The speed at which the enemy will move diagonally.")]
        [SerializeField] protected float _DiagonalSpeed = 150f;
        [SerializeField] protected float _LeftBound = -0.5f;
        [SerializeField] protected float _RightBound = 0.5f;

        protected Vector2 _Direction = Vector2.right;

        protected override void AssignReferences ()
        {
            base.AssignReferences ();

            this.EnemyType = Enums.EnemyTypes.Jelly;
            // Get the left and right bounds of the enemies movement.
            _LeftBound = _Transform.position.x + _LeftBound;
            _RightBound = _Transform.position.x + _RightBound;
        }

        protected override void Move ()
        {
            GetDirection ();

            _Velocity = new Vector2 (_Direction.x * _DiagonalSpeed, -_FallSpeed) * Time.deltaTime;
            _Rigidbody2D.velocity = _Velocity;
        }

        protected void GetDirection ()
        {
            if (HasHitLeftBound ())
                _Direction = Vector2.right;
            else if (HasHitRightBound ())
                _Direction = Vector2.left;
        }

        protected bool HasHitLeftBound ()
        {
            if (_Transform.position.x <= _LeftBound)
                return true;

            return false;
        }

        protected bool HasHitRightBound ()
        {
            if (_Transform.position.x >= _RightBound)
                return true;

            return false;
        }
    }
}
