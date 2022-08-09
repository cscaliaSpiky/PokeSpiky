using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PokeSpiky
{
    public static class Extensions
    {
        public static T GetRandom<T>(this IEnumerable<T> list)
        {
            int randomValue = Random.Range(0, list.Count());
            return list.ElementAt(randomValue);
        }

        public static Vector3 ToVector3XZ(this Vector2 v3)
        {
            return new Vector3(v3.x, 0, v3.y);
        }
        
        public static T CreateInstance<T>(this T prefab, Transform parent = null) where T : Object
        {
            return GameObject.Instantiate(prefab, parent);
        }

    }
}