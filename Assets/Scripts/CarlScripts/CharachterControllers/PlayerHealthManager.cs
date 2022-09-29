using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("Health Values")]
    [SerializeField] private int _currentHealth;

    [SerializeField] private float _invincibleTime;
    private float _invincible;

    public Grabbing _grabbing;
    public static bool isDead;
    private bool _playerDied;

    [Header("Components")]
    [SerializeField] private GameObject _playerArt;
    [SerializeField] private GameObject _ghostArt;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _particleSystem;
    private void Start()
    {
        _playerDied = false;
        _currentHealth = SettingHolder.Instance._startingHealth;

        _grabbing = GetComponent<Grabbing>();
        _particleSystem = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if(_currentHealth == 0 && !_playerDied)
        {
            PlayerDeath();
            
            _playerDied = true;
        }
    }

    public void HurtPlayer(int _damageAmount)
    {
        if (_currentHealth! > 0 && Time.time > _invincible)
        {

            _invincible = Time.time + _invincibleTime;

            _currentHealth -= _damageAmount;

            _animator.Play("Damage");
            _particleSystem.Play();
            SoundManager.Instance.Play(SettingHolder.Instance.hitMarker);
            ScoreManager.instance.AddSaboteurScore();

        }

        else return;
    }

    private void PlayerDeath()
    {
        
        
        _playerArt.SetActive(false);
        _ghostArt.SetActive(true);
        ScoreManager.instance.SaboteurKillsPlayer();
        _grabbing.state = Grabbing.State.Dead;
        SoundManager.Instance.Play(SettingHolder.Instance.Ghost);

        this.GetComponent<Grabbing>().enabled = false;
        this.GetComponent<PullScript>().enabled = true;

        this.gameObject.layer = LayerMask.NameToLayer("Ghost");
    }
}
