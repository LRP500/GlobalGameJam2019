using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    /// <summary>
    /// Extension methods for UnityEngine.GameObject
    /// </summary>
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Gets a component attached to the given game object
        /// If one isn't found, a new one is attached and returned
        /// </summary>
        /// <param name="gameObject">Game object.</param>
        /// <returns>Previously or newly attached component.</returns>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
        }

        /// <summary>
        /// Checks whether a game object has a component of type T attached
        /// </summary>
        /// <param name="gameObject">Game object.</param>
        /// <returns>True when component is attached.</returns>
        public static bool HasComponent<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponent<T>() != null;
        }
        
        /// <summary>
        /// Set GameObject amd children's layer recursively
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="layer"></param>
        public static void SetLayerRecursively(GameObject gameObject, int layer)
        {
            gameObject.layer = layer;
            foreach (Transform t in gameObject.transform)
            {
                t.gameObject.layer = layer;
            }
        }
        
        /// <summary>
        /// Enable/Disable all colliders recursively
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="state"></param>
        public static void SetCollision(this GameObject gameObject, bool state)
        {
            var colliders = gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider collider in colliders) collider.enabled = state;
        }
        
        /// <summary>
        /// Enable/Disable all renderers recursively
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="state"></param>
        public static void SetRenderer(this GameObject gameObject, bool state)
        {
            var renderers = gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers) renderer.enabled = state;
        }

        /// <summary>
        /// Search for component in parents
        /// </summary>
        /// <param name="gameObject"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetComponentInParents<T>(this GameObject gameObject)where T : Component
        {
            for(Transform t = gameObject.transform; t != null; t = t.parent)
            {
                T result = t.GetComponent<T>();
                if(result != null) return result;
            }
            return null;
        }

        /// <summary>
        /// Search for components in parents
        /// </summary>
        /// <param name="gameObject"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] GetComponentsInParents<T>(this GameObject gameObject) where T: Component
        {
            var results = new List<T>();
            for(Transform t = gameObject.transform; t != null; t = t.parent)
            {
                T result = t.GetComponent<T>();
                if(result != null) results.Add(result);
            }
            return results.ToArray();
        }
    }
}
