using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabREfs : ScriptableObject
{
    public static GameObject playerPrefab = Resources.Load<GameObject>("Player");
}
