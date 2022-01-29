using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

    private static bool shutdown = false;
    private static object locked = new object();
    private static T instance;

    public static T Instance {
        get {
            if (shutdown) {
                return null;
            }

            lock (locked) {
                if (instance == null) {
                    instance = (T)FindObjectOfType(typeof(T));
                    if (instance == null) {
                        var singletonObject = new GameObject();
                        instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (Singleton)";
                        DontDestroyOnLoad(singletonObject);
                    }
                }
                return instance;
            }
        }
    }

    private void OnApplicationQuit() {
        shutdown = true;
    }

    private void OnDestroy() {
        shutdown = true;
    }
}