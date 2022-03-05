using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private bool position;
    private bool verticaldirection;
    private float endbracket;
    private float startbracket;
    [SerializeField]
    private float duration = 1f;
    private bool move;
    private bool rote;
    //private float velycomp;
    //private float velxcomp;
    //private float velratio;
    //private float enemyfieldheight;
    private float widthofscreen;
    private float posxcomp;
    private float randomrot;
    // Start is called before the first frame update
    void Start()
    {
        //here we need the second part multiplied by scale as we are changing the scale of the object dynamically based on screen size
        widthofscreen = GetComponentInParent<edges>().widthofscreen;
        endbracket =  widthofscreen/ 2 - GetComponent<SpriteRenderer>().size.x * transform.localScale.x/ 2;
        //Debug.Log(GetComponentInParent<edges>().widthofscreen);
        //Debug.Log(GetComponent<SpriteRenderer>().size.x);
        //Debug.Log(transform.localScale.x);
        startbracket = - widthofscreen / 2 + GetComponent<SpriteRenderer>().size.x * transform.localScale.x / 2;
        //enemyfieldheight = GetComponentInParent<edges>().heightofscreen / 2;
        move = true;
        rote = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Circle").Length > 0)
        {
            position = GameObject.FindGameObjectWithTag("Circle").transform.position.y > 0 ? true : false;
            verticaldirection = GameObject.FindGameObjectWithTag("Circle").GetComponent<Rigidbody2D>().velocity.y > 0 ? true : false;
            if (position && verticaldirection)
            {
                if (move)
                {
                    //ACTUAL USED: Based on x position of ball, move the paddle but intermittently using Coroutine
                    //Since, if a velx = 2*vely nearly ensures that the ball will reach the other side after 
                    //hiiting the wall, lets cap the movement matrix to a range of -2velx to 2 velx in inverse
                    //velycomp = GameObject.FindGameObjectWithTag("Circle").GetComponent<Rigidbody2D>().velocity.y;
                    //velxcomp = GameObject.FindGameObjectWithTag("Circle").GetComponent<Rigidbody2D>().velocity.x;
                    posxcomp = GameObject.FindGameObjectWithTag("Circle").transform.position.x;
                    //Debug.Log(velycomp);
                    //Debug.Log(enemyfieldheight);
                    //velratio = velxcomp / velycomp;
                    move = false;
                    StartCoroutine(MoveTowards(posxcomp));
                    randomrot = Random.value;
                    if (randomrot >= 0.5 && randomrot < 0.75 && posxcomp == transform.position.x && rote)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, -10);
                        rote = false;
                        StartCoroutine(AntiClock());
                    }
                    else if (randomrot >= 0.75 && randomrot < 1 && posxcomp == transform.position.x && rote)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 10);
                        rote = false;
                        StartCoroutine(Clock());
                    }
                }
            }
            else
            {
                if (move)
                {
                    move = false;
                    StartCoroutine(Lerp());
                }
            }
        }
    }
    IEnumerator Lerp()
    {
        float time = 0;
        Vector2 startPosition = transform.position;
        Vector2 endPosition = new Vector2(Random.Range(startbracket, endbracket), transform.position.y);
        float t = time / duration;
        while (time < duration)
        {
            t = time / duration;
            t = t * t * (3f - 2f * t);
            transform.position = Vector2.Lerp(startPosition, endPosition, t);
            time += Time.deltaTime;

            yield return null;
        }

        transform.position = endPosition;
        move = true;
    }
    IEnumerator MoveTowards(float finalpos)
    {
        Vector2 startposition = transform.position;
        Vector2 endposition = new Vector2(finalpos, transform.position.y);
        float step = 10 * Time.deltaTime;
        transform.position = Vector2.MoveTowards(startposition, endposition, step);

        yield return null;
        move = true;
    }
    IEnumerator AntiClock()
    {
        float time = 0;
        Quaternion startrot = transform.rotation;
        Quaternion endrot = Quaternion.Euler(0, 0, 0);
        while(time<duration)
        {
            transform.rotation = Quaternion.Lerp(startrot, endrot, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endrot;
        rote = true;
    }
    IEnumerator Clock()
    {
        float time = 0;
        Quaternion startrot = transform.rotation;
        Quaternion endrot = Quaternion.Euler(0, 0, 0);
        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startrot, endrot, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endrot;
        rote = true;
    }
}
