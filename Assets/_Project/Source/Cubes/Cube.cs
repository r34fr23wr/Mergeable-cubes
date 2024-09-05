using UnityEngine;

namespace Source.Cubes
{
    [RequireComponent(typeof(CubeMovement), typeof(CubeCollision))]
    public class Cube : MonoBehaviour
    {
        public int Id;

        public CubeView View => _view;

        [SerializeField] private CubeView _view;
        [SerializeField] private CubeMovement _movement;
        [SerializeField] private CubeCollision _collision;

        private void OnValidate()
        {
            _view ??= GetComponentInChildren<CubeView>();
            _movement ??= GetComponent<CubeMovement>();
            _collision ??= GetComponent<CubeCollision>();
        }

        private void Start()
        {
            _collision.Init(_movement, this);
        }
    }
}
