using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraightLine : MonoBehaviour
{
    [SerializeField] private Transform baseP1Transform;
    [SerializeField] private Transform baseP2Transform;

    //  2点を結んだ直線の傾き
    private float slope = 0;

    //  2点を結んだ直線の切片
    private float intercept = 0;

    //  移動させたい位置
    private Vector2 targetPos;

    //  基本の2点の中間地点
    private Vector2 centerPos;
    private float latestX = 0;
    private float offsetY = 0;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 p1 = baseP1Transform.position;
        Vector3 p2 = baseP2Transform.position;

        slope = (p2.y-p1.y) / (p2.x-p1.x);
        intercept = GetIntercept(p1,slope);

        targetPos = p2;
        latestX = p1.x;
        offsetY = p2.y - p1.y;

        centerPos = (p1 + p2) / 2;

        //  0.1f間隔でキューブを配置していく
        for(float i = latestX;i<baseP2Transform.position.x;i+=0.1f)
        {
            //Instantiate(baseP1Transform.gameObject,GetLinePoint(baseP1Transform.position,slope,i),Quaternion.identity);
            Instantiate(baseP1Transform.gameObject,GetLinePoint2(slope,intercept,i),Quaternion.identity);
            Instantiate(baseP1Transform.gameObject,GetLinePoint2(slope,intercept + 5,i),Quaternion.identity);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        //  移動させる
        // if(targetPos.x >= latestX)
        // {
        //     Vector2 setPos = GetLinePoint(baseP1Transform.position,slope,latestX);
            
        //     baseP2Transform.position = setPos;

        //     latestX+= 0.01f;
        // }
    }

    private Vector2 GetLinePoint(Vector2 p1,float m,float x)
    {
        //  (y1 - y2) = m(x1 - x2)の公式を使って直線の式を求める
        //  上の式を変形して、「y1 = (m * x1) - (m * x2) + y2」として、y1の数値を求める
        //  x1の数値は、適当でいい
        Vector2 retVec = new Vector2(x,0);

        float y =  (m * x) - (m * p1.x) + p1.y;

        retVec.y = y;

        return retVec;
    }

    private Vector2 GetLinePoint2(float m,float n,float x)
    {
        //  y = xm + n の公式を使う
        Vector2 retVec = new Vector2(x,0);

        float y =  (x * m) + n;

        retVec.y = y;

        return retVec;
    }

    //  切片を求める
    private float GetIntercept(Vector2 pos,float m)
    {
        return pos.y - (pos.x * m);
    }

    //  与えられた直線(かたむき)に垂直ないちを計算する
    private Vector2 GetVerticalLinePoint(Vector2 p1,float m,float x)
    {
        //  (y1 - y2) = m(x1 - x1)の公式を使って直線の式を求める
        //  上の式を変形して、「y1 = (m * x1) - (m * x2) + y2」として、y1の数値を求める
        //  x1の数値は、適当でいい
        Vector2 retVec = new Vector2(x,0);

        float y =  (-m * x) - (-m*p1.x) + p1.y;

        retVec.y = y;

        return retVec;
    }
}
