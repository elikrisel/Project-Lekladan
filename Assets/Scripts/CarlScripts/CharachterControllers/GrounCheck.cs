using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrounCheck : MonoBehaviour
{
    [Header("Ground Check Distance")]
    [SerializeField] private float _maxDistance = 1f;

    private CapsuleCollider _playerCollider;
    public bool _onGround;

    private void Start()
    {
        _playerCollider = this.gameObject.GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        OnGround();
    }

    public void OnGround()
    {
        Ray ray = new Ray(transform.position + _playerCollider.center, Vector3.down);

        _onGround = false;

        if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance, LayerMask.GetMask("Ground")))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red, 1f);

            if (hit.distance < (_playerCollider.center.y + 0.15f))
            {
                _onGround = true;
            }
        }
    }
}
