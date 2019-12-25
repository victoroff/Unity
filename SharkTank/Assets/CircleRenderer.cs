using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRenderer : MonoBehaviour
{
    // Start is called before the first frame update

    public float movespeed = 3.0F;
    public Vector2 directions = new Vector2(1, 1);

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        transform.position = new Vector2(
            transform.position.x + movespeed * directions.x * Time.deltaTime,
            transform.position.y + movespeed * directions.y * Time.deltaTime
       );
    }
    
}
