using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
public class PlayerManager : MonoBehaviour
{
    public List<PlayerInput> _players = new List<PlayerInput>();
    [SerializeField] private List<Transform> _startingPoints;
    [SerializeField] private List<GameObject> _playerPrefabs;

    private PlayerInputManager _playerInputManager;

    public static PlayerManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        _playerInputManager = FindObjectOfType<PlayerInputManager>();
    }

    private void OnEnable()
    {
        _playerInputManager.onPlayerJoined += AddPlayer;
        
    }

    private void Update()
    {
        _playerInputManager.playerPrefab = _playerPrefabs[_players.Count];
    }

    private void OnDisable()
    {
        _playerInputManager.onPlayerLeft -= AddPlayer;
    }

    public void AddPlayer(PlayerInput _Player)
    {
        _players.Add(_Player);
        
        _Player.gameObject.transform.position = _startingPoints[_players.Count - 1].position;

    }
}
