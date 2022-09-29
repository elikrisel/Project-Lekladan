using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class countdown : MonoBehaviour {
    private float timeStart;
    public Text textBox;
    public GameObject timesUp;
    public GameObject result;
    
    [Header("Coroutine")]
    private int timeDelay = 3;
    private bool isExecuting;

    [SerializeField] private EventSystem eventSystem;

    private PauseMenu pause;
    private PlayerInputActionAsset playerControls;
    private InputAction.CallbackContext context;
    private InputAction MenuPause;
    
    public static countdown instance;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        playerControls = new PlayerInputActionAsset();
        timeStart = SettingHolder.Instance._countdownTimer;
    }
    
    private void OnDisable()
    {
        MenuPause.Disable();
    }

    private void OnEnable()
    {
        MenuPause = playerControls.Player.MenuPause;
        MenuPause.Enable();

        MenuPause.performed += SeeResult;

    }

    private void SeeResult(InputAction.CallbackContext ctx)
    {
        
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(result);
        

    }

    void Start() 
    {
        textBox.text = timeStart.ToString();
        timesUp.SetActive(false);
        result.SetActive(false);

    }

    
    void Update()
    {
        timeStart -= Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString();

        if (timeStart <= 0)
        {
            timeStart = 0;
            StartCoroutine(ExecuteAfterAnimation(timeDelay)); 
                
        }
    }

    public IEnumerator ExecuteAfterAnimation(float time)
    {
        if (isExecuting)
            yield break;
            
        isExecuting = true;
        
        timesUp.SetActive(true);
        result.SetActive(true);
        SeeResult(context);
        
        
        yield return new WaitForSeconds(time);
        
        Time.timeScale = 0;
        

        isExecuting = false;


    }

    
}
