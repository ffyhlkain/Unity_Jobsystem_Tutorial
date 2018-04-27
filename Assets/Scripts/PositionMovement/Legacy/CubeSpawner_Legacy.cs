using UnityEngine;

namespace Assets.Scripts.PositionMovement.Legacy
{
    public class CubeSpawner_Legacy : MonoBehaviour
    {
        [SerializeField] private int cubeCount = 10000;
        private MovingCube_Legacy[] cubes;

        private void Awake()
        {
            cubes = new MovingCube_Legacy[cubeCount];

            for (int i = 0; i < cubeCount; i++)
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cubes[i] = cube.AddComponent<MovingCube_Legacy>();

                var endPosition = new Vector3(Random.Range(-1000, 1000), Random.Range(-1000, 1000), 0);
                cubes[i].Initialize(endPosition);
            }
        }

        private void Update()
        {
            if (cubes != null)
            {
                for (int i = 0; i < cubes.Length; i++)
                {
                    var cube = cubes[i];
                    if(cube != null) cube.UpdatePosition(Time.deltaTime);
                }
            }
        }
    }
}