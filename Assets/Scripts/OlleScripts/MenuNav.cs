using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour
{
    public Launch launchStart;
    public Launch launchOptions;
    public Launch launchExit;
    public Launch launchCredits;
    public Launch launchGraphics;
    public Launch launchSound;
    public Launch launchControls;
    public Launch launchCard1;
    public Launch launchCard2;
    public Launch launchCard3;
    public Launch launchCard4;
    public Launch launchCard5;

    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject graphicsMenu;
    public GameObject soundMenu;
    public GameObject controlsMenu;
    public GameObject choosePlayer;
    public GameObject minigameMenu;
    public GameObject customMinigame;

    public GameObject mainMenuSelect;
    public GameObject optionsMenuSelect;
    public GameObject graphicsMenuSelect;
    public GameObject soundMenuSelect;
    public GameObject controlsMenuSelect;
    public GameObject choosePlayerSelect;
    public GameObject minigameMenuSelect;
    public GameObject customMinigameSelect;

    public CinemachineSwitcher cinemachineSwitcher;

    //----------------MAIN MENU----------------
    //Start
    public void StartGame()
    {
        choosePlayer.SetActive(true);
        mainMenu.SetActive(false);

        launchStart.GetComponent<Launch>();
        launchStart.Fire();

        cinemachineSwitcher.mainCamera = "Choose";
        cinemachineSwitcher.SwitchState();
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(choosePlayerSelect);
    }

    //Options
    public void Options()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);

        launchOptions.GetComponent<Launch>();
        launchOptions.Fire();

        cinemachineSwitcher.mainCamera = "Options";
        cinemachineSwitcher.SwitchState();

        launchGraphics.ResetPosition();
        launchSound.ResetPosition();
        launchControls.ResetPosition();

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(optionsMenuSelect);
    }

    //Exit
    public void ExitGame()
    {
        launchExit.GetComponent<Launch>();
        launchExit.Fire();
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    //----------------OPTIONS MENU----------------
    //Back Button
    public void OptionsBack()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);

        cinemachineSwitcher.mainCamera = "Main";
        cinemachineSwitcher.SwitchState();

        launchStart.ResetPosition();
        launchOptions.ResetPosition();
        launchExit.ResetPosition();
        launchCredits.ResetPosition();

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(mainMenuSelect);
    }

    //Graphics
    public void OptionsGraphics()
    {
        graphicsMenu.SetActive(true);
        optionsMenu.SetActive(false);

        launchGraphics.GetComponent<Launch>();
        launchGraphics.Fire();

        cinemachineSwitcher.mainCamera = "Graphics";
        cinemachineSwitcher.SwitchState();

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(graphicsMenuSelect);
    }

    //Sound
    public void OptionsSound()
    {
        soundMenu.SetActive(true);
        optionsMenu.SetActive(false);

        launchSound.GetComponent<Launch>();
        launchSound.Fire();

        cinemachineSwitcher.mainCamera = "Sound";
        cinemachineSwitcher.SwitchState();

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(soundMenuSelect);
    }

    //Controls
    public void OptionsControl()
    {
        controlsMenu.SetActive(true);
        optionsMenu.SetActive(false);

        launchControls.GetComponent<Launch>();
        launchControls.Fire();

        cinemachineSwitcher.mainCamera = "Controls";
        cinemachineSwitcher.SwitchState();

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(controlsMenuSelect);
    }

    //----------------SOUND MENU----------------
    //Back Button
    public void SoundBack()
    {
        optionsMenu.SetActive(true);
        soundMenu.SetActive(false);

        cinemachineSwitcher.mainCamera = "Options";
        cinemachineSwitcher.SwitchState();

        launchGraphics.ResetPosition();
        launchSound.ResetPosition();
        launchControls.ResetPosition();

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(optionsMenuSelect);
    }

    //----------------GRAPHICS MENU----------------
    //Back Button
    public void GraphicsBack()
    {
        optionsMenu.SetActive(true);
        graphicsMenu.SetActive(false);

        cinemachineSwitcher.mainCamera = "Options";
        cinemachineSwitcher.SwitchState();

        launchGraphics.ResetPosition();
        launchSound.ResetPosition();
        launchControls.ResetPosition();

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(optionsMenuSelect);
    }

    //----------------CONTROLS MENU----------------
    //Back Button
    public void ControlsBack()
    {
        optionsMenu.SetActive(true);
        controlsMenu.SetActive(false);

        cinemachineSwitcher.mainCamera = "Options";
        cinemachineSwitcher.SwitchState();

        launchGraphics.ResetPosition();
        launchSound.ResetPosition();
        launchControls.ResetPosition();

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(optionsMenuSelect);
    }

    //----------------START MENU----------------
    //Back Button
    public void StartBack()
    {
        mainMenu.SetActive(true);
        choosePlayer.SetActive(false);

        cinemachineSwitcher.mainCamera = "Main";
        cinemachineSwitcher.SwitchState();

        launchStart.ResetPosition();
        launchOptions.ResetPosition();
        launchExit.ResetPosition();

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(mainMenuSelect);
    }

    public void StartProceed()
    {
        minigameMenu.SetActive(true);
        choosePlayer.SetActive(false);

        cinemachineSwitcher.mainCamera = "Minigame";
        cinemachineSwitcher.SwitchState();

        launchCard1.ResetPosition();
        launchCard2.ResetPosition();
        launchCard3.ResetPosition();
        launchCard4.ResetPosition();
        launchCard5.ResetPosition();

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(minigameMenuSelect);
    }


    //----------------MINIGAME MENU----------------
    //Back Button
    public void MinigameBack()
    {
        choosePlayer.SetActive(true);
        minigameMenu.SetActive(false);

        cinemachineSwitcher.mainCamera = "Choose";
        cinemachineSwitcher.SwitchState();

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(choosePlayerSelect);
    }

    //Minigame Deck
    public void MinigamePlay()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }

    //Custom Minigame
    public void MinigameCustom()
    {
        customMinigame.SetActive(true);
        minigameMenu.SetActive(false);

        cinemachineSwitcher.mainCamera = "CustomMinigame";
        cinemachineSwitcher.SwitchState();
    }

    //----------------CUSTOM MINIGAME----------------
    //Back Button
    public void CustomBack()
    {
        minigameMenu.SetActive(true);
        customMinigame.SetActive(false);

        cinemachineSwitcher.mainCamera = "Minigame";
        cinemachineSwitcher.SwitchState();

        launchCard1.ResetPosition();
        launchCard2.ResetPosition();
        launchCard3.ResetPosition();
    }

}
