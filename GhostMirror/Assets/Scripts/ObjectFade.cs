using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFade : MonoBehaviour
{
    public GameObject g;

    private void Start()
    {
        
        
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
