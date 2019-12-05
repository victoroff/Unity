using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRectangle : MonoBehaviour
{
    public Transform camera;
    public Transform rectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rectPrefab.localScale = new Vector3(30,30,0);
     
     //   rectPrefab.localPosition = new Vector3(camera.localPosition.x,camera.localPosition.y,0);
        Instantiate(rectPrefab,camera.position,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
