using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRectangle : MonoBehaviour
{
    //rectangle p[roperties
    //public int RectangleWidth;
    //public int RectangleHeight;
    //public Sprite rectSprite;
    ////private SpriteRenderer sr;
    //public Color color = Color.blue;
    ////public Transform camera;
    ////public Transform rectPrefab;

    ////screen
    //private Vector2 screenBounds;

    //void Awake()
    //{
    //    sr = GetComponent<SpriteRenderer>();
    //    sr.color = color;

    //    // transform.position = new Vector3(0f, 0f, 0.0f);
    //}

    // Start is called before the first frame update
    void Start()
    {

        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));


        ////   rectPrefab.localScale = new Vector3(30,30,0);

        //////   rectPrefab.localPosition = new Vector3(camera.localPosition.x,camera.localPosition.y,0);
        ////   Instantiate(rectPrefab,camera.position,Quaternion.identity);

        ////Create Rectangle
        // CreateRectangle(RectangleWidth, RectangleHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void CreateRectangle(int rectangleWidth, int rectangleHeight)
    //{
    //    //Texture2D tex = new Texture2D(rectangleWidth, rectangleHeight);

    //    //var rect = new Rect(screenBounds.x,screenBounds.y, tex.width, tex.height);
    //    ////var pivot = new Vector2(rect.x, rect.y);

    //    //rectSprite = Sprite.Create(tex, rect, new Vector2(0, 0),200);
    //    //sr.sprite = rectSprite;


    //    //rectSprite = Sprite.Create(tex, rect, new Vector2(0, 0), 200);
    //    //sr.sprite = rectSprite;


    //}

}
