using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField] private Transform c1CenterTransform;
    [SerializeField] private Transform c1VertexTransform;

    [SerializeField] private Transform c2CenterTransform;
    [SerializeField] private Transform c2VertexTransform;


    //[SerializeField] private Transform targetTransform;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(CheckCirclePointHit(baseP1Transform.position, baseP2Transform.position, targetTransform.position));


        bool isHit = CheckCircleHit(
            c1CenterTransform.position, c1VertexTransform.position,
            c2CenterTransform.position, c2VertexTransform.position
            );

        Debug.Log(isHit);
    }
    
    /// <summary>
    /// 1点が指定した円に当たっているかを検出する
    /// </summary>
    /// <param name="center"></param>
    /// <param name="vertex"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    private bool CheckCirclePointHit(Vector2 center,Vector2 vertex ,Vector2 target)
    {
        var radius = Mathf.Sqrt(
            Mathf.Pow(vertex.x - center.x, 2) + 
            Mathf.Pow(vertex.y - center.y, 2)
            );
        
        var targetDistance = Mathf.Sqrt(
            Mathf.Pow(target.x - center.x, 2) +
            Mathf.Pow(target.y - center.y, 2)
            );
        
        if (radius >= targetDistance)
        {
            //  Hit
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 2つの円が当たっているかを検出する
    /// </summary>
    /// <returns></returns>
    private bool CheckCircleHit(Vector2 c1Center, Vector2 c1Vertex, Vector2 c2Center,Vector2 c2Vertex)
    {
        //  各円の半径を求める
        float c1Radius = Mathf.Sqrt(
            Mathf.Pow(c1Vertex.x - c1Center.x, 2) +
            Mathf.Pow(c1Vertex.y - c1Center.y, 2)
            );

        float c2Radius = Mathf.Sqrt(
            Mathf.Pow(c2Vertex.x - c2Center.x, 2) +
            Mathf.Pow(c2Vertex.y - c2Center.y, 2)
            );

        //  2つの円の中心の距離を求める
        float cDistance = Mathf.Sqrt(
            Mathf.Pow(c2Center.x - c1Center.x, 2) +
            Mathf.Pow(c2Center.y - c1Center.y, 2)
            );
        
        if (cDistance <= (c1Radius + c2Radius))
        {
            //  Hit
            return true;
        }
        else
        {
            return false;
        }
    }
}
