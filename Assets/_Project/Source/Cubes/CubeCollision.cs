using UnityEngine;
using Source.CubesBuilder;
using Source.Infrastructure;

namespace Source.Cubes
{
    public class CubeCollision : MonoBehaviour
    {
        private CubeMovement _movement;

        public void Init(CubeMovement movement) => _movement = movement;

        private void OnTriggerEnter(Collider other)
        {
            if(_movement.IsMoving && other.gameObject.TryGetComponent(out CubeCollision targer))
                ServiceLocator.Instance.Get<CubesMergeHandler>().DoMerge(this, targer);
        }
    }
}