using UnityEngine;
using Source.Cubes;
using System;

namespace Source.CubesBuilder
{
    public class CubesMergeHandler : IService
    {
        public void DoMerge(Cube cubeToDesroy, Cube cubeToMerge)
        {
            cubeToDesroy.HideObject();
            ServiceLocator.Instance.Get<CubeBuilder>().Build(cubeToMerge);
        }
    }
}