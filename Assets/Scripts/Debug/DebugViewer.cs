using UnityEngine;

public class DebugViewer : MonoBehaviour
{
    bool isVisible = true;

    [RuntimeInitializeOnLoadMethod]
    public static void Initialize()
    {
        GameObject debugViewer = new GameObject("DebugViewer");
        debugViewer.AddComponent<DebugViewer>();
        DontDestroyOnLoad(debugViewer);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            isVisible = !isVisible; // Toggle visibility
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
        GUILayout.Label($"FPS: {1f / Time.deltaTime}", style);
        GUILayout.EndVertical();
    }
}
