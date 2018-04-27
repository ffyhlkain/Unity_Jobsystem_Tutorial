using System;
using UnityEngine;

namespace Assets.Scripts.PositionMovement.Legacy
{
    public class MovingCube_Legacy : MonoBehaviour
    {
        private Transform cachedTransform;
        private Vector3 endPosition;
        private Vector3 direction;

        public void Initialize(Vector3 end)
        {
            endPosition = end;
            cachedTransform = transform;
            direction = (endPosition - transform.position).normalized;
        }

        internal void UpdatePosition(float deltaTime)
        {
            cachedTransform.position += direction * deltaTime;
        }
    }
}
