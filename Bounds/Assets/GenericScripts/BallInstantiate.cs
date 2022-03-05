using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallInstantiate : MonoBehaviour
{
    public static int ballcount = 0;
    public GameObject Ball;
    private float heightofscreen;
    private float ymaxPos;
    private float yminPos;
    void Awake()
    {
        this.transform.parent = GameObject.Find("Main Camera").transform;
    }
    void Start()
    {
        heightofscreen = GetComponentInParent<edges>().heightofscreen;
        ymaxPos = GetComponentInParent<edges>().topspace;
        yminPos = GetComponentInParent<edges>().bottomspace;
    }
    // Update is called once per frame
    void Update()
    {
        if (MatchManager.getscore() < 3 && MatchManager.getoppscore() < 3)
        {
            //Debug.Log(MatchManager.getoppscore());
            if (GameObject.FindGameObjectsWithTag("Circle").Length <= 0)
            {
                if (Random.value > 0.5)
                    Instantiate(Ball, new Vector2(0, ymaxPos - heightofscreen / 2 - 1f), Quaternion.identity);
                else
                    Instantiate(Ball, new Vector2(0, -heightofscreen / 2 + yminPos + 1f), Quaternion.identity);
            }
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
