using UnityEngine;
using Source.CubesBuilder;

namespace Source.Infrastructure
{
    public class CoreStateObserver : IService
    {
        private GameObject _playGameButtonObject;

        private int _maxCubesCount;
        private int _currentCubesCount;

        public CoreStateObserver(int maxCubesCount, GameObject playGameButtonObject)
        {
            _maxCubesCount = maxCubesCount;
            _playGameButtonObject = playGameButtonObject;
        }

        public void Configure() => _currentCubesCount = _maxCubesCount;

        public void OnCubesMerged()
        {
            _currentCubesCount--;

            if(_currentCubesCount <= 1) FinishGame();
        }

        private void FinishGame()
        {
            ServiceLocator.Instance.Get<CubesPool>().HideAllCubes();
            _playGameButtonObject.SetActive(true);
        }
    }
}
