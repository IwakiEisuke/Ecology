using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [SerializeField] InputActionReference pause;

    bool isPausing = false;

    private void Start()
    {
        pause.action.performed += _ =>
        {
            if (!isPausing)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        };
    }

    public void Pause()
    {
        isPausing = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isPausing = false;
        Time.timeScale = 1;
    }
}
