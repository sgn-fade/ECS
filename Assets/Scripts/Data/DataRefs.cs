using UnityEngine;

namespace Data
{
    public class DataRefs : ScriptableObject
    {
        public static readonly PlayerInitData PlayerInitData = Resources.Load("Data/PlayerInitData") as PlayerInitData;
        public static readonly BerryInitData BerryInitData = Resources.Load("Data/BerryInitData") as BerryInitData;
        public static readonly EnemyInitData EnemyInitData = Resources.Load("Data/EnemyInitData") as EnemyInitData;
    }
}
