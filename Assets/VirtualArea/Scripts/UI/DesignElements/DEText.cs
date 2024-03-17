using TMPro;
using UnityEngine;

namespace VirtualArea.DesignElements
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class DEText : DE
    {
        // Components
        private TextMeshProUGUI text;

        private void Awake()
        {
            // Get components
            rectTransform = GetComponent<RectTransform>();
            text = GetComponent<TextMeshProUGUI>();
        }

        /// <summary>
        /// Change the text content.
        /// </summary>
        /// <param name="message">The text content to change.</param>
        /// <returns>Return this object.</returns>
        public DEText SetText(string message)
        {
            text.text = message;

            return this;
        }

        /// <summary>
        /// Change the font size.
        /// </summary>
        /// <param name="fontSize">The font size to change.</param>
        /// <returns>Return this object.</returns>
        public DEText SetFontSize(float fontSize)
        {
            text.fontSize = fontSize;

            return this;
        }

        /// <summary>
        /// Change the text color.
        /// </summary>
        /// <param name="color">The text color to change.</param>
        /// <returns>Return this object.</returns>
        public DEText SetColor(Color color)
        {
            text.color = color;

            return this;
        }

        /// <summary>
        /// Change text alignment.
        /// </summary>
        /// <param name="alignment">The text alignment to change.</param>
        /// <returns>Return this object.</returns>
        public DEText SetAlignment(TextAlignmentOptions alignment)
        {
            text.alignment = alignment;

            return this;
        }
    }
}
