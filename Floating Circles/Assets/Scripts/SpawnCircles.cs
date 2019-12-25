using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class SpawnCircles : MonoBehaviour
{
    public GameObject Rectangle;

    //circle properties
    public int MaxCircles;
    [Range(0.1f,0.5f)]
    public float radius;
    public Transform circlePrefab;

    private List<Transform> spawnedCircles;

    // Start is called before the first frame update
    void Start()
    {
        var circles = new Dictionary<float, List<float>>();
        GenerateCircles(circles);

    }

    void Update()
    {

    }

    private void GenerateCircles(Dictionary<float, List<float>> circles)
    {
        circlePrefab.localScale = new Vector3(radius * 2, radius * 2, 0);

        for (int i = 0; i < MaxCircles; i++)
        {

            
            float rndX = Random.Range(Rectangle.transform.position.x + radius, 
                Rectangle.transform.position.x  + Rectangle.transform.localScale.x - radius);

            float rndY = Random.Range(Rectangle.transform.position.y + radius, 
                Rectangle.transform.position.y  + Rectangle.transform.localScale.y - radius);

            if (SafeToSpawn(circles, rndX, rndY))
            {
                if (!circles.ContainsKey(rndX))
                {
                    circles.Add(rndX, new List<float>());
                }
                circles[rndX].Add(rndY);

                // var circlePos = Camera.main.ViewportToWorldPoint(new Vector3(position.x,position.y, 1));
                var position = new Vector3(rndX, rndY,/*Rectangle.transform.position.z - 1*/0);
                
                var spawnedCircle = Instantiate(circlePrefab, position, Quaternion.identity);
                spawnedCircle.parent = Rectangle.transform;
                
            }
            else
            {
                i-=1;
            }
        }
    }

    private bool SafeToSpawn(Dictionary<float, List<float>> circles, float rndX, float rndY)
    {
        if (CircleColliding(circles, rndX, rndY))
        {
            return false;
        }
        return true;
    }

    private bool CircleColliding(Dictionary<float, List<float>> circles, float x, float y)
    {
        //we need to check around the circle position
        var diameter = radius * 2;
        float xMostLeft = x - diameter;
        float xMostRight = x + diameter;
        var surroundingXs = circles.Where(c => c.Key >= xMostLeft && c.Key <= xMostRight).Select(mc => mc.Key).ToList();
        
        if (surroundingXs.Count == 0)
        {
            
            return false;
        }

        foreach (float surroundingX in surroundingXs)
        {
            foreach (float surroundingY in circles[surroundingX])
            {
                
                if (Vector2.Distance(new Vector2(x, y), new Vector2(surroundingX, surroundingY)) < diameter)
                {

                    return true;
                }
            }
        }

        return false;
    }
}

