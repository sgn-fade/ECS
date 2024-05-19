using UnityEngine;

namespace Data
{
    [CreateAssetMenu]

    public class EnemyInitData : ScriptableObject
    {
        public GameObject enemyPrefab;
        public float speed = 1f;
    }
}