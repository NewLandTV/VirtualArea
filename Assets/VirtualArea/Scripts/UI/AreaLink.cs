using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VirtualArea
{
    public class AreaLink : MonoBehaviour, IPointerClickHandler
    {
        // Datas
        private UnityAction onClick;

        // Components
        private Image image;

        /// <summary>
        /// Initialize the basic data of the area link.
        /// </summary>
        public void Initialize()
        {
            // Get components
            if (image == null)
            {
                image = GetComponent<Image>();
            }
        }

        /// <summary>
        /// Display area link on the background screen.
        /// </summary>
        /// <param name="onClick"></param>
        public void Show(Sprite linkImage, UnityAction onClick)
        {
            image.sprite = linkImage;

            this.onClick = onClick;

            gameObject.SetActive(true);
        }

        // Event functions
        public void OnPointerClick(PointerEventData eventData)
        {
            onClick?.Invoke();
        }
    }
}
