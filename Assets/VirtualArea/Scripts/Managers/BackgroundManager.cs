using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VirtualArea
{
    public class BackgroundManager : Singleton<BackgroundManager>
    {
        // Area link
        [Header("Area Link"), SerializeField]
        private uint makeAreaLinkCount;

        private List<AreaLink> areaLinkList;

        // Prefabs
        [Space, Header("Prefabs"), SerializeField]
        private AreaLink areaLinkPrefab;

        [Space, Header("Background Image"), SerializeField]
        private Image backgroundImage;
        [SerializeField]
        private TMP_Dropdown backgroundDropdown;

        [Serializable]
        public class BackgroundImageData
        {
            public string name;

            public Sprite sprite;
        }

        [SerializeField]
        private BackgroundImageData[] defaultBackgroundImageDatas;

        private void Awake()
        {
            SetupSingleton(this);
        }

        public void Setup()
        {
            // Allocations
            areaLinkList = new List<AreaLink>();

            // Setup UI
            List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

            for (int i = 0; i < defaultBackgroundImageDatas.Length; i++)
            {
                options.Add(new TMP_Dropdown.OptionData(defaultBackgroundImageDatas[i].name, defaultBackgroundImageDatas[i].sprite));
            }

            backgroundDropdown.AddOptions(options);

            // Call functions
            MakeAreaLink(makeAreaLinkCount);
        }

        /// <summary>
        /// Make as many new area links as specified count.
        /// </summary>
        /// <param name="count">The number to make.</param>
        private void MakeAreaLink(uint count = 1)
        {
            for (uint i = 0; i < count; i++)
            {
                AreaLink areaLink = Instantiate(areaLinkPrefab, Vector3.zero, Quaternion.identity, ScreenManager.instance.AreaLinkTransform);

                areaLink.Initialize();

                areaLinkList.Add(areaLink);
            }
        }

        /// <summary>
        /// Get a area link.
        /// </summary>
        /// <returns>Gets the area link if present, otherwise returns null.</returns>
        public AreaLink GetAreaLink()
        {
            // Find any area link (disabled)
            for (int i = areaLinkList.Count - 1; i >= 0; i--)
            {
                if (!areaLinkList[i].gameObject.activeSelf)
                {
                    return areaLinkList[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Set the background image.
        /// </summary>
        /// <param name="sprite">The sprite to change.</param>
        public void SetBackgroundImage(Sprite sprite)
        {
            backgroundImage.sprite = sprite;
        }

        // UI Functions
        public void OnChangedDropdownValue(int index)
        {
            SetBackgroundImage(defaultBackgroundImageDatas[index].sprite);
        }
    }
}
