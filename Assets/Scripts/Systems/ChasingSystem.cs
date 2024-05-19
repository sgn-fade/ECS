using Components;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Systems
{
    public class ChasingSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsPool<ChaseComponent> _chases;
        private EcsPool<MoveComponent> _movables;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var chaseComponent = ref _chases.Get (entity);
                ref var moveComponent = ref _movables.Get (entity);
                Vector3 direction = chaseComponent.Target.position - moveComponent.Transform.position;
                if (direction.magnitude > 10)
                {
                    moveComponent.Rigidbody.velocity = Vector3.zero;
                    return;
                };

                moveComponent.Rigidbody.velocity = direction.normalized * moveComponent.MoveSpeed;
            }
        }

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<ChaseComponent>().Inc<MoveComponent>().End();
            _chases = world.GetPool<ChaseComponent>();
            _movables = world.GetPool<MoveComponent>();
        }
    }
}