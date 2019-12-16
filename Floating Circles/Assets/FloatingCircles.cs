using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class FloatingCircles : MonoBehaviour
{
    //rectangle p[roperties
    //public int RectangleWidth;
    //public int RectangleHeight;
    //private Sprite rectSprite;
    //private SpriteRenderer sr;
    //public Color color = Color.blue;
    public GameObject Rectangle;


    //circle properties
    public int MaxCircles;
    [Range(0.1f,0.5f)]
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
        var circles = new Dictionary<float, List<float>>();
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

    private void GenerateCircles(Dictionary<float, List<float>> circles)
    {
        circlePrefab.localScale = new Vector3(radius * 2, radius * 2, 0);

        //rectangle position on screen
        // var rectanglePos = Camera.main.WorldToScreenPoint(Rectangle.transform.position);
        //  Debug.Log(rectanglePos.x + ":x\\y:" + rectanglePos.y);

        for (int i = 0; i < MaxCircles; i++)
        {


            float rndX = Random.Range(Rectangle.transform.position.x + radius, Rectangle.transform.position.x  + Rectangle.transform.localScale.x - radius);
            float rndY = Random.Range(Rectangle.transform.position.y + radius, Rectangle.transform.position.y  + Rectangle.transform.localScale.y - radius);

            if (SafeToSpawn(circles, rndX, rndY))
            {
                if (!circles.ContainsKey(rndX))
                {
                    circles.Add(rndX, new List<float>());
                }
                circles[rndX].Add(rndY);

                // var circlePos = Camera.main.ViewportToWorldPoint(new Vector3(position.x,position.y, 1));
                var position = new Vector3(rndX, rndY,Rectangle.transform.position.z - 1);
           //     Debug.Log(position);
                Instantiate(circlePrefab, position, Quaternion.identity);
            }
            else
            {
                i--;
            }
            //PopulateCirclesOnScreen();
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
        //(x-r;x+r) and (y-r;y+r)
        var diameter = radius * 2;
        int xMostLeft = (int)(x - diameter);
        int xMostRight = (int)(x + diameter);
        //var yPosition = y - radius;

        var surroundingXs = circles.Where(c => c.Key > xMostLeft && c.Key < xMostRight).Select(mc => mc.Key).ToList();

        if (surroundingXs.Count == 0)
        {
            
            return false;
        }

        foreach (float surroundingX in surroundingXs)
        {
            foreach (float surroundingY in circles[surroundingX])
            {
                Debug.Log(Vector2.Distance(new Vector2(x, y), new Vector2(surroundingX, surroundingY)));
                //if(Mathf.Sqrt(Mathf.Pow(surroundingX - x,2) + Mathf.Pow(surroundingY - y,2)) < diameter)
                if (Vector2.Distance(new Vector2(x, y), new Vector2(surroundingX, surroundingY)) < diameter)
                {

                    return true;
                }
            }
        }
        

        //for (int i = xMostLeft; i < xMostRight; i++)
        //{

        //    //if one of the points does not have circle we don't need to check it
        //    if (!circles.ContainsKey(i))
        //    {
        //        continue;
        //    }
        //    else if (circles[x].Contains(y))
        //    {
        //        return true;
        //    }


        //    if (Vector2.Distance(new Vector2(i, yPosition), new Vector2(x, y)) < radius * 2)
        //    {

        //        return true;
        //    }
        //    yPosition++;
        //}
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

