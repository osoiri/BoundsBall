using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 100.0f;
    float forcex = 0;
    float forcey = 0;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        forcex = Random.Range(0, 2) == 0 ? Random.Range(0.25f, 0.5f) : Random.Range(-0.25f, -0.5f);
        if (transform.position.y > 0)
        {
            
            forcey = Random.Range(-0.6f, -0.9f);
        }
        else
        {
            forcey = Random.Range(0.6f, 0.9f);
        }
        Vector2 directionforce = new Vector2(forcex, forcey);
        rb.AddForce(directionforce * speed * Mathf.Abs(transform.position.y), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
