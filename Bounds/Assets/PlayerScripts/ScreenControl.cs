using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenControl : MonoBehaviour
{
    private Vector2 startPos;
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float duration = 2f;
    private bool fingerDown;
    private bool rote;
    private float widthofscreen;
    // Start is called before the first frame update
    void Start()
    {
        fingerDown = false;
        rote = true;
        widthofscreen = GetComponentInParent<edges>().widthofscreen;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 /*&& Input.touches[0].phase == TouchPhase.Began*/)
        {
            if (!fingerDown)
            {
                startPos = Input.touches[0].position;
                fingerDown = true;
            }
            if (Input.touches[0].position.x < (startPos.x - 50))
            {
                if (transform.position.x > -widthofscreen / 2)
                    transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                else
                    transform.position = new Vector2(-widthofscreen / 2, transform.position.y);
            }
            else if(Input.touches[0].position.x > (startPos.x + 50))
            {
                if (transform.position.x < widthofscreen / 2)
                    transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                else
                    transform.position = new Vector2(widthofscreen / 2, transform.position.y);
            }
            if(Input.touches[0].position.y < (startPos.y - 150) && rote)
            {
                rote = false;
                transform.rotation = Quaternion.Euler(0, 0, 10);
                StartCoroutine(RotateAntiClock());
            }
            else if(Input.touches[0].position.y > (startPos.y + 150) && rote)
            {
                rote = false;
                transform.rotation = Quaternion.Euler(0, 0, -10);
                StartCoroutine(RotateClock());
            }
            if (Input.touches[0].phase == TouchPhase.Ended)
                fingerDown = false;
        }
    }
    IEnumerator RotateAntiClock()
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
    IEnumerator RotateClock()
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
