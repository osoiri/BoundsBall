using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edges : MonoBehaviour
{
    private BoxCollider2D topwall;
    private BoxCollider2D bottomwall;
    private BoxCollider2D leftwall;
    private BoxCollider2D rightwall;
    public float topspace;
    public float bottomspace;
    public float heightofscreen;
    public float widthofscreen;
    void Awake()
    {
        topwall = gameObject.AddComponent<BoxCollider2D>();
        bottomwall = gameObject.AddComponent<BoxCollider2D>();
        leftwall = gameObject.AddComponent<BoxCollider2D>();
        rightwall = gameObject.AddComponent<BoxCollider2D>();
        float halfHeight = Camera.main.orthographicSize;
        float halfWidth = Camera.main.aspect * halfHeight;
        //float ratio = Screen.safeArea.height / Screen.height;
        float bottomoffset = Screen.safeArea.y * halfHeight * 2 / Screen.height;
        //Debug.Log(Screen.safeArea.y);
        //Debug.Log(yminPos);
        float ymaxPos = Screen.safeArea.yMax * halfHeight * 2 / Screen.height;
        //Debug.Log(Screen.safeArea.yMax);
        //Debug.Log(ymaxPos);
        //Debug.Log(Screen.safeArea.height);
        //float safeSize = ratio * halfHeight * 2;
        float topoffset = halfHeight * 2 - ymaxPos;
        //Debug.Log(topoffset);
        topwall.size = bottomwall.size = leftwall.size = rightwall.size = new Vector2(halfWidth*2,halfHeight *2);
        topwall.offset = new Vector2(0, halfHeight*2 - topoffset);
        bottomwall.offset = new Vector2(0, -halfHeight * 2 + bottomoffset);
        leftwall.offset = new Vector2(-halfWidth*2, 0);
        rightwall.offset = new Vector2(halfWidth*2, 0);

        topspace = ymaxPos;
        bottomspace = bottomoffset;
        heightofscreen = halfHeight * 2;
        widthofscreen = halfWidth * 2;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
