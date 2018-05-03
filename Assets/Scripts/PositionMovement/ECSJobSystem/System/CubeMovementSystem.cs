using Assets.Scripts.PositionMovement.ECSJobSystem.Components;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms2D;
using UnityEngine;
using UnityEngine.Jobs;

namespace Assets.Scripts.PositionMovement.ECSJobSystem
{
    public class CubeMovementSystem : JobComponentSystem
    {
        private struct CubeMovementJob : IJobProcessComponentData<ECSJobSystemCubeComponent>
        {
            public ComponentDataArray<ECSJobSystemCubeComponent> CubeComponents;
            public ComponentArray<Transform> Transforms;

            public void Execute(ref ECSJobSystemCubeComponent cubeComponentData)
            {
                Debug.Log("ECSJobSystem execute");
                //cubeComponentData.EndPosition
            }
        }

        [Inject] private CubeMovementJob cubeMovementJob;

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var passedTime = Time.deltaTime;
            Debug.Log("ECSJobSystem cubemovementjob update.");
            //for (int i = 0; i < data.Length; i++)
            //{
            //    var entityTransform = data.Transforms[i];
            //    var entity = data.CubeComponents[i];
            //    var pos = new float2(entityTransform.position.x, entityTransform.position.y);
            //    var entityDirection = (entity.EndPosition.Value - pos);
            //    var movement = entityDirection * passedTime;
            //    entityTransform.position += new Vector3(movement.x, movement.y, 0).normalized;
            //}
            cubeMovementJob = new CubeMovementJob() {  CubeComponents = }
            return cubeMovementJob.Schedule(this, 64, inputDeps);

        }
    }
}