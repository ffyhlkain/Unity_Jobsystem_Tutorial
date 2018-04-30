using Unity.Entities;
using Unity.Transforms2D;

namespace Assets.Scripts.PositionMovement.ECSJobSystem.Components
{
    public struct CubeComponent : IComponentData
    {
        public Position2D EndPosition;
    }
}