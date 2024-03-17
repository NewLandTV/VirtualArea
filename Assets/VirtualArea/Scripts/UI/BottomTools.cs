using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VirtualArea
{
    public class BottomTools : MonoBehaviour, IPointerDownHandler, IDragHandler
    {
        // Datas
        private Vector2 beginPosition;
        private Vector2 movePosition;

        // Components
        [SerializeField]
        private Image titleImage;
        private RectTransform areaRectTransform;

        /// <summary>
        /// Initialize bottom tools in area.
        /// </summary>
        public void Initialize(RectTransform areaRectTransform)
        {
            if (this.areaRectTransform == null)
            {
                this.areaRectTransform = areaRectTransform;
            }
        }

        /// <summary>
        /// Change the title image.
        /// </summary>
        /// <param name="image">Title image to be changed.</param>
        public void SetTitleImage(Sprite image)
        {
            titleImage.sprite = image;
        }

        // Event functions
        public void OnPointerDown(PointerEventData eventData)
        {
            AreaManager.instance.SetTopArea(areaRectTransform);

            beginPosition = areaRectTransform.position;
            movePosition = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            areaRectTransform.position = beginPosition + (eventData.position - movePosition);
        }
    }
}
