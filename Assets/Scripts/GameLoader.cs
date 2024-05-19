using System;
using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsLite;
using Systems;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems.Add(new GameInitSystem())
            .Add(new MoveSystem())
            .Add(new PlayerInputSystem())
            .Add(new PickSystem())
            .Add(new RotationSystem())
            .Add(new ChasingSystem())
            .Init();
    }

    private void Update()
    {
        _systems.Run();
    }

    private void OnDestroy()
    {
        _systems.Destroy();

        _world.Destroy();
    }
}