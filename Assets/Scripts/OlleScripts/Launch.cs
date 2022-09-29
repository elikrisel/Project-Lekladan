using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public Rigidbody RB;
    public GameObject anchorPoint;

    public float launchX;
    public float launchY;
    public float launchZ;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    public void AddForce(Vector3 force, ForceMode mode = ForceMode.Impulse){}

    public void Fire()
    {
        RB.AddForce(launchX, launchY, launchZ, ForceMode.Impulse);
    }

    public void ResetPosition()
    {
        transform.position = anchorPoint.transform.position;
        transform.rotation = anchorPoint.transform.rotation;
    }
}
