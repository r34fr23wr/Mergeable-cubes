using UnityEngine;
using DG.Tweening;

namespace Source.Cubes
{
    public class CubeVFX
    {
        private Transform _transform;

        public CubeVFX(Transform transform) => _transform = transform;

        public void MoveTo(Vector3 position)
        {
            _transform.DOMove(position, 0.5f).SetEase(Ease.OutBack);
        }
    }
}