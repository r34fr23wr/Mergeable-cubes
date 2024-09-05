using UnityEngine;
using Source.Cubes;
using System;

namespace Source.CubesBuilder
{
    public class CubesMergeHandler : IService
    {
        public void DoMerge(CubeCollision cubeToDesroy, CubeCollision cubeToMerge)
        {
            cubeToDesroy.HideObject();
        }
    }
}