using Unity.Entities;
using Unity.Transforms;

namespace Assets.Scripts.PositionMovement.ECSJobSystem.Components
{
    public struct ECSJobSystemCubeComponent : IComponentData
    {
        public Position EndPosition;
    }
}