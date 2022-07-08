using System.Collections.Generic;
using System.Linq;
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
    }
}