using UnityEngine;
using System.Collections.Generic;
using Source.Infrastructure;
using Source.Cubes;

namespace Source.CubesBuilder
{
    public class CubesPool : IService
    {
        private readonly Cube _prefab;
        private readonly Transform[] _spawnPoints;

        public CubesPool(Cube prefab, Transform[] spawnPoints)
        {
            _prefab = prefab;
            _spawnPoints = spawnPoints;
        }

        private List<Cube> _spawnedCubes = new List<Cube>();

        public void CreatePool()
        {
            if(_spawnedCubes.Count == 0) for(int i=0; i<_spawnPoints.Length; i++) CreateCube(_spawnPoints[i]);
            else ShowAllCubes();

            ConfigureCubes();
        }

        private void CreateCube(Transform spawnPoint)
        {
            Cube spawnedObject = Extensions.InstantiateObject(_prefab, spawnPoint.position, spawnPoint);
            _spawnedCubes.Add(spawnedObject);
            spawnedObject.gameObject.SetActive(true);
        }

        public void ShowAllCubes()
        {
            for(int i=0; i<_spawnedCubes.Count; i++)
            {
                _spawnedCubes[i].transform.position = _spawnPoints[i].position;
                _spawnedCubes[i].ShowObject();
            }
        }

        public void HideAllCubes()
        {
            foreach(Cube cube in _spawnedCubes) cube.HideObject();
        }

        private void ConfigureCubes() => ServiceLocator.Instance.Get<CubeBuilder>().Build(_spawnedCubes);
    }
}