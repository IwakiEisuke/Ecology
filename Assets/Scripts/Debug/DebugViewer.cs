using System;
using UnityEngine;

public class DebugViewer : MonoBehaviour
{
    public static DebugViewer Instance { get; private set; }

    bool isVisible = true;

    int frameCount;
    float maxGap;
    float currMaxGap;
    float prevFrameTime;
    float prevTime;
    float fps;

    string currentTime;

    string stackTrace = string.Empty;

    [RuntimeInitializeOnLoadMethod]
    public static void Initialize()
    {
        GameObject debugViewer = new("DebugViewer");
        Instance = debugViewer.AddComponent<DebugViewer>();
        DontDestroyOnLoad(debugViewer);
    }

    private void Update()
    {
        frameCount++;

        float gapTime = Time.realtimeSinceStartup - prevFrameTime;
        prevFrameTime = Time.realtimeSinceStartup;
        if (gapTime > currMaxGap)
        {
            currMaxGap = gapTime;
        }

        float elapsedTime = Time.realtimeSinceStartup - prevTime;
        if (elapsedTime > 0.2f)
        {
            fps = frameCount / elapsedTime;
            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
            maxGap = currMaxGap;
            currMaxGap = 0f;
        }

        currentTime = TimeSpan.FromSeconds(GameTimeManager.CurrentTime).ToString(@"dd\.hh\:mm\:ss");

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
        GUILayout.Label($"FPS: {fps:0.0} | <maxGap> {maxGap*1000:0}ms", style);
        GUILayout.Label($"CurrentTime: {currentTime}", style);
        GUILayout.Label(stackTrace, style);
        GUILayout.EndVertical();
    }

    public static void SetStackTrace(string stackTrace)
    {
        Instance.stackTrace = stackTrace;
    }
}
