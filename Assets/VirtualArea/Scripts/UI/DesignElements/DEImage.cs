using UnityEngine;
using UnityEngine.UI;

namespace VirtualArea.DesignElements
{
    [RequireComponent(typeof(Image))]
    public class DEImage : DE
    {
        // Components
        private Image image;

        private void Awake()
        {
            // Get components
            rectTransform = GetComponent<RectTransform>();
            image = GetComponent<Image>();
        }

        /// <summary>
        /// Change the image sprite.
        /// </summary>
        /// <param name="sprite">The image sprite to change.</param>
        /// <returns>Return this object.</returns>
        public DEImage SetSprite(Sprite sprite)
        {
            image.sprite = sprite;

            return this;
        }

        /// <summary>
        /// Change the image color.
        /// </summary>
        /// <param name="color">The image color to change.</param>
        /// <returns>Return this object.</returns>
        public DEImage SetColor(Color color)
        {
            image.color = color;

            return this;
        }
    }
}
