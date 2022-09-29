using UnityEngine;

public class SettingHolder : MonoBehaviour
{
    [Header("Game Settings")]
    public float _countdownTimer;
    public int _startingHealth;

    [Header("Prefabs")]
    [SerializeField]
    public GameObject SoundManagerPrefab;

    [Header("Sounds")]
    public AudioClip Ambiance;
    public AudioClip activateSound;
    public AudioClip Jump;
    public AudioClip Shoot;
    public AudioClip hitMarker;
    public AudioClip Run;
    public AudioClip Throw;
    public AudioClip Score;
    public AudioClip gameOver;
    public AudioClip Ghost;
    public AudioClip Tackled;

    [Range(0.0001f, 1f)] public float VolumeMusic;
    [Range(0.0001f, 1f)] public float VolumeFx;

    public static SettingHolder Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("A SettingsHolder already exists");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
