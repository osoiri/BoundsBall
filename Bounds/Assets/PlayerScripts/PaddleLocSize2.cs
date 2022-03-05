using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleLocSize2 : MonoBehaviour
{
    void Awake()
    {
        this.transform.parent = GameObject.Find("Main Camera").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        float yminPos = GetComponentInParent<edges>().bottomspace;
        float heightofscreen = GetComponentInParent<edges>().heightofscreen;
        float widthofscreen = GetComponentInParent<edges>().widthofscreen;

        transform.position = new Vector2(0, -heightofscreen / 2 + yminPos + 0.2f*2);
        transform.localScale = new Vector2(widthofscreen / 4, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
