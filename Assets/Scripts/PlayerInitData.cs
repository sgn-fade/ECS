using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class PlayerInitData : ScriptableObject
{
    public GameObject playerPrefab;
    public float speed = 2f;

}