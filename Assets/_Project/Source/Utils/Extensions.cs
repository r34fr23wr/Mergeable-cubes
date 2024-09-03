using UnityEngine;

namespace Source
{
    public static class Extensions
    {
        public static T InstantiateObject<T>(T prefab) where T : MonoBehaviour
        {
            T spawnedObject = Object.Instantiate(prefab);

            return spawnedObject;
        }

        public static T InstantiateObject<T>(T prefab, Vector3 position) where T : MonoBehaviour
        {
            T spawnedObject = Object.Instantiate(prefab, position, Quaternion.identity);

            return spawnedObject;
        }

        public static T InstantiateObject<T>(T prefab, Vector3 position, Transform parent) where T : MonoBehaviour
        {
            T spawnedObject = Object.Instantiate(prefab, position, Quaternion.identity, parent);

            return spawnedObject;
        }

        public static void ShowObject(this MonoBehaviour monoBehaviour)
        {
            if(monoBehaviour != null)
                monoBehaviour.gameObject.SetActive(false);
        }

        public static void HideObject(this MonoBehaviour monoBehaviour)
        {
            if(monoBehaviour != null)
                monoBehaviour.gameObject.SetActive(false);
        }
    }
}