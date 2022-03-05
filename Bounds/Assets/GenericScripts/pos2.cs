using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pos2 : MonoBehaviour
{
    void Awake()
    {
        this.transform.parent = GameObject.Find("Main Camera").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        //float ymax = GetComponentInParent<edges>().topspace;
        float ymin = GetComponentInParent<edges>().bottomspace;
        float heightofscreen = GetComponentInParent<edges>().heightofscreen;
        float widthofscreen = GetComponentInParent<edges>().widthofscreen;

        transform.position = new Vector2(0, -heightofscreen / 2 + ymin - GetComponent<SpriteRenderer>().size.y / 2);
        transform.localScale = new Vector2(widthofscreen, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
