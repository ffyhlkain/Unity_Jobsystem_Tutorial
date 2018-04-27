using Unity.Entities;

namespace Assets.Scripts.PositionMovement.ECSJobSystem
{
    public class CubeSpawnerSystem : ComponentSystem
    {


    }

    public class MoveSystem : ComponentSystem
    {
        struct Data
        {
            public Position3D Position;
            public Heading2D Heading;
            public MoveSpeed MoveSpeed;
        }

        protected override void OnUpdate()
        {
            var dt = Time.deltaTime;
            foreach (var entity in GetEntities<Data>())
            {
                var pos = entity.Position;
                pos.Value += entity.Heading.Value * entity.MoveSpeed.Value * dt;
            }
        }
    }
}
