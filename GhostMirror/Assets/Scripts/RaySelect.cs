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
    private Vector3 gyroRotation;

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
            lightSource.transform.rotation = ConvertRotation(Input.gyro.attitude);
            //    lightSource.transform.Rotate(Vector3.right * 270, Space.World);
            RaycastHit hit;
            if (Physics.Raycast(lightSource.transform.position, lightSource.transform.forward, out hit))
            {
                //Transform hitObject = hit.transform;
                hitpos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                createLight();
            }
            Debug.DrawRay(lightSource.transform.position, lightSource.transform.forward, Color.red, (1f / 60f));
            testLight.transform.rotation = ConvertRotation(Input.gyro.attitude);
            // Vector3 gyroRot = Input.gyro.rotationRate * rotateSpeed;
            if (GameObject.Find("door").GetComponent<BoxCollider>().bounds.Contains(hitpos))
            {

            }
        }



    }
    void createLight()
    {
        if(previousLight == null)
        {
            previousLight = (GameObject)Instantiate(testLight, hitpos, Quaternion.identity);
            previousLight.transform.eulerAngles = gyroRotation;
            previousLight.transform.Rotate(Vector3.right * 180, Space.World);
        }
        else
        {
            Destroy(previousLight);
            previousLight = (GameObject)Instantiate(testLight, hitpos, Quaternion.identity);
            previousLight.transform.eulerAngles = gyroRotation;
            previousLight.transform.Rotate(Vector3.right * 180, Space.World);
        }
    }

    private Quaternion ConvertRotation(Quaternion q)
    {
        return Quaternion.Euler(90, 90, 0) * (new Quaternion(-q.x, -q.y, q.z, q.w));
    }

    public Vector3 GetHitPosition()
    {
        return hitpos;
    }
    public Vector3 GetLightSourcePosition()
    {
        return lightSource.transform.position;
    }
    public Vector3 GetLightSourceDir()
    {
        return lightSource.transform.forward;
    }
}
