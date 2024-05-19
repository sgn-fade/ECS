using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    public class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem
    {
        EcsFilter _filter;
        private EcsPool<InputComponent> _inputs;
        public void Run(IEcsSystems systems)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");


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
            _inputs = world.GetPool<InputComponent>();
        }
    }
}