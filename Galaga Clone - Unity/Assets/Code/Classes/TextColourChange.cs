using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Classes
{
    enum ColorState { first, second }

    class TextColourChange : MonoBehaviour
    {
        [Tooltip ("The speed at which the text will change colors.")]
        [SerializeField] private float _SwitchRate = 1.0f;
        [Tooltip ("The first color that the text will start with.")]
        [SerializeField] private Color _FirstColor = Color.white;
        [Tooltip ("The other color the text will alternate to and from.")]
        [SerializeField] private Color _SecondColor = Color.white;

        /// <summary>Reference to the Text this component will change.</summary>
        private Text _Label = null;
        /// <summary>The current color state this component is in.</summary>
        private ColorState _ColorState = ColorState.second;

        private void Awake ()
        {
            _Label = GetComponent<Text> ();
        }

        private void Start ()
        {
            Invoke ("SwitchColor", _SwitchRate);
        }

        private void SwitchColor ()
        {
            if (_ColorState == ColorState.first)
            {
                _Label.color = _FirstColor;
                _ColorState = ColorState.second;
            }
            else if (_ColorState == ColorState.second)
            {
                _Label.color = _SecondColor;
                _ColorState = ColorState.first;
            }

            Invoke ("SwitchColor", _SwitchRate);
        }
    }
}
