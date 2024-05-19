using System;
using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    public class RotationSystem : IEcsRunSystem, IEcsInitSystem
    {
        EcsFilter _filter;
        private EcsPool<MoveComponent> _moves;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var moveComponent = ref _moves.Get(entity);

                Vector3 velocity = moveComponent.Rigidbody.velocity;

                if (velocity.x == 0) return;
                moveComponent.Transform.localScale = new Vector3(Math.Sign(velocity.x), 1, 1) * 2;

            }
        }

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<InputComponent>().End();
            _moves = world.GetPool<MoveComponent>();
        }
    }
}