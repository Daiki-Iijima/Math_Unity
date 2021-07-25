using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour
{
    [SerializeField] private Transform line1p1;
    [SerializeField] private Transform line1p2;

    [SerializeField] private Transform line2p1;
    [SerializeField] private Transform line2p2;

    [SerializeField] private GameObject IntersectionPoint;

    struct Line
    {
        //  傾き
        public float slope;
        //  切片
        public float intercept;
        //  線上の点(どこでもいいのでp1を入れることにする)
        public Vector2 point;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float line1slope = (line1p2.position.y - line1p1.position.y) / (line1p2.position.x - line1p1.position.x);
        float line1Intercept = line1p1.position.y - (line1slope * line1p1.position.x);
        Line line1 = new Line()
        {
            slope = line1slope,
            intercept = line1Intercept,
            point = (Vector2)line1p1.position
        };

        float line2slope = (line2p2.position.y - line2p1.position.y) / (line2p2.position.x - line2p1.position.x);
        float line2Intercept = line2p1.position.y - (line2slope * line2p1.position.x);
        Line line2 = new Line()
        {
            slope = line2slope,
            intercept = line2Intercept,
            point = (Vector2)line2p1.position
        };

        Vector2 intersectionPoint = lineIntersect(line1, line2);
        IntersectionPoint.transform.position = intersectionPoint;
    }

    /// <summary>
    /// 2本の直線の交差する点(座標)を計算する
    /// </summary>
    /// <param name="line1">第1の直線</param>
    /// <param name="line2">第2の直線</param>
    /// <returns>2本の直線が交差する座標</returns>
    private Vector2 lineIntersect(Line line1,Line line2)
    {
        float x = ((line1.slope * line1.point.x) - (line2.slope * line2.point.x) + line2.point.y - line1.point.y) / (line1.slope - line2.slope);

        float y = line1.slope * x + line1.intercept;

        return new Vector2(x,y);
    }
}
