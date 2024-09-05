using UnityEngine;
using Source.CubesBuilder;
using Source.Cubes;
using Source.UI;

namespace Source.Infrastructure
{
    public class CoreEntryPoint : MonoBehaviour, IService
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Material[] _materials;
        [SerializeField] private PlayGameButton _playGameButton;
        [SerializeField] private Cube _cubePrefab;

        private void Awake()
        {
            ServiceLocator serviceLocator = new ServiceLocator();

            CubeBuilder cubeBuilder = new CubeBuilder(_materials);
            serviceLocator.Register(cubeBuilder);

            CoreStateObserver coreStateObserver = new CoreStateObserver(_spawnPoints.Length, _playGameButton.gameObject);
            coreStateObserver.Configure();
            serviceLocator.Register(coreStateObserver);

            CubesMergeHandler cubesMergeHandler = new CubesMergeHandler();
            serviceLocator.Register(cubesMergeHandler);

            CubesPool cubesPool = new CubesPool(_cubePrefab, _spawnPoints);
            serviceLocator.Register(cubesPool);
        }
    }
}
