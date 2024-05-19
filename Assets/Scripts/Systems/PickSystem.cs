using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    public class PickSystem : IEcsRunSystem, IEcsInitSystem
    {
        EcsFilter _filter;
        private EcsPool<PickComponent> _picks;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var pickComponent = ref _picks.Get (entity);
                Collider[] hits = Physics.OverlapSphere(pickComponent.Transform.position, pickComponent.SphereRadius);
                if(hits != null) _picks.Del(entity);
            }
        }

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<PickComponent>().End();
            _picks = world.GetPool<PickComponent>();
        }
    }
}