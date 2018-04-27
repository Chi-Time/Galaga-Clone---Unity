using UnityEngine;

namespace Assets.Code.Classes
{
    [System.Serializable]
    class SaveData
    {
        public uint HighScore;

        public string SerializeToString ()
        {
            return JsonUtility.ToJson (this, true);
        }
    }
}
