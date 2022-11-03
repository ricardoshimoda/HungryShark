using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    public Vector3 leftBottom;
    public Vector3 rightTop;

    void Start()
    {
        leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0));
        rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth,Camera.main.pixelHeight,0));
        float xScale = rightTop.x - leftBottom.x;
        float yScale = rightTop.y - leftBottom.y;
        transform.localScale =  new Vector3(xScale, yScale, 1);
    }

    void Update()
    {
        
    }
}
