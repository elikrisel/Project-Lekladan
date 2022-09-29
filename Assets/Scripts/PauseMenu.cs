using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    private PlayerInputActionAsset playerControls;
    private InputAction MenuPause;

    [SerializeField] public GameObject PauseUI;
    [SerializeField] private bool isPaused;

    [SerializeField] private GameObject pauseSelect;
    [SerializeField] private EventSystem eventSystem;

    void Awake()
    {
        playerControls = new PlayerInputActionAsset();

    }


    private void OnEnable()
    {
        MenuPause = playerControls.Player.MenuPause;
        MenuPause.Enable();

        MenuPause.performed += Pause;
    }

    private void OnDisable()
    {
        MenuPause.Disable();
    }

    void Pause(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        PauseUI.SetActive(true);
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(pauseSelect);
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        PauseUI.SetActive(false);
        isPaused = false;
    }

    public void BackToMenu()
    {
        AudioListener.pause = false;
        Time.timeScale = 1;
        GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);
        ScoreManager.instance.ResetScore();

    }

}
