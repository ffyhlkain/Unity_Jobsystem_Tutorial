using Assets.Scripts.PositionMovement;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int cubeCount = 10000;
    private TransformAccessArray transformAccessArray;
    private JobHandle positionJobHandle;
    private NativeArray<Vector3> endPositions;

    private void Start()
    {
        var transformArray = new Transform[cubeCount];
        endPositions = new NativeArray<Vector3>(cubeCount, Allocator.Persistent);

        for (int i = 0; i < cubeCount; i++)
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            transformArray[i] = cube.transform;

            endPositions[i] = new Vector3(Random.Range(-1000, 1000), Random.Range(-1000, 1000), 0);
        }

        transformAccessArray = new TransformAccessArray(transformArray);
    }

    private void Update()
    {
        var positionJob = new PositionJob
        {
            deltaTime = Time.deltaTime,
            endPositions = this.endPositions
        };

        positionJobHandle = positionJob.Schedule(transformAccessArray);
    }

    private void LateUpdate()
    {
        positionJobHandle.Complete();
    }

    private void OnDestroy()
    {
        transformAccessArray.Dispose();
        endPositions.Dispose();
    }
}