using UnityEngine;

namespace Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Set color alpha without changing RGB
        /// </summary>
        /// <param name="color"></param>
        /// <param name="alpha"></param>
        public static void SetAlpha(this Color color, float alpha)
        {
            Color newColor = color;
            newColor.a = alpha;
            color = newColor;
        }
    }
}
