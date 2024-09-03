using UnityEngine;

namespace Source.Cubes
{
    [RequireComponent(typeof(CubeMovement), typeof(CubeCollision))]
    public class Cube : MonoBehaviour
    {
        public int Id { get; private set; }

        [SerializeField] private CubeMovement _movement;
        [SerializeField] private CubeCollision _collision;

        private void OnValidate()
        {
            _movement ??= GetComponent<CubeMovement>();
            _collision ??= GetComponent<CubeCollision>();
        }

        private void Start()
        {
            _collision.Init(_movement);
        }
    }
}
