using UnityEngine;

namespace Assets.Code.Classes
{
    class Rotator : MonoBehaviour
    {
        [Tooltip ("The speed at which the object will rotate.")]
        [SerializeField] private float _RotationSpeed = 0.0f;

        /// <summary>Reference to this object's Transform component.</summary>
        private Transform _Transform = null;

        private void Awake ()
        {
            AssignReferences ();
        }

        private void AssignReferences ()
        {
            _Transform = GetComponent<Transform> ();
        }

        private void Update ()
        {
            Rotate ();
        }

        private void Rotate ()
        {
            _Transform.Rotate (new Vector3 (0.0f, _RotationSpeed * Time.deltaTime, 0.0f));
        }
    }
}
