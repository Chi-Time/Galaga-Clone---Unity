using UnityEngine;

[RequireComponent (typeof (Renderer))]
public class ScrollTexture : MonoBehaviour
{
    [SerializeField] private Vector2 _Scroll = new Vector2 (0f, 1f);

    private Vector2 _Offset = new Vector2 (0f, 0f);
    private Renderer _Renderer = null;

    private void Awake ()
    {
        AssignReferences ();
    }

    private void AssignReferences ()
    {
        _Renderer = GetComponent<Renderer> ();
    }

    private void FixedUpdate ()
    {
        _Offset += _Scroll * Time.deltaTime;
        _Renderer.material.SetTextureOffset ("_MainTex", _Offset);
    }
}