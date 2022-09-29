using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField] private int _damageToGive;
    [SerializeField] private bool _canDamage;
    private void Start()
    {
        _canDamage = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _canDamage = false;

        }

        if (collision.gameObject.CompareTag("Player") && _canDamage == true)
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(_damageToGive);
        }        
    }
}
