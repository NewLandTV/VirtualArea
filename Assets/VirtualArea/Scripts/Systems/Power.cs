using UnityEngine;

namespace VirtualArea
{
    public class Power : MonoBehaviour
    {
        // Flags
        public static bool IsRunning
        {
            get;
            private set;
        }

        private void Start()
        {
            // Setup
            AreaManager.instance.Setup();
            ScreenManager.instance.Setup(16, 9);
            BackgroundManager.instance.Setup();

            IsRunning = true;
        }
    }
}
