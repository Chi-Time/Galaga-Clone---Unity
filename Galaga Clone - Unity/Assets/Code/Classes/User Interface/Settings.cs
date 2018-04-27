using UnityEngine;

namespace Assets.Code.Classes.User_Interface
{
    [System.Serializable]
    class Settings
    {
        public int AALevel;
        public int QualityLevel;
        public int VSyncCount;

        public string SerializeToString ()
        {
            return JsonUtility.ToJson (this, true);
        }
    }
}
