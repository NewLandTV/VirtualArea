using UnityEngine;

namespace VirtualArea
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        // UI
        [Header("UI"), SerializeField]
        private Transform areaTransform;
        public Transform AreaTransform => areaTransform;
        [SerializeField]
        private Transform areaLinkTransform;
        public Transform AreaLinkTransform => areaLinkTransform;
        [SerializeField]
        private Transform topAreaTransform;
        public Transform TopAreaTransform => topAreaTransform;

        private void Awake()
        {
            SetupSingleton(this);
        }

        public void Setup(int x, int y)
        {
            // Call functions
            Screen.SetResolution(Screen.height * (y / x), Screen.height, true);
        }
    }
}
