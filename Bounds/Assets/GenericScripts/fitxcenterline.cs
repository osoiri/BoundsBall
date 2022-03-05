using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fitxcenterline : MonoBehaviour
{
    private SpriteRenderer sr;
    private bool colorup;
    [SerializeField]
    private float duration = 0.5f;
    void Awake()
    {
        this.transform.parent = GameObject.Find("Main Camera").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        float widthscreen = GetComponentInParent<edges>().widthofscreen;
        transform.localScale = new Vector2(widthscreen, 0.2f);
        sr = GetComponent<SpriteRenderer>();
        colorup = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (colorup)
        {
            if (MatchManager.getscore() == MatchManager.getoppscore())
            {
                colorup = false;
                StartCoroutine(LerpColour(sr.color, new Color(1, 1, 1, 0.5f)));
            }
            else if (MatchManager.getscore() < MatchManager.getoppscore())
            {
                colorup = false;
                StartCoroutine(LerpColour(sr.color, new Color(1, 0, 0, 0.5f)));
            }
            else if (MatchManager.getscore() > MatchManager.getoppscore())
            {
                colorup = false;
                StartCoroutine(LerpColour(sr.color, new Color(0, 1, 0, 0.5f)));
            }
        }
    }
    IEnumerator LerpColour(Color startcolor, Color endcolor)
    {
        float time = 0;
        while(time < duration)
        {
            sr.color = Color.Lerp(startcolor, endcolor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        colorup = true;
        sr.color = endcolor;
    }
}
