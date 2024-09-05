using UnityEngine;
using Source.Infrastructure;
using UnityEngine.EventSystems;

namespace Source.Cubes
{
    public class CubeMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public bool IsMoving = false;

        private Camera _camera;
        private Vector3 _startPosition;
        private CubeVFX _vfx;

        private void OnEnable()
        {
            _camera = Camera.main;
            _vfx = new CubeVFX(transform);
            SetStartPosition(transform.position);
        }

        private void OnDisable() => IsMoving = false;

        public void OnBeginDrag(PointerEventData eventData)
        {
            IsMoving = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            MoveToPosition();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            MoveToStart();
            IsMoving = false;
        }

        private void SetStartPosition(Vector3 position) => _startPosition = new Vector3(position.x,position.y, 10f);

        private void MoveToPosition() => transform.position = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10f));

        private void MoveToStart() => _vfx.MoveTo(_startPosition);
    }
}
