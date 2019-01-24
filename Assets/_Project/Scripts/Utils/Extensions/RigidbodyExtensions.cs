using UnityEngine;

namespace Extensions
{
    /// <summary>
    /// Extension methods for UnityEngine.Rigidbody
    /// </summary>
    public static class RigidbodyExtensions
    {
        /// <summary>
        /// Changes the direction of a rigidbody without changing its speed.
        /// </summary>
        /// <param name="rigidbody">Rigidbody.</param>
        /// <param name="direction">New direction.</param>
        public static void ChangeDirection(this Rigidbody rigidbody, Vector3 direction)
        {
            rigidbody.velocity = direction * rigidbody.velocity.magnitude;
        }
        
        /// <summary>
        /// Freeze rigidbody's movement and rotation
        /// </summary>
        /// <param name="rigidbody"></param>
        public static void Freeze(this Rigidbody rigidbody)
        {
            if (rigidbody == null) return;
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.isKinematic = true;
        }
         
        /// <summary>
        /// Save current rigidbody state for later reuse
        /// </summary>
        /// <param name="rigidbody2D"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static Rigidbody2DState GetState(this Rigidbody2D rigidbody2D, Rigidbody2DState state = null)
        {
            if (state == null) state = new Rigidbody2DState();
            state.velocity = rigidbody2D.velocity;
            state.angularVelocity = rigidbody2D.angularVelocity;
            return state;
        }
        
        /// <summary>
        /// Rigidbody state definition
        /// </summary>
        public class Rigidbody2DState
        {
            public Vector2 velocity;
            public float angularVelocity;
        }
    }
}
