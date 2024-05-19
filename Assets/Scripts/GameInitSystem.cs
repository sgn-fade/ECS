using Leopotam.EcsLite;
using UnityEngine;

public class GameInitSystem : IEcsInitSystem
{
    EcsWorld _world = null;
    public void Init(IEcsSystems systems)
    {
        _world = systems.GetWorld();
        var player = _world.NewEntity();
        var inputPool = _world.GetPool<InputComponent>();
        var movePool = _world.GetPool<MoveComponent>();
        ref var inputComponent = ref inputPool.Add(player);
        ref var moveComponent = ref movePool.Add(player);


        PlayerInitData playerData = DataRefs.PlayerInitData;
        var playerPrefab = Object.Instantiate(playerData.PlayerPrefab, Vector3.zero, Quaternion.identity);
        moveComponent.MoveSpeed = playerData.Speed;
        moveComponent.Transform = playerPrefab.transform;
    }

}