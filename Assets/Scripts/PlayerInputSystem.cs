using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;

public class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem
{
    EcsFilter _filter;
    private EcsPool<InputComponent> _inputs;
    public void Run(IEcsSystems systems)
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if(x == 0 && y == 0) return;

        foreach (int entity in _filter)
        {
            ref var inputComponent = ref _inputs.Get (entity);
            inputComponent.Direction = new Vector2(x, y);
        }
    }

    public void Init(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();
        _filter = world.Filter<InputComponent>().End();
    }
}