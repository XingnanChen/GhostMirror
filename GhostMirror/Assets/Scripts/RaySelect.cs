using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySelect : MonoBehaviour
{
    public GameObject testLight;
    public static Vector3 hitpos = new Vector3();
    private Sprite mySprite;
    private GameObject previousLight;
    public GameObject lightSource;
    public GameObject camera;
    // Update is called once per frame
    private Rigidbody rb;
    private Vector3 gyroRotation;

    private string cameraDir;

  //  [SerializeField] private AudioClip ghostRevealing;

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
          //      SoundManager.Instance.PlaySFX(ghostRevealing);
            }
        }



    }
    void createLight()
    {
        if(previousLight == null)
        {
            previousLight = (GameObject)Instantiate(testLight, hitpos, Quaternion.identity);
            previousLight.transform.eulerAngles = gyroRotation;
            previousLight.transform.Rotate(Vector3.right * 90, Space.World);
        }
        else
        {
            Destroy(previousLight);
            previousLight = (GameObject)Instantiate(testLight, hitpos, Quaternion.identity);
            previousLight.transform.eulerAngles = gyroRotation;
            previousLight.transform.Rotate(Vector3.right * 90, Space.World);
        }
    }

    private Quaternion ConvertRotation(Quaternion q)
    {
        cameraDir = camera.GetComponent<CameraList>().cameraDir;
        float smooth = 5.0f;
        float tiltAngle = 90f;
        if (cameraDir.Equals("Forward"))
        {
            print("forward");

            Quaternion target = Quaternion.Euler(0, 0, 0);
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, target, Time.deltaTime*smooth);
            return Quaternion.Euler(90, 0, 0) * (new Quaternion(-q.x, -q.y, q.z, q.w));
        }
        else if (cameraDir.Equals("Left"))
        {
            print("left");
            Quaternion target = Quaternion.Euler(0, -90, 0);
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, target, Time.deltaTime*smooth);
            print(camera.transform.rotation);
            return Quaternion.Euler(90, -90, 0) * (new Quaternion(-q.x, -q.y, q.z, q.w));
        }
        else
        {
            print("right");
            return Quaternion.Euler(90, 0, 0) * (new Quaternion(-q.x, -q.y, q.z, q.w));
        }
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
