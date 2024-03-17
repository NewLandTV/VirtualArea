using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VirtualArea.DesignElements
{
    [RequireComponent(typeof(Button))]
    public class DEButton : DE
    {
        // Components
        private DEImage deImage;
        public DEImage DEImage => deImage;
        private Button button;

        private void Awake()
        {
            // Get components
            rectTransform = GetComponent<RectTransform>();
            deImage = GetComponent<DEImage>();
            button = GetComponent<Button>();
        }

        /// <summary>
        /// Add button click event.
        /// </summary>
        /// <param name="onClickEvent">Button click event logic.</param>
        public void AddOnClickEvent(UnityAction onClickEvent)
        {
            button.onClick.AddListener(onClickEvent);
        }
    }
}
