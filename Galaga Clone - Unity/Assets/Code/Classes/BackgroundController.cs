using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [Tooltip ("The speed at which the background scrolls down the screen.")]
    [SerializeField] private float _ScrollSpeed = 0.0f;
    [Tooltip ("The point at which the background is culled and placed at the top again.")]
    [SerializeField] private float _CullBoundary = -12.0f;

    private Transform _Transform = null;

    private void Awake ()
    {
        AssignReferences ();
    }

    private void AssignReferences ()
    {
        _Transform = GetComponent<Transform> ();
    }

    private void FixedUpdate ()
    {
        _Transform.Translate (Vector3.down * _ScrollSpeed * Time.deltaTime);

        if (_Transform.position.y <= _CullBoundary)
            _Transform.position = new Vector3 (0.0f, 26.2f, 0.0f);
    }
}
