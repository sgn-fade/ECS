using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    public class MoveSystem : IEcsRunSystem, IEcsInitSystem
    {
        EcsFilter _filter;
        private EcsPool<InputComponent> _inputs;
        private EcsPool<MoveComponent> _movables;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var moveComponent = ref _movables.Get (entity);
                ref var inputComponent = ref _inputs.Get (entity);
                moveComponent.Rigidbody.velocity = inputComponent.Direction * moveComponent.MoveSpeed;
            }
        }

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<InputComponent>().Inc<MoveComponent>().End();
            _inputs = world.GetPool<InputComponent>();
            _movables = world.GetPool<MoveComponent>();
        }
    }
}