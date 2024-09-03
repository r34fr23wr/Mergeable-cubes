using UnityEngine;
using UnityEngine.UI;
using Source.Infrastructure;
using Source.CubesBuilder;

namespace Source.UI
{
    public class CoreLoaderButton : MonoBehaviour
    {
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(LoadScene);
        }

        public void LoadScene()
        {
            ServiceLocator.Instance.Get<CubesPool>().CreatePool();
            gameObject.SetActive(false);
        }
    }
}
