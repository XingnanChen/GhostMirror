using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFade : MonoBehaviour
{
    private Renderer rend;
    public GameObject Faderay;
    public GameObject Fadecamera;
    private bool isrendered = false;

    private void Start()
    {
        /*rend = GetComponent<Renderer>();
        rend.enabled = false;*/
        rend = GetComponent<Renderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;


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
