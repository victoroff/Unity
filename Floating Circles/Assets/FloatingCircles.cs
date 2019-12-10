//using System.Collections.Generic;
//using UnityEngine;

//public class FloatingCircles : MonoBehaviour
//{
//    //rectangle properties
//    //public int RectangleWidth;
//    //public int RectangleHeight;
//    //private Sprite rectSprite;
//    //private SpriteRenderer sr;
//    //public Color color = Color.blue;
//    public Transform Rectangle;


//    //circle properties
//    public int MaxCircles;
//    public float radius;
//    public Transform circlePrefab;
//    //void Awake()
//    //{
//    //    sr = GetComponent<SpriteRenderer>();
//    //    sr.color = color;

//    //    // transform.position = new Vector3(0f, 0f, 0.0f);
//    //}

//    // Start is called before the first frame update
//    void Start()
//    {
//        //arr
//        //var circles = new Vector2[maxCircles];
//        //CreateCircles(circles);

//        //list - not working fast, can't check raiduses properly
//        //var circles = new List<Vector2>();
//        //GenerateCircles(circles);

//        //Create Rectangle
//       // CreateRectangle(RectangleWidth, RectangleHeight);

//        //with dict
//        var circles = new Dictionary<float, List<float>>();
//        GenerateCircles(circles);
//     //   Debug.Log(rectSprite.rect.x + "/" + rectSprite.rect.y);
//        //foreach (var circle in circles)
//        //{
//        //    Debug.Log(circle.Value);
//        //}
//    }



//    void Update()
//    {

//    }
//    //generate circles using List
//    //private void GenerateCircles(List<Vector2> circles)
//    //{
//    //    for (int i = 0; i < maxCircles; i++)
//    //    {
//    //        var pos = new Vector2(Random.Range(radius, maxCircles), Random.Range(radius, maxCircles));

//    //        if (!circles.Contains(pos))//how to check radius?
//    //        {
//    //            circles.Add(pos);
//    //        }
//    //        else
//    //        {
//    //            i--;
//    //        }
//    //    }
//    //}
//    //private void CreateRectangle(int rectangleWidth, int rectangleHeight)
//    //{
//    //    Texture2D tex = new Texture2D(rectangleWidth, rectangleHeight);

//    //    var rect = new Rect(0.0f, 0.0f, tex.width, tex.height);
//    //    //var pivot = new Vector2(rect.x, rect.y);

//    //    rectSprite = Sprite.Create(tex, rect, new Vector2(0, 0));
//    //    sr.sprite = rectSprite;

//    //}

//    private void GenerateCircles(Dictionary<float, List<float>> circles)
//    {
//        circlePrefab.localScale = new Vector3(radius * 2, radius * 2, 0);

//        for (int i = 0; i < MaxCircles; i++)
//        {
//            var position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(Rectangle.position.x + radius, Rectangle.localScale.x - radius),
//                Random.Range(Rectangle.position.y + radius, Rectangle.localScale.y - radius),1));
//            //   Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(Rectangle.position.x + radius, Screen.width), Random.Range(Rectangle.position.x - radius, Screen.height), 1));
//            //var position = new Vector2(Random.Range(Rectangle.position.x + radius, Rectangle.localScale.x - radius), 
//            //    Random.Range(Rectangle.position.y + radius, Rectangle.localScale.y - radius));

//            //random coordinates
//            float rndX = Random.Range(Rectangle.position.x + radius, Rectangle.localScale.x - radius);
//            float rndY = Random.Range(Rectangle.position.y + radius, Rectangle.localScale.y - radius);

//            if (SafeToSpawn(circles, rndX,rndY))
//            {
//                if (!circles.ContainsKey(position.x))
//                {
//                    circles.Add(rndX, new List<float>());
//                }
//                circles[rndX].Add(rndY);

//                Instantiate(circlePrefab, position,Quaternion.identity);
//            }
//            else
//            {
//                i--;
//            }
//            //PopulateCirclesOnScreen();
//        }
//    }

//    private bool SafeToSpawn(Dictionary<float, List<float>> circles, float rndX,float rndY)
//    {
//        if (circles.ContainsKey(rndX) && circles[rndX].Contains(rndY))
//        {
//            return false;
//        }

//        if (CircleColliding(circles,rndX,rndY))
//        {
//            return false;
//        }

//        return true;
//    }

//    private bool CircleColliding(Dictionary<float, List<float>> circles, float rndX,float rndY)
//    {
//        //we need to check around the circle position
//        //(x-r;x+r) and (y-r;y+r)
//        int xMostLeft = (int)(rndX - radius);
//        int xMostRight = (int)(rndX + radius);
//        var yPosition = rndY - radius;


//        for (int x = xMostLeft; x < xMostRight; x++)
//        {
//            if (!circles.ContainsKey(x))
//            {
//                continue;
//            }
//            //if one of the points does not have circle we don't need to check it
//            if (circles.ContainsKey(x) && circles[rndX].Contains(rndY))
//            {
//                return true;
//            }

//            if (Vector2.Distance(new Vector2(x, yPosition), new Vector2(rndX,rndY)) < radius * 2)
//            {

//                return true;
//            }
//            yPosition++;
//        }
//        return false;
//    }

//    //public bool CirclesColliding(Vector2 pos1, Vector2 pos2)
//    //{
//    //    //to do how to check position if collide
//    //    // how to check circles without radius

//    //    if (pos1.x == pos2.x && Vector2.Distance(pos1,pos2) < radius * 2)
//    //    {
//    //        return true;
//    //    }
//    //    return false;
//    //}
//    //public bool SafeToInsert(Vector2[] circles, Vector2 position)
//    //{

//    //    for (int i = 0; i < circles.Length; i++)
//    //    {
//    //        if (CirclesColliding(circles[i], position))
//    //        {
//    //            return false;
//    //        }
//    //    }
//    //    return true;
//    //}
//    //public void CreateCircles(Vector2[] circles)
//    //{
//    //    for (int i = 0; i < circles.Length; i++)
//    //    {
//    //        var position = new Vector2(Random.Range(0, 1000), Random.Range(0, 1000));
//    //        if (SafeToInsert(circles, position))
//    //        {
//    //            circles[i] = position;
//    //        }
//    //        else
//    //        {
//    //            i--;
//    //        }
//    //    }
//    //}
//}

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


            float rndX = Random.Range(Rectangle.transform.position.x + radius, Rectangle.transform.position.x + radius + Rectangle.transform.localScale.x - radius);
            float rndY = Random.Range(Rectangle.transform.position.y + radius, Rectangle.transform.position.y + radius + Rectangle.transform.localScale.y - radius);

            if (SafeToSpawn(circles, rndX, rndY))
            {
                if (!circles.ContainsKey(rndX))
                {
                    circles.Add(rndX, new List<float>());
                }
                circles[rndX].Add(rndY);

                // var circlePos = Camera.main.ViewportToWorldPoint(new Vector3(position.x,position.y, 1));
                var position = new Vector3(rndX, rndY);
                Debug.Log(position);
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
        int xMostLeft = (int)(x - radius);
        int xMostRight = (int)(x + radius);
        var yPosition = y - radius;

        var b = circles.Where(c => c.Key > -12 && c.Key < -3);
        Debug.Log(b);

        for (int i = xMostLeft; i < xMostRight; i++)
        {

            //if one of the points does not have circle we don't need to check it
            if (!circles.ContainsKey(i))
            {
                continue;
            }
            else if (circles[x].Contains(y))
            {
                return true;
            }


            if (Vector2.Distance(new Vector2(i, yPosition), new Vector2(x, y)) < radius * 2)
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

