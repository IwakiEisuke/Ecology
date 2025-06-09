using UnityEngine;

public class DebugViewer : MonoBehaviour
{
    bool isVisible = true;

    int frameCount;
    float prevTime;
    float fps;

    [RuntimeInitializeOnLoadMethod]
    public static void Initialize()
    {
        GameObject debugViewer = new GameObject("DebugViewer");
        debugViewer.AddComponent<DebugViewer>();
        DontDestroyOnLoad(debugViewer);
    }

    private void Update()
    {
        frameCount++;

        float time = Time.realtimeSinceStartup - prevTime;
        if (time > 0.2f)
        {
            fps = frameCount / time;
            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            isVisible = !isVisible;
        }
    }

    private void OnGUI()
    {
        if (!isVisible) return;

        GUIStyle style = new(GUI.skin.label)
        {
            fontSize = 32,
            normal = { textColor = Color.white }
        };
        GUILayout.BeginVertical();
        GUILayout.Label("Debug Viewer: Press F1 to toggle visibility", style);
        GUILayout.Label($"FPS: {fps}", style);
        GUILayout.EndVertical();
    }
}
