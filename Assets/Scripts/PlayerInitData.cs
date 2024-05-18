using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerInitData : ScriptableObject
    {
        public GameObject PlayerPrefab = PrefabREfs.playerPrefab;
        public float DefaultSpeed = 2f;

    }
}