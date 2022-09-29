using UnityEngine;

public class SaboteurBodySlam : MonoBehaviour
{
    [SerializeField] private int _damageToGive;
    private GameObject _hello;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(_damageToGive);
        }
    }
}
