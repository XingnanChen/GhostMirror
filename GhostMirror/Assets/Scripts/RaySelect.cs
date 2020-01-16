using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySelect : MonoBehaviour
{
    public GameObject testLight;
    private Vector3 hitpos = new Vector3();
    private Sprite mySprite;
    private GameObject previousLight;
    public GameObject lightSource;
    // Update is called once per frame
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
        Vector3 gyroRotation = Input.gyro.attitude.eulerAngles;
        gyroRotation = new Vector3(-gyroRotation.x, -gyroRotation.y, gyroRotation.z);
        lightSource.transform.eulerAngles = gyroRotation;
        lightSource.transform.Rotate(Vector3.right * 90, Space.World);
        RaycastHit hit;
        if(Physics.Raycast(lightSource.transform.position,lightSource.transform.forward, out hit))
        {
            //Transform hitObject = hit.transform;
           hitpos = new Vector3(hit.point.x,hit.point.y,hit.point.z);
            createLight();
        }
        Debug.DrawRay(lightSource.transform.position, lightSource.transform.forward,Color.red,(1f/60f));
       // Vector3 gyroRot = Input.gyro.rotationRate * rotateSpeed;

        
    }
    void createLight()
    {
        if(previousLight == null)
        {
            previousLight = (GameObject)Instantiate(testLight, hitpos, Quaternion.identity);
        }
        else
        {
            Destroy(previousLight);
            previousLight = (GameObject)Instantiate(testLight, hitpos, Quaternion.identity);
        }
        
    }
}
