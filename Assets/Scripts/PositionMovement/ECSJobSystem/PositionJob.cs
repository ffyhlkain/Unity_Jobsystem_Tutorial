using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;

namespace Assets.Scripts.PositionMovement.ECSJobSystem
{
    public struct PositionJob : IJobParallelForTransform
    {
        public NativeArray<Vector3> endPositions;
        public float deltaTime; // passed time in seconds

        public void Execute(int index, TransformAccess transform)
        {
            var direction = (endPositions[index] - transform.position).normalized;
            transform.position += direction * deltaTime;
        }
    }
}