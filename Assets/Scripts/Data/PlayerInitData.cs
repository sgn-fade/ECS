using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class PlayerInitData : ScriptableObject
    {
        public GameObject playerPrefab;
        public float speed = 2f;
    }
}