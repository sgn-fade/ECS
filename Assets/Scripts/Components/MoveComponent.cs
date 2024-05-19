using UnityEngine;

namespace Components
{
    public struct MoveComponent
    {
        public Transform Transform;
        public Rigidbody2D Rigidbody;
        public float MoveSpeed;
        public bool IsMoving;
    }
}
