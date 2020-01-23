using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button button;
    public GameObject camera;
    public GameObject ray;
    private Vector3 camPos = Vector3.zero;
    public float smoothTime = 0.3f;
    public Vector3 velocity = Vector3.zero;
    private bool cameraMoving = false;
    [SerializeField] private AudioClip doorLocked;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        if (button.name.Equals("ForwardButton"))
        {
            btn.onClick.AddListener(MoveForward);
        }
        if (button.name.Equals("BackButton"))
        {
            btn.onClick.AddListener(MoveBack);
        }
    }

   void MoveForward()
    {
        if (GameObject.Find("ForwardButton").GetComponent<ButtonManager>().cameraMoving || GameObject.Find("BackButton").GetComponent<ButtonManager>().cameraMoving)
        {
            return;
        }
        Vector3 hitPosition = ray.GetComponent<RaySelect>().GetHitPosition();
        //bool trigger = false;
      //  foreach (GameObject.FindObjectsOfType<BoxCollider>()) ;
        foreach(GameObject gameObject in camera.GetComponent<CameraList>().children)
        {
            RaycastHit hitInfo;
            Ray ray1 = new Ray(ray.GetComponent<RaySelect>().GetLightSourcePosition(),ray.GetComponent<RaySelect>().GetLightSourceDir());
            if (gameObject.GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f)) 
            {
               // gameObject.GetComponent<BoxCollider>().bounds.Contains(hitPosition)
               
                // trigger = true;
           //     print(camera.transform.position);
                camera.GetComponent<CameraList>().parent = gameObject;
                camera.GetComponent<CameraList>().children = gameObject.GetComponent<CameraPoint>().gameObjects;
                camera.GetComponent<CameraList>().cameraDir = gameObject.GetComponent<CameraPoint>().cameraDir;

                camPos = gameObject.GetComponent<CameraPoint>().camPosition;
                cameraMoving = true;

                print("Fparent "+camera.GetComponent<CameraList>().parent.name);
                foreach (GameObject t in camera.GetComponent<CameraList>().children)
                {
                    print("Fchildren " + t.name);
                }
                break;
            }
         //   else print(false);
        }
      
    }

    void MoveBack()
    {
        // trigger = true;
        if (GameObject.Find("ForwardButton").GetComponent<ButtonManager>().cameraMoving || GameObject.Find("BackButton").GetComponent<ButtonManager>().cameraMoving)
        {
            //print(true);
            return;
        }
        camera.GetComponent<CameraList>().parent = camera.GetComponent<CameraList>().parent.GetComponent<CameraPoint>().parentObject;
        camera.GetComponent<CameraList>().children = camera.GetComponent<CameraList>().parent.GetComponent<CameraPoint>().gameObjects;

        camPos = camera.GetComponent<CameraList>().parent.GetComponent<CameraPoint>().camPosition;
        camera.GetComponent<CameraList>().cameraDir = camera.GetComponent<CameraList>().parent.GetComponent<CameraPoint>().cameraDir;
        cameraMoving = true;

       // camera.transform.position = camPos;

        print("backparent " + camera.GetComponent<CameraList>().parent.name);

        foreach (GameObject gameObject in camera.GetComponent<CameraList>().children)
        {
            print("backchildren " + gameObject.name);
        }
    }

    private void FixedUpdate()
    {
        if (cameraMoving)
        {
       //     print(true);
            camera.transform.position = Vector3.SmoothDamp(camera.transform.position, camPos, ref velocity, smoothTime);
            if (camera.transform.position == camPos)
            {
                cameraMoving = false;
                if (camera.GetComponent<CameraList>().parent.name.Equals("door"))
                {
                    SoundManager.Instance.PlaySFX(doorLocked);
                }
            }
        }
        
    }

}
