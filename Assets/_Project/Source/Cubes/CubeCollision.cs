using UnityEngine;
using Source.CubesBuilder;
using Source.Infrastructure;

namespace Source.Cubes
{
    public class CubeCollision : MonoBehaviour
    {
        private CubeMovement _movement;
        private Cube _cube;

        public void Init(CubeMovement movement, Cube cube)
        {
            _movement = movement;
            _cube = cube;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(_movement.IsMoving && other.gameObject.TryGetComponent(out Cube cube))
            {
                ServiceLocator.Instance.Get<CubesMergeHandler>().DoMerge(_cube, cube);
                ServiceLocator.Instance.Get<CoreStateObserver>().OnCubesMerged();
            }
        }
    }
}