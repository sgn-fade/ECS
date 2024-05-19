using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    public class GameInitSystem : IEcsInitSystem
    {
        EcsWorld _world = null;
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            var player = _world.NewEntity();
            var inputPool = _world.GetPool<InputComponent>();
            var movePool = _world.GetPool<MoveComponent>();
            ref var moveComponent = ref movePool.Add(player);
            inputPool.Add(player);


            PlayerInitData playerData = DataRefs.PlayerInitData;
            var playerPrefab = Object.Instantiate(playerData.playerPrefab, Vector3.zero, Quaternion.identity);
            moveComponent.MoveSpeed = playerData.speed;
            moveComponent.Transform = playerPrefab.transform;
            SpawnBerries();
        }

        private void SpawnBerries()
        {
            var pickPool = _world.GetPool<PickComponent>();
            BerryInitData berryData = DataRefs.BerryInitData;

            for (int i = 0; i < 5; i++)
            {
                var berry = _world.NewEntity();
                var berryPrefab = Object.Instantiate(berryData.berryPrefab, Random.insideUnitCircle * 2, Quaternion.identity);
                ref var pickComponent = ref pickPool.Add(berry);
                pickComponent.Transform = berryPrefab.transform;
                pickComponent.GameObject = berryPrefab.gameObject;
                pickComponent.SphereRadius = 0.0001f;
            }
        }

    }
}