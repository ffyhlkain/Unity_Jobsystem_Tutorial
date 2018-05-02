using Unity.Entities;
using Unity.Transforms2D;

namespace Assets.Scripts.PositionMovement.ECSSystem.Components
{
    public struct CubeComponent : IComponentData
    {
        public Position2D EndPosition;
    }
}