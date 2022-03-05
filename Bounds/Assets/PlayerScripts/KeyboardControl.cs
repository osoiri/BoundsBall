using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float duration = 2f;
    private bool rote;
    private float widthofscreen;
    // Start is called before the first frame update
    void Start()
    {
        rote = true;
        widthofscreen = GetComponentInParent<edges>().widthofscreen;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > -widthofscreen / 2)
                transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            else
                transform.position = new Vector2(-widthofscreen / 2, transform.position.y);
        }
        if(Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < widthofscreen / 2)
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            else
                transform.position = new Vector2(widthofscreen / 2, transform.position.y);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && rote == true)
        {
            rote = false;
            transform.rotation = Quaternion.Euler(0, 0, 10);
            StartCoroutine(RotateAntiClock());
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) && rote == true)
        {
            rote = false;
            transform.rotation = Quaternion.Euler(0, 0, -10);
            StartCoroutine(RotateClock());
        }
    }
    IEnumerator RotateAntiClock()
    {
        float time = 0;
        Quaternion startrot = transform.rotation;
        Quaternion endrot = Quaternion.Euler(0, 0, 0);
        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startrot, endrot, time/duration);
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
        while(time < duration)
        {
            transform.rotation = Quaternion.Lerp(startrot, endrot, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endrot;
        rote = true;
    }
}
