using UnityEngine;
using Source.CubesBuilder;
using Source.Cubes;

namespace Source.Infrastructure
{
    public class CoreEntryPoint : MonoBehaviour, IService
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Coroutines _coroutines;
        [SerializeField] private Cube _cubePrefab;

        private ServiceLocator _serviceLocator;
        private CubesPool _cubesPool;
        private GameStateObserver _gameStateObserver;

        private void Awake()
        {
            _serviceLocator = new ServiceLocator();
            _gameStateObserver = new GameStateObserver();

            CubesMergeHandler cubesMergeHandler = new CubesMergeHandler();
            _serviceLocator.Register(cubesMergeHandler);

            _cubesPool = new CubesPool(_cubePrefab, _spawnPoints);
            _serviceLocator.Register(_cubesPool);
        }
    }
}
