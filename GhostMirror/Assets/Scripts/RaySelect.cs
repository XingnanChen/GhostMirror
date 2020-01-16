using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySelect : MonoBehaviour
{
    public GameObject testLight;
    private Vector3 hitpos = new Vector3();
    private Sprite mySprite;
    private GameObject previousLight;
    public GameObject lightSource;
    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 testDir = new Vector3(-180,-45,0);
        if(Physics.Raycast(lightSource.transform.position,testDir,out hit))
        {
            //Transform hitObject = hit.transform;
           hitpos = new Vector3(hit.point.x+0.05f,hit.point.y+0.05f,hit.point.z);
            createLight();
            print("?");
        }
        Debug.DrawRay(lightSource.transform.position, testDir, Color.red,(1f/60f));
    }
    void createLight()
    {
        if(previousLight == null)
        {
            previousLight = (GameObject)Instantiate(testLight, hitpos, Quaternion.identity);
            print("!");
        }
        else
        {
            Destroy(previousLight);
            previousLight = (GameObject)Instantiate(testLight, hitpos, Quaternion.identity);
            print("!");
        }
        
    }
}
