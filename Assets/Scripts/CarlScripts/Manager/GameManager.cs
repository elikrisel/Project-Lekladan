using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerManager; 

    public static GameManager Instance;

    public GameState state;

    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Instantiate(SettingHolder.Instance.SoundManagerPrefab).GetComponent<SoundManager>();
    }

    void Start()
    {
        UpdateGameState(GameState.Menu);        
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.Menu:
                HandleMenu();
                break;
            case GameState.Playing:
                HandlePlaying();
                break;
            case GameState.Finished:
                HandleResults();
                break;
            case GameState.Results:
                HandleResults();
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleResults()
    {
        SceneManager.LoadScene(2);
    }

    private void HandlePlaying()
    {
        SceneManager.LoadScene(3);
        PickableItem.isDestroyed = false;
        SaboteurShoot.currentBall = 0;
    }

    private void HandleMenu()
    {
        SceneManager.LoadScene(1);
    }

    public enum GameState
    {
        Menu,
        Playing,
        Finished,
        Results
    }
}
