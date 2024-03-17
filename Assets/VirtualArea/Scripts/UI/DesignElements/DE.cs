using System;
using UnityEngine;

namespace VirtualArea.DesignElements
{
    // Enums
    public enum DesignElementType
    {
        Text,
        Image,
        Button
    }

    public class DE : MonoBehaviour
    {
        // Components
        protected RectTransform rectTransform;
        public RectTransform RectTransform => rectTransform;

        /// <summary>
        /// Create a new design element with a name and type.
        /// </summary>
        /// <param name="name">The name of the design element.</param>
        /// <param name="type">The type of the design element.</param>
        /// <returns>Returns the created design element.</returns>
        public static GameObject Create(string name, DesignElementType type)
        {
            Type[] components = null;

            switch (type)
            {
                case DesignElementType.Text:
                    components = new Type[]
                    {
                        typeof(DEText)
                    };

                    break;
                case DesignElementType.Image:
                    components = new Type[]
                    {
                        typeof(DEImage)
                    };

                    break;
                case DesignElementType.Button:
                    components = new Type[]
                    {
                        typeof(DEImage),
                        typeof(DEButton)
                    };

                    break;
            }

            return new GameObject(name, components);
        }
    }
}
