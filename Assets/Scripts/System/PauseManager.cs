using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] InputActionReference pause;
    [SerializeField] Image pausePanel;

    bool isPausing = false;

    private void Start()
    {
        pausePanel.gameObject.SetActive(false);

        pause.action.performed += TogglePause;
    }

    public void TogglePause(InputAction.CallbackContext context)
    {
        if (!isPausing)
        {
            Pause();
        }
        else
        {
            Resume();
        }

        isPausing = !isPausing;
        pausePanel.gameObject.SetActive(isPausing);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    private void OnDisable()
    {
        pause.action.performed -= TogglePause;
    }
}
