using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button button;
    public GameObject camera;
    public GameObject ray;
   
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
                print(camera.transform.position);
                camera.GetComponent<CameraList>().parent = gameObject;
                camera.GetComponent<CameraList>().children = gameObject.GetComponent<CameraPoint>().gameObjects;

                Vector3 camPos = gameObject.GetComponent<CameraPoint>().camPosition;
                camera.transform.position = camPos;


                print(camera.GetComponent<CameraList>().parent.name);
                foreach (GameObject t in camera.GetComponent<CameraList>().children)
                {
                    print("children" + t.name);
                }
                //;
                break;
            }
         //   else print(false);
        }
      
    }

    void MoveBack()
    {
        // trigger = true;

        camera.GetComponent<CameraList>().parent = camera.GetComponent<CameraList>().parent.GetComponent<CameraPoint>().parentObject;
        camera.GetComponent<CameraList>().children = camera.GetComponent<CameraList>().parent.GetComponent<CameraPoint>().gameObjects;

        Vector3 camPos = camera.GetComponent<CameraList>().parent.GetComponent<CameraPoint>().camPosition;
        camera.transform.position = camPos;

        print("parent"+camera.GetComponent<CameraList>().parent.name);

        foreach(GameObject gameObject in camera.GetComponent<CameraList>().children)
        {
            print("children"+gameObject.name);
        }
    }
}
