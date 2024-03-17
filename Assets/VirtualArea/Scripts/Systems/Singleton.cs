using UnityEngine;

public class Singleton<T> : MonoBehaviour
{
    public static T instance
    {
        get;
        private set;
    }

    /// <summary>
    /// Destroy the instance if it already exists, otherwise make it undestroyed.
    /// </summary>
    protected void SetupSingleton(T type)
    {
        if (instance == null)
        {
            instance = type;

            DontDestroyOnLoad(gameObject);

            return;
        }

        Destroy(gameObject);
    }
}
