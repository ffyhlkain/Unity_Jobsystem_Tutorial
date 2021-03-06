﻿using Assets.Scripts.PositionMovement.ECSSystem.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms2D;
using UnityEngine;

namespace Assets.Scripts.PositionMovement.ECSSystem
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private int cubeCount = 10000;

        private void Start()
        {
            InitializeGame();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public void InitializeGame()
        {
            Debug.Log("Initialize ECS cubespawner");
            var entityManager = World.Active.GetExistingManager<EntityManager>();

            for (int i = 0; i < cubeCount; i++)
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                var cubeEntity = cube.AddComponent<GameObjectEntity>().Entity;

                var endPosition = new Position2D();
                endPosition.Value = new float2(Random.Range(-1000, 1000), Random.Range(-1000, 1000));
                entityManager.AddComponentData(cubeEntity, new CubeComponent() { EndPosition = endPosition });
            }
        }
    }
}
