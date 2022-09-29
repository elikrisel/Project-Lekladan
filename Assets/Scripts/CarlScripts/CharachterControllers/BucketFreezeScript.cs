using UnityEngine;

public class BucketFreezeScript : MonoBehaviour
{
    private Rigidbody _playerRB;

    private void Start()
    {
        _playerRB = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        FreezeY();
    }

    private void FreezeY()
    {
        if (this.gameObject.GetComponent<GrounCheck>()._onGround)
        {
            _playerRB.constraints = RigidbodyConstraints.FreezePositionY;
            _playerRB.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
}
