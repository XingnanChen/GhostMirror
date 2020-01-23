using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMajhong : MonoBehaviour
{
    public Material material;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(ObjectFade.changeMahjong == true)
        {
            rend.sharedMaterial = material;
        }
        
    }
}
