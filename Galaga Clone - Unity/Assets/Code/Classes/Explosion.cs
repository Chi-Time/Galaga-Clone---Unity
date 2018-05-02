using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Tooltip ("The sound clip played when the enemy dies.")]
    [SerializeField] protected AudioClip _DeathSFX = null;

    private void Awake ()
    {
        AudioSource.PlayClipAtPoint (_DeathSFX, Camera.main.transform.position, 1.0f);
        Destroy (this.gameObject, 1.0f);
    }
}
