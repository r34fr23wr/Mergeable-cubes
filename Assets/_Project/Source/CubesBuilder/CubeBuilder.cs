using UnityEngine;
using System.Collections.Generic;
using Source.Cubes;

namespace Source.CubesBuilder
{
    public class CubeBuilder : IService
    {
        private Material[] _materials;

        public CubeBuilder(Material[] materials) => _materials = materials;

        public void Build(List<Cube> cubes)
        {
            int[] generatedIds = GenerateRandomIds(cubes.Count);

            for(int i = 0; i < cubes.Count; i++)
            {
                Cube cube = cubes[i];
                int id = generatedIds[i];

                Material material = _materials[id];

                if(material == null) material = _materials[0];

                cube.View.ChangeView(id, material);
                cube.Id = id;
            }
        }

        public void Build(Cube cube)
        {
            int id = cube.Id+1;

            if(_materials.Length <= id) return;

            Debug.Log($"Old Id: {cube.Id}    New Id: {id}    Materials: {_materials.Length}");    

            cube.View.ChangeView(id, _materials[id]);
            cube.Id = id;
        }

        private int[] GenerateRandomIds(int cubesCount)
        {
            int[] ids = new int[cubesCount];

            ids[0] = 1; ids[1] = 1;

            for(int i=2; i<cubesCount; i++) ids[i] = i;

            for(int i=ids.Length-1; i>0; i--)
            {
                int randomIndex = Random.Range(0, i + 1);
                int temp = ids[i];
                ids[i] = ids[randomIndex];
                ids[randomIndex] = temp;
            }

            return ids;
        }
    }
}