using System.Collections.Generic;
using UnityEngine;

public class FloatingCircles : MonoBehaviour
{
    //rectangle p[roperties
    //public int RectangleWidth;
    //public int RectangleHeight;
    //private Sprite rectSprite;
    //private SpriteRenderer sr;
    //public Color color = Color.blue;

   

    //circle properties
    public int MaxCircles;
    public float radius;
    public Transform circlePrefab;
    //void Awake()
    //{
    //    sr = GetComponent<SpriteRenderer>();
    //    sr.color = color;

    //    // transform.position = new Vector3(0f, 0f, 0.0f);
    //}

    // Start is called before the first frame update
    void Start()
    {
        //arr
        //var circles = new Vector2[maxCircles];
        //CreateCircles(circles);

        //list - not working fast, can't check raiduses properly
        //var circles = new List<Vector2>();
        //GenerateCircles(circles);

        //Create Rectangle
       // CreateRectangle(RectangleWidth, RectangleHeight);
       
        //with dict
        var circles = new Dictionary<float, List<Vector2>>();
        GenerateCircles(circles);
     //   Debug.Log(rectSprite.rect.x + "/" + rectSprite.rect.y);
        //foreach (var circle in circles)
        //{
        //    Debug.Log(circle.Value);
        //}
    }

  

    void Update()
    {

    }
    //generate circles using List
    //private void GenerateCircles(List<Vector2> circles)
    //{
    //    for (int i = 0; i < maxCircles; i++)
    //    {
    //        var pos = new Vector2(Random.Range(radius, maxCircles), Random.Range(radius, maxCircles));

    //        if (!circles.Contains(pos))//how to check radius?
    //        {
    //            circles.Add(pos);
    //        }
    //        else
    //        {
    //            i--;
    //        }
    //    }
    //}
    //private void CreateRectangle(int rectangleWidth, int rectangleHeight)
    //{
    //    Texture2D tex = new Texture2D(rectangleWidth, rectangleHeight);

    //    var rect = new Rect(0.0f, 0.0f, tex.width, tex.height);
    //    //var pivot = new Vector2(rect.x, rect.y);

    //    rectSprite = Sprite.Create(tex, rect, new Vector2(0, 0));
    //    sr.sprite = rectSprite;

    //}

    private void GenerateCircles(Dictionary<float,List<Vector2>> circles)
    {
        for (int i = 0; i < MaxCircles; i++)
        {
            var position = new Vector2(Random.Range(0, 1000), Random.Range(0, 1000));

            if (SafeToSpawn(circles, position))
            {
                if (!circles.ContainsKey(position.x))
                {
                    circles[position.x] = new List<Vector2>
                    {
                        position
                    };
                }
                else
                {
                    circles[position.x].Add(position);
                }
                Instantiate(circlePrefab, position, Quaternion.identity);
            }
            else
            {
                i--;
            }
            //PopulateCirclesOnScreen();
        }
    }

    private bool SafeToSpawn(Dictionary<float, List<Vector2>> circles, Vector2 position)
    {
        if (CircleColliding(circles,position))
        {
            return false;
        }
        return true;
    }

    private bool CircleColliding(Dictionary<float, List<Vector2>> circles, Vector2 position)
    {
        //we need to check around the circle position
        //(x-r;x+r) and (y-r;y+r)
        int xMostLeft = (int)(position.x - radius);
        int xMostRight = (int)(position.x + radius);
        var yPosition = position.y - radius;
        

        for (int i = xMostLeft; i < xMostRight; i++)
        {
            //if one of the points does not have circle we don't need to check it
            if (!circles.ContainsKey(i))
            {
                continue;
            }

            if (Vector2.Distance(new Vector2(i, yPosition), position) < radius * 2)
            {
                
                return true;
            }
            yPosition++;
        }
        return false;
    }

    //public bool CirclesColliding(Vector2 pos1, Vector2 pos2)
    //{
    //    //to do how to check position if collide
    //    // how to check circles without radius

    //    if (pos1.x == pos2.x && Vector2.Distance(pos1,pos2) < radius * 2)
    //    {
    //        return true;
    //    }
    //    return false;
    //}
    //public bool SafeToInsert(Vector2[] circles, Vector2 position)
    //{

    //    for (int i = 0; i < circles.Length; i++)
    //    {
    //        if (CirclesColliding(circles[i], position))
    //        {
    //            return false;
    //        }
    //    }
    //    return true;
    //}
    //public void CreateCircles(Vector2[] circles)
    //{
    //    for (int i = 0; i < circles.Length; i++)
    //    {
    //        var position = new Vector2(Random.Range(0, 1000), Random.Range(0, 1000));
    //        if (SafeToInsert(circles, position))
    //        {
    //            circles[i] = position;
    //        }
    //        else
    //        {
    //            i--;
    //        }
    //    }
    //}
}
