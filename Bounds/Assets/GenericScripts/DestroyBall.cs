using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Circle")
        {
            if(gameObject.name == "UpperBlock")
            {
                MatchManager.setscore();
            }
            else if(gameObject.name == "LowerBlock")
            {
                MatchManager.setoppscore();
            }
            Destroy(collision.gameObject);
            BallInstantiate.ballcount--;
        }
    }
}
