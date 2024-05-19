using System;
using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsLite;
using Systems;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    EcsWorld _world;
    private EcsSystems systems;
    private void Start()
    {
        _world = new EcsWorld();
        systems = new EcsSystems(_world);

        systems.Add(new GameInitSystem());
        systems.Add(new MoveSystem());
        systems.Add(new PlayerInputSystem());
        systems.Add(new PickSystem());

        systems.Init();
    }

    private void Update()
    {
        systems.Run();
    }

    private void OnDestroy()
    {
        systems.Destroy();

        _world.Destroy();
    }
}
