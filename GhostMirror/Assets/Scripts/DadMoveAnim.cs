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

    public GameObject ghost;
    // Start is called before the first frame update
    void Start()
    {
        playAnim = true;
        anim = GetComponent<Animator>();
        stopWalking = false;
    }
     
    // Update i s called once per frame
    void Update()
    {
        if (playAnim)
        {
            if (!stopWalking)
            {
                //this.transform.Translate(moveSpeed *Time.deltaTime *(-0.5f), 0, 0);
                this.transform.position = Vector3.SmoothDamp(this.transform.position, stopPosition, ref velocity, smoothTime);

            }
            if (this.transform.position.x-stopPosition.x <0.1f)
            {
                GameObject.Destroy(ghost);
            }

        }
    }

}
