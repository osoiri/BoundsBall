using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleLocSize : MonoBehaviour
{
    void Awake()
    {
        this.transform.parent = GameObject.Find("Main Camera").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        //float yminPos = GetComponent<edges>().bottomspace;
        float ymaxPos = GetComponentInParent<edges>().topspace;
        float widthofscreen = GetComponentInParent<edges>().widthofscreen;
        float heightofscreen = GetComponentInParent<edges>().heightofscreen;

        transform.position = new Vector2(0, ymaxPos - heightofscreen / 2 - 0.2f*2);
        transform.localScale = new Vector2(widthofscreen/4, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
