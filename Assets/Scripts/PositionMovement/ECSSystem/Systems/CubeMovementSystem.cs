using Assets.Scripts.PositionMovement.ECSJobSystem.Components;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.PositionMovement.ECSSystem
{
    public class CubeMovementSystem : ComponentSystem
    {
        private struct Data
        {
            public int Length;
            public ComponentDataArray<CubeComponent> CubeComponents;
            public ComponentArray<Transform> Transforms;
        }

        [Inject] private Data data;

        protected override void OnUpdate()
        {
            var passedTime = Time.deltaTime;

            for (int i = 0; i < data.Length; i++)
            {
                var entityTransform = data.Transforms[i];
                var entity = data.CubeComponents[i];
                var pos = new float2(entityTransform.position.x, entityTransform.position.y);
                var entityDirection = (entity.EndPosition.Value - pos);
                var movement = entityDirection * passedTime;
                entityTransform.position += new Vector3(movement.x, movement.y, 0).normalized;
            }
        }
    }
}