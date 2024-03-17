using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace VirtualArea
{
    public class Area : MonoBehaviour, IPointerDownHandler
    {
        // UI
        [Header("UI"), SerializeField]
        private TextMeshProUGUI titleText;
        [SerializeField]
        private RectTransform contentView;
        [SerializeField]
        private BottomTools bottomTools;
        public BottomTools BottomTools => bottomTools;

        // Datas
        private uint width;
        public uint Width
        {
            get => width;
            set
            {
                width = value;
                rectTransform.sizeDelta = new Vector2(width, height);
            }
        }
        private uint height;
        public uint Height
        {
            get => height;
            set
            {
                height = value + 60;
                rectTransform.sizeDelta = new Vector2(width, height);
            }
        }
        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value == null || value.Length == 0 ? "Empty" : value;
                titleText.text = title;
                name = $"Area_{title.Replace(" ", string.Empty)}";
            }
        }

        private List<GameObject> designElements;
        public List<GameObject> DesignElements
        {
            get => designElements;
            set
            {
                if (value == null && designElements != null && designElements.Count > 0)
                {
                    for (int i = 0; i < designElements.Count; i++)
                    {
                        Destroy(designElements[i]);
                    }
                }

                designElements = value;
            }
        }

        // Components
        private RectTransform rectTransform;
        public RectTransform RectTransform => rectTransform;

        /// <summary>
        /// Initialize the basic data of the area.
        /// </summary>
        public void Initialize()
        {
            // Get components
            if (rectTransform == null)
            {
                rectTransform = GetComponent<RectTransform>();
            }

            bottomTools.Initialize(rectTransform);

            Width = 200;
            Height = 0;
            Title = null;
            DesignElements = null;
        }

        /// <summary>
        /// Activate this area
        /// </summary>
        public void Active()
        {
            AreaManager.instance.SetTopArea(rectTransform);

            gameObject.SetActive(true);
        }

        /// <summary>
        /// Add a design element in content view.
        /// <param name="designElement">The design elements to add.</param>
        /// </summary>
        public void AddDesignElement(RectTransform designElement)
        {
            if (designElements == null)
            {
                DesignElements = new List<GameObject>();
            }

            designElements.Add(designElement.gameObject);

            designElement.SetParent(contentView);
        }

        /// <summary>
        /// Add design elements in content view.
        /// </summary>
        /// <param name="designElements">There are the design elements to add.</param>
        public void AddDesignElements(params RectTransform[] designElements)
        {
            if (this.designElements == null)
            {
                DesignElements = new List<GameObject>();
            }

            for (int i = 0; i < designElements.Length; i++)
            {
                this.designElements.Add(designElements[i].gameObject);

                designElements[i].SetParent(contentView);
            }
        }

        // Event functions
        public void OnPointerDown(PointerEventData eventData)
        {
            AreaManager.instance.SetTopArea(rectTransform);
        }

        // Button click events
        public void OnCloseButtonClick()
        {
            gameObject.SetActive(false);

            Initialize();

            rectTransform.position = AreaManager.instance.AreaPrefabPosition;
        }
    }
}
