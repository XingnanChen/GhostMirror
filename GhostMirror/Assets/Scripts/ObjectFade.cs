using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFade : MonoBehaviour
{
    private Renderer rend;
    public GameObject Faderay;
    public GameObject Fadecamera;
    private bool isrendered = false;
    private bool isscaled = false;
    private float collisionTime = 0;
    private Renderer photoRenderer;
    private Renderer ifRope;
    private Renderer hangingGhost;
    private bool displayHanging = false;
    private Renderer picture1;
    private Renderer picture2;
    private Renderer picture2T;
    private Renderer picture3T;
    private Renderer picture4T;
    private Renderer picture5T;
    private Renderer picture6T;
    private Renderer picture7T;
    private Renderer picture8T;
    private Renderer picture3;
    private Renderer picture4;
    private Renderer picture5;
    private Renderer picture6;
    private Renderer picture7;
    private Renderer picture;
    private void Start()
    {
        /*rend = GetComponent<Renderer>();
        rend.enabled = false;*/
        rend = GetComponent<Renderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;
        photoRenderer = GameObject.Find("photo_3_lowres_mirrior").GetComponent<Renderer>();
        Color pc = photoRenderer.material.color;
        pc.a = 0f;
        photoRenderer.material.color = pc;
        ifRope = GameObject.Find("hanging_rope").GetComponent<Renderer>();
        ifRope.enabled = false;
        hangingGhost = GameObject.Find("hanging_ghost_test").GetComponent<Renderer>();
        /*Color ghostColor = hangingGhost.material.color;
        ghostColor.a = 0f;
        hangingGhost.material.color = ghostColor;*/
        hangingGhost.enabled = false;
        picture1 = GameObject.Find("picture (1)").GetComponent<Renderer>();
        picture2 = GameObject.Find("picture (2)").GetComponent<Renderer>();
        picture3 = GameObject.Find("picture (3)").GetComponent<Renderer>();
        picture4 = GameObject.Find("picture (4)").GetComponent<Renderer>();
        picture5 = GameObject.Find("picture (5)").GetComponent<Renderer>();
        picture6 = GameObject.Find("picture (6)").GetComponent<Renderer>();
        picture7 = GameObject.Find("picture (7)").GetComponent<Renderer>();
        picture = GameObject.Find("picture").GetComponent<Renderer>();
        picture2T = GameObject.Find("picture (8)").GetComponent<Renderer>();
        picture2T.enabled = false;
        picture3T = GameObject.Find("picture (10)").GetComponent<Renderer>();
        picture3T.enabled = false;
        picture4T = GameObject.Find("picture (9)").GetComponent<Renderer>();
        picture4T.enabled = false;
        picture5T = GameObject.Find("picture (13)").GetComponent<Renderer>();
        picture5T.enabled = false;
        picture6T = GameObject.Find("picture (14)").GetComponent<Renderer>();
        picture6T.enabled = false;
        picture7T = GameObject.Find("picture (12)").GetComponent<Renderer>();
        picture7T.enabled = false;
        picture8T = GameObject.Find("picture (11)").GetComponent<Renderer>();
        picture8T.enabled = false;
    }

    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            print("!");
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator PhotoFadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color pc = photoRenderer.material.color;
            pc.a = f;
            photoRenderer.material.color = pc;
            print("!");
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator HangGhostFade()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color ghostC = hangingGhost.material.color;
            ghostC.a = f;
            hangingGhost.material.color = ghostC;
            print("!");
            yield return new WaitForSeconds(0.05f);
        }

    }

    IEnumerator HangGhostFadeOut()
    {
        for (float f = 1f; f >= 0.001f; f -= 0.05f)
        {
            Color ghostC = hangingGhost.material.color;
            ghostC.a = f;
            hangingGhost.material.color = ghostC;
            print("!");
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void FadeOut()
    {
        /*for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            print("!");
            yield return new WaitForSeconds(0.2f);
        }*/
        rend.enabled = false;
    }

    private void Update()
    {
        Vector3 lightPos = RaySelect.hitpos;
        RaycastHit hitInfo;
        Ray ray1 = new Ray(Faderay.GetComponent<RaySelect>().GetLightSourcePosition(), Faderay.GetComponent<RaySelect>().GetLightSourceDir());
        if (gameObject.GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f) && Fadecamera.GetComponent<CameraList>().parent.name == "mirror")
        {
            //rend.enabled = true;
            StartCoroutine("FadeIn");
            isrendered = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if(isrendered == true)
        {
            //gameObject.transform.position = lightPos;
            Vector3 ghostPosition = lightPos;
            ghostPosition.z -= 0.1f;
            gameObject.transform.position = ghostPosition;

        }
        if (GameObject.Find("picture (1)").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f) && Fadecamera.GetComponent<CameraList>().parent.name == "picture (1)" && isrendered == true && isscaled == false)
        {
            //rend.enabled = true;
            isscaled = true;
            gameObject.transform.localScale += new Vector3(-0.04f, -0.04f, 0);
            print("change");
            
        }

        if(isscaled == true && Fadecamera.GetComponent<CameraList>().parent.name == "picture (1)")
        {
            collisionTime += Time.deltaTime;
            if(collisionTime >= 3f)
            {
                StartCoroutine("PhotoFadeIn");
                FadeOut();
                ifRope.enabled = true;
                displayHanging = true;
                
            }
        }

        if (isscaled == true && Fadecamera.GetComponent<CameraList>().parent.name == "InitCameraObject")
        {
            //rend.enabled = true;
            isscaled = false;
            gameObject.transform.localScale += new Vector3(0.04f, 0.04f, 0);
        }

        if(displayHanging == true)
        {
            if(GameObject.Find("hanging_ghost_test").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f))
            {
                //StartCoroutine("HangGhostFade");
                hangingGhost.enabled = true;
            }
            else if(GameObject.Find("hanging_ghost_test").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f) == false)
            {
                //StartCoroutine("HangGhostFadeOut");
                hangingGhost.enabled = false;
            }

        }

        if (Fadecamera.GetComponent<CameraList>().parent.name == "picture (1)")
        {
            if(GameObject.Find("picture (2)").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f))
            {
                picture2T.enabled = true;
                picture2.enabled = false;
            }
            if (GameObject.Find("picture (2)").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f)==false)
            {
                picture2T.enabled = false;
                picture2.enabled = true;
            }
            if (GameObject.Find("picture (3)").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f))
            {
                picture3T.enabled = true;
                picture3.enabled = false;
            }
            if (GameObject.Find("picture (3)").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f) == false)
            {
                picture3T.enabled = false;
                picture3.enabled = true;
            }
            if (GameObject.Find("picture (4)").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f))
            {
                picture4T.enabled = true;
                picture4.enabled = false;
            }
            if (GameObject.Find("picture (4)").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f) == false)
            {
                picture4T.enabled = false;
                picture4.enabled = true;
            }
            if (GameObject.Find("picture (5)").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f))
            {
                picture5T.enabled = true;
                picture5.enabled = false;
            }
            if (GameObject.Find("picture (5)").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f) == false)
            {
                picture5T.enabled = false;
                picture5.enabled = true;
            }
            if (GameObject.Find("picture (6)").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f))
            {
                picture6T.enabled = true;
                picture6.enabled = false;
            }
            if (GameObject.Find("picture (6)").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f) == false)
            {
                picture6T.enabled = false;
                picture6.enabled = true;
            }
            if (GameObject.Find("picture (7)").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f))
            {
                picture7T.enabled = true;
                picture7.enabled = false;
            }
            if (GameObject.Find("picture (7)").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f) == false)
            {
                picture7T.enabled = false;
                picture7.enabled = true;
            }
            if (GameObject.Find("picture").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f))
            {
                picture8T.enabled = true;
                picture.enabled = false;
            }
            if (GameObject.Find("picture").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f) == false)
            {
                picture8T.enabled = false;
                picture.enabled = true;
            }


        }


    }

    

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine("FadeIn");
        }
    }

    IEnumerator FadeIn()
    {
        SetMaterialTransparent();
        iTween.FadeTo(g, 0, 1f);
        yield return new WaitForSeconds(0.05f);
    }*/
    /*Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.J))
        {
            StartCoroutine("FadeIn");
        }
    }

    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            print("!");
            yield return new WaitForSeconds(0.05f);
        }

    }

    public void startFading()
    {
        StartCoroutine("FadeIn");
    }*/
    /*private void SetMaterialTransparent()
    {
        foreach(Material m in g.GetComponent<Renderer>().materials)
        {
            m.SetFloat("_Mode", 2);
            m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            m.SetInt("_ZWrite", 0);
            m.DisableKeyword("_ALPHATEST_ON");
            m.EnableKeyword("_ALPHABLEND_ON");
            m.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            m.renderQueue = 3000;
            print("!");
        }
    }*/


}
