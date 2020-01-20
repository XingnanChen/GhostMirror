using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForwardButton : MonoBehaviour
{
    public Button forwardButton;
  //  public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = forwardButton.GetComponent<Button>();
   //     camera = GameObject.Find("Main Camera");
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        print("click");
    //    print(camera.transform.position);
    }
}
