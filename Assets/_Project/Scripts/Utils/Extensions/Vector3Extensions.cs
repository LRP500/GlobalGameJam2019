using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    /// <summary>
    /// Extension methods for UnityEngine.Vector3
    /// </summary>
    public static class Vector3Extensions
    {
        /// <summary>
        /// Finds the position closest to the given one
        /// </summary>
        /// <param name="position">World position.</param>
        /// <param name="otherPositions">Other world positions.</param>
        /// <returns>Closest position.</returns>
        public static Vector3 GetClosest(this Vector3 position, IEnumerable<Vector3> otherPositions)
        {
            var closest = Vector3.zero;
            var shortestDistance = Mathf.Infinity;
            foreach (var otherPosition in otherPositions)
            {
                var distance = (position - otherPosition).sqrMagnitude;
                if (distance < shortestDistance)
                {
                    closest = otherPosition;
                    shortestDistance = distance;
                }
            }
            return closest;
        }
        
        /// <summary>
        /// Sets vector's x value
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="x">Value of x.</param>
        public static void SetX(this Vector3 vector, float x)
        {
            vector = new Vector3(x, vector.y, vector.z );
        }

        /// <summary>
        /// Sets vector's y value
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="y">Value of x.</param>
        public static void SetY(this Vector3 vector, float y)
        {
            vector = new Vector3(vector.x, y, vector.z);
        }

        /// <summary>
        /// Sets vector's z value
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="z">Value of x.</param>
        public static void SetZ( this Vector3 vector, float z)
        {
            vector = new Vector3(vector.x, vector.y, z);
        }

        /// <summary>
        /// Set vector's x and y values
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SetXY(this Vector3 vector, float x, float y)
        {
            vector = new Vector3(x, y, vector.z);
        }

        /// <summary>
        /// Set vector's x and z values
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="x"></param>
        /// <param name="z"></param>
        public static void SetXZ(this Vector3 vector, float x, float z)
        {
            vector = new Vector3(x, vector.y, z);
        }
        
        /// <summary>
        /// Set vector's y and z values
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void SetYZ(this Vector3 vector, float y, float z)
        {
            vector = new Vector3(vector.x, y, z);
        }

    }
}
