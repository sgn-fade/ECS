using Components;
using Data;
using Leopotam.EcsLite;
using Unity.VisualScripting;
using UnityEngine;

namespace Systems
{
    public class GameInitSystem : IEcsInitSystem
    {
        EcsWorld _world = null;
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            var chasingTarget = CreatePlayer();
            SpawnBerries();
            SpawnEnemy(chasingTarget);
        }

        private Transform CreatePlayer()
        {
            var player = _world.NewEntity();
            var inputPool = _world.GetPool<InputComponent>();
            var movePool = _world.GetPool<MoveComponent>();
            ref var moveComponent = ref movePool.Add(player);
            inputPool.Add(player);
            PlayerInitData playerData = DataRefs.PlayerInitData;
            var playerPrefab = Object.Instantiate(playerData.playerPrefab, Vector3.zero, Quaternion.identity);
            moveComponent.MoveSpeed = playerData.speed;
            moveComponent.Transform = playerPrefab.transform;
            moveComponent.Rigidbody = playerPrefab.GetComponent<Rigidbody2D>();
            return playerPrefab.transform;
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
        private void SpawnEnemy(Transform chasingTarget)
        {
            var chasePool = _world.GetPool<ChaseComponent>();
            var movePool = _world.GetPool<MoveComponent>();
            EnemyInitData enemyData = DataRefs.EnemyInitData;

            for (int i = 0; i < 5; i++)
            {
                var enemy = _world.NewEntity();
                var enemyPrefab = Object.Instantiate(enemyData.enemyPrefab, Random.insideUnitCircle * 3, Quaternion.identity);
                ref var chaseComponent = ref chasePool.Add(enemy);
                ref var moveComponent = ref movePool.Add(enemy);
                moveComponent.MoveSpeed = enemyData.speed;

                moveComponent.Transform = enemyPrefab.transform;
                moveComponent.Rigidbody = enemyPrefab.GetComponent<Rigidbody2D>();
                chaseComponent.Target = chasingTarget;
                chaseComponent.IsActive = false;
            }
        }
    }
}