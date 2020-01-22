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
    private void Start()
    {
        /*rend = GetComponent<Renderer>();
        rend.enabled = false;*/
        rend = GetComponent<Renderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;
        photoRenderer = GameObject.Find("photo_3_lowres").GetComponent<Renderer>();
        Color pc = photoRenderer.material.color;
        pc.a = 0f;
        photoRenderer.material.color = pc;
        ifRope = GameObject.Find("hanging_rope").GetComponent<Renderer>();
        ifRope.enabled = false;
        hangingGhost = GameObject.Find("mouse_1.4_0").GetComponent<Renderer>();
        /*Color ghostColor = hangingGhost.material.color;
        ghostColor.a = 0f;
        hangingGhost.material.color = ghostColor;*/
        hangingGhost.enabled = false;
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
            yield return new WaitForSeconds(0.2f);
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
        if (GameObject.Find("photo_3_lowres_missing_mother").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f) && Fadecamera.GetComponent<CameraList>().parent.name == "photo_3_lowres_missing_mother" && isrendered == true && isscaled == false)
        {
            //rend.enabled = true;
            isscaled = true;
            gameObject.transform.localScale += new Vector3(-0.04f, -0.04f, 0);
            print("change");
            
        }

        if(isscaled == true && Fadecamera.GetComponent<CameraList>().parent.name == "photo_3_lowres_missing_mother")
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
            if(GameObject.Find("mouse_1.4_0").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f))
            {
                //StartCoroutine("HangGhostFade");
                hangingGhost.enabled = true;
            }
            else if(GameObject.Find("mouse_1.4_0").GetComponent<BoxCollider>().Raycast(ray1, out hitInfo, 1000f) == false)
            {
                //StartCoroutine("HangGhostFadeOut");
                hangingGhost.enabled = false;
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
