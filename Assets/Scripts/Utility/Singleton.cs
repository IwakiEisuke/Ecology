using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Instance => GetInstance();

    private static T GetInstance()
    {
        if (instance != null && instance.gameObject != null)
        {
            return instance;
        }

        if (instance == null)
        {
            instance = FindAnyObjectByType<T>();
            DontDestroyOnLoad(instance.gameObject);
            return instance;
        }
        else if (instance != FindFirstObjectByType<T>())
        {
            Destroy(FindFirstObjectByType<T>());
        }

        return instance;
    }
}
