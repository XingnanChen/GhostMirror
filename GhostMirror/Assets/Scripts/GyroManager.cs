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
        Vector3 gyroRot = Input.gyro.rotationRate * rotateSpeed;

        Vector3 gyroRotation = Input.gyro.attitude.eulerAngles;
        gyroRotation = new Vector3(-gyroRotation.x, -gyroRotation.y, gyroRotation.z);
        this.transform.eulerAngles = gyroRotation;
        this.transform.Rotate(Vector3.right *90, Space.World);

    }
    private Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, q.z, q.w);
    }
}
