using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] KeyInputManager keyInputManager;
    [SerializeField] GameObject pausePanel;

    public bool IsPausing { get; private set; }

    private void Start()
    {
        pausePanel.gameObject.SetActive(false);
        keyInputManager.Pause += Pause;
        keyInputManager.Resume += Resume;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        IsPausing = true;
        pausePanel.SetActive(true);
        InputManager.Instance.SetUIActionMap();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        IsPausing = false;
        pausePanel.SetActive(false);
        InputManager.Instance.SetPlayerActionMap();
    }
}
