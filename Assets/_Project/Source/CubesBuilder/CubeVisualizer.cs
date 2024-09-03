using UnityEngine;
using Source.Cubes;

namespace Source.CubesBuilder
{
    public class CubeVisualizer : IService
    {
        public void DoMerge(CubeCollision cubeToDesroy, CubeCollision cubeToMerge)
        {
            GameObject.Destroy(cubeToDesroy.gameObject);
        }
    }
}