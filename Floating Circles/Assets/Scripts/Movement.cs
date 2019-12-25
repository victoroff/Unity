using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 6.0F;
    public Vector2 directions;
    //public GameObject room;
    private Transform rectangle;
    // Start is called before the first frame update
    void Awake()
    {
       directions = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
    }

    private void Start()
    {
        rectangle = transform.parent;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(
            transform.position.x + speed * directions.x * Time.deltaTime,
            transform.position.y + speed * directions.y * Time.deltaTime
        );

        //var rectBounds = rectangle.GetComponent<MeshCollider>().bounds;
        //Debug.Log(rectBounds.size.x + "----"+ rectBounds.size.y);
        
        if (transform.position.x + transform.localScale.x/2 >= rectangle.position.x + rectangle.localScale.x)
        {
            directions.x *= -1;
        }
        if (transform.position.x - transform.localScale.x/2 < rectangle.position.x)
        {
            directions.x *= -1;
        }

        

        if (transform.position.y + transform.localScale.y/2 >= rectangle.position.y + rectangle.localScale.y)
        {
            directions.y *= - 1;
        }
        if (transform.position.y - transform.localScale.y/2 <= rectangle.position.y)
        {
            directions *= -1;
        }

        //if (gameObject.GetComponent<SpriteRenderer>().bounds )
        //{

        //}
    }

 
}
