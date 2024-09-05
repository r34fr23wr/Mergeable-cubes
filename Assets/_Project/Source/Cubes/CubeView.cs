using UnityEngine;
using TMPro;

namespace Source.Cubes
{
    public class CubeView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _text;
        [SerializeField] private MeshRenderer _meshRenderer;

        private void OnValidate()
        {
            _text ??= GetComponentInChildren<TextMeshPro>();
            _meshRenderer ??= GetComponent<MeshRenderer>();
        }

        public void ChangeView(int id, Material material)
        {
            _text.text = id.ToString();
            _meshRenderer.material = material;
        }

    }
}
