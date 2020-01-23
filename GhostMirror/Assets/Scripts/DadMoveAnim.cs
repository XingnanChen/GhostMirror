using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadMoveAnim : MonoBehaviour
{
    public bool playAnim;
    private Animator anim;
    public float moveSpeed = -0.0001f;
    public Vector3 stopPosition;
    public float smoothTime = 3.0f;
    public Vector3 velocity = Vector3.zero;
    private bool stopWalking;
    private bool endStart = false;
    public GameObject ghost;
    // Start is called before the first frame update
    void Start()
    {
        playAnim = false;
        anim = GetComponent<Animator>();
        stopWalking = false;
        transform.position = new Vector3(0, 0, 100);
       
    }
     
    // Update i s called once per frame
    void Update()
    {
        playAnim = ObjectFade.fatherDisplay;
        if (playAnim && endStart == false)
        {
            transform.position = new Vector3(3.531f, 0, 0.51f);
            endStart = true;
            GameObject.Find("door").transform.position = new Vector3(100, 100, 100);
        }
        if (endStart == true&&GameObject.Find("Main Camera").GetComponent<CameraList>().parent.name == "InitCameraObject")
        {           
            if (!stopWalking)
            {
                //this.transform.Translate(moveSpeed *Time.deltaTime *(-0.5f), 0, 0);
                this.transform.position = Vector3.SmoothDamp(this.transform.position, stopPosition, ref velocity, smoothTime);

            }
            if (this.transform.position.x - stopPosition.x < 0.1f)
            {
               GameObject.Destroy(ghost);
               
            }

           
        }
    }

}
