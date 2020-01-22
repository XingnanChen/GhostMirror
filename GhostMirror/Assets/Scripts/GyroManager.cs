using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManager : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float upSpeed = 2f;
    [SerializeField]
    private float maxSpeed = 10f;
    [SerializeField]
    private float rotateSpeed = 2f;
    private Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.gyro.enabled)
        {
            transform.rotation = ConvertRotation(Input.gyro.attitude);

        }
    }

    private Quaternion ConvertRotation(Quaternion q)
    {
        return Quaternion.Euler(90, 90, 0) * (new Quaternion(-q.x, -q.y, q.z, q.w));
    }

}
