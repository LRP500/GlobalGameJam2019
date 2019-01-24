using UnityEngine;

namespace Extensions
{
    public static class Vector2Extensions
    {
        /// <summary>
        /// Sets vector's x value
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="x">Value of x.</param>
        public static void SetX( this Vector2 vector, float x)
        {
            vector = new Vector2(x, vector.y);
        }

        /// <summary>
        /// Sets vector's y value
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="y">Value of x.</param>
        public static void SetY(this Vector2 vector, float y)
        {
            vector = new Vector2(vector.x, y);
        }
    }
}
