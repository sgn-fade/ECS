using Leopotam.EcsLite;

public class GameInitSystem : IEcsInitSystem
{
    EcsWorld _world = null;
    public void Init(IEcsSystems systems)
    {
        _world = systems.GetWorld();
        var player = _world.NewEntity();
        var inputPool = _world.GetPool<InputComponent>();
        inputPool.Add(player);
    }
}