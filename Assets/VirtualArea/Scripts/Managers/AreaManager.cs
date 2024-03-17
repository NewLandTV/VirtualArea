using System.Collections.Generic;
using UnityEngine;

namespace VirtualArea
{
    public class AreaManager : Singleton<AreaManager>
    {
        // Area
        [Header("Area"), SerializeField]
        private uint makeAreaCount;

        private List<Area> areaList;
        private RectTransform topArea;

        // Prefabs
        [Space, Header("Prefabs"), SerializeField]
        private Area areaPrefab;
        public Vector3 AreaPrefabPosition => areaPrefab.transform.position;

        private void Awake()
        {
            SetupSingleton(this);
        }

        public void Setup()
        {
            // Allocations
            areaList = new List<Area>();

            // Call functions
            MakeArea(makeAreaCount);
        }

        /// <summary>
        /// Make as many new areas as specified count.
        /// </summary>
        /// <param name="count">The number to make.</param>
        private void MakeArea(uint count = 1)
        {
            for (uint i = 0; i < count; i++)
            {
                Area area = Instantiate(areaPrefab, AreaPrefabPosition, Quaternion.identity, ScreenManager.instance.AreaTransform);

                area.Initialize();

                areaList.Add(area);
            }
        }

        /// <summary>
        /// Get a area with AIV.
        /// </summary>
        /// <param name="aiv">Area identifier Value.</param>
        /// <returns>Gets the area if it exists, makes a new area if it doesn't exist, or returns null.</returns>
        public Area GetArea(int aiv = 0, bool make = false)
        {
            Area area = null;

            // Find any area (disabled)
            if (aiv == 0)
            {
                for (int i = areaList.Count - 1; i >= 0; i--)
                {
                    if (!areaList[i].gameObject.activeSelf)
                    {
                        return areaList[i];
                    }
                }
            }

            int index = aiv - 1;

            if (index >= 0 && index < areaList.Count)
            {
                area = areaList[index].gameObject.activeSelf ? null : areaList[index];
            }

            if (make)
            {
                MakeArea();

                return areaList[areaList.Count - 1];
            }

            return area;
        }

        /// <summary>
        /// Make it appear on top of other areas.
        /// </summary>
        /// <param name="area">This is the area to go to the top.</param>
        public void SetTopArea(RectTransform area)
        {
            if (topArea != null)
            {
                topArea.SetParent(ScreenManager.instance.AreaTransform);
            }

            topArea = area;

            area.SetParent(ScreenManager.instance.TopAreaTransform);
        }
    }
}
