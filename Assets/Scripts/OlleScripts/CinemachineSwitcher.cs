using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField]
    private InputAction action;

    //public CinemachineVirtualCamera vcam1; //Main
    //public CinemachineVirtualCamera vcam2; //Options

    public MenuNav menu;

    private Animator animator;
    public string mainCamera = "Main";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    void Start()
    { 
        action.performed += _ => SwitchState(); //SwitchPriority(); 
    }

    public void SwitchState()
    {
        if (mainCamera == "Main")
        {
            animator.Play("MainMenu");
        }

        else if (mainCamera == "Options")
        {
            animator.Play("OptionsMenu");
        }

        else if (mainCamera == "Sound")
        {
            animator.Play("SoundMenu");
        }

        else if (mainCamera == "Graphics")
        {
            animator.Play("GraphicsMenu");
        }

        else if (mainCamera == "Controls")
        {
            animator.Play("ControlsMenu");
        }

        else if (mainCamera == "Choose")
        {
            animator.Play("ChoosePlayer");
        }

        else if (mainCamera == "Minigame")
        {
            animator.Play("MinigameMenu");
        }

        else if (mainCamera == "CustomMinigame")
        {
            animator.Play("CustomMinigame");
        }

    }

    /*private void SwitchPriority()
    {
        if (mainCamera)
        {
            vcam1.Priority = 0;
            vcam2.Priority = 1;
        }
        else
        {
            vcam1.Priority = 1;
            vcam2.Priority = 0;
        }

        mainCamera = !mainCamera;
    }*/
}
