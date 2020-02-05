using UnityEngine;

namespace Ps.Utils
{
    public static class Angles
    {
        public static float SignedAngle(Vector2 from, Vector2 to)
        {
            return Mathf.Atan2(to.x * from.y - to.y * from.x, to.x * from.x + to.y * from.y) * Mathf.Rad2Deg;
        }
        public static float SignedAngle(Vector3 from, Vector3 to)
        {
            return Mathf.Atan2(to.x * from.z - to.z * from.x, to.x * from.x + to.z * from.z) * Mathf.Rad2Deg;
        }

    }
}