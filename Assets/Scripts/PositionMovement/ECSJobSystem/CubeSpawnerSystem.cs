using Unity.Entities;

namespace Assets.Scripts.PositionMovement.ECSJobSystem
{
    public class CubeMovementSystem : ComponentSystem
    {
        private struct Data
        {
            public Position3D Position;
            public float2 Direction;
            public float MovementSpeed;
        }

        [Inject] private Data data;

        protected override void OnUpdate()
        {
            var passedTime = Time.deltaTime;

            for (int i = 0; i < data.Length; i++)
            {
                var entity = data[i];
                var entityPosition = entity.Position;
                var entityDirection = entity.Direction;
                var entitySpeed = entity.MovementSpeed;

                entityPosition.Value += entityDirection * entitySpeed * passedTime;
            }
        }
    }

    //public class MoveSystem : ComponentSystem
    //{
    //    struct Data
    //    {
    //        public Position3D Position;
    //        public Heading2D Heading;
    //        public MoveSpeed MoveSpeed;
    //    }

    //    protected override void OnUpdate()
    //    {
    //        var dt = Time.deltaTime;
    //        foreach (var entity in GetEntities<Data>())
    //        {
    //            var pos = entity.Position;
    //            pos.Value += entity.Heading.Value * entity.MoveSpeed.Value * dt;
    //        }
    //    }
    //}
}
