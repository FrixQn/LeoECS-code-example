using UnityEngine;

namespace ECSExample.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 RandomPoint(this Vector3 extents, Vector3 center)
        {
            Vector3 max = center + extents;
            Vector3 min = center - extents;
            return new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z));
        }
    }
}
