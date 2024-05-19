using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataRefs : ScriptableObject
{
    public static readonly PlayerInitData PlayerInitData = Resources.Load("Data/PlayerInitData") as PlayerInitData;
    public static readonly BerryInitData BerryInitData = Resources.Load("Data/BerryInitData") as BerryInitData;
}
