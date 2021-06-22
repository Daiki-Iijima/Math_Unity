using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StraightLine : MonoBehaviour
{
    [SerializeField] private Transform baseP1Transform;
    [SerializeField] private Transform baseP2Transform;
    
    [SerializeField] private Transform targetP1Transform;
    [SerializeField] private Transform targetP2Transform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float baseSlope = SlopeBetweenPoints(baseP1Transform.position,baseP2Transform.position);
        Debug.Log("ベースの傾き:"+baseSlope);

        float baseVertical = PerpSlope(baseSlope);
        Debug.Log("ベースの垂直:"+baseVertical);

        float targetSlope = SlopeBetweenPoints(targetP1Transform.position,targetP2Transform.position);
        Debug.Log("ターゲットの傾き:"+baseSlope);

        float targetVertical = PerpSlope(targetSlope);
        Debug.Log("ターゲットの垂直:"+targetVertical);

        Debug.Log("垂直かどうか:"+CheckPerp(baseSlope,targetSlope));
    }

    //  渡された2点の線形方程式の傾きを求める
    //  マイナスの場合、原点より()
    private float SlopeBetweenPoints(Vector3 p1,Vector3 p2)
    {
        return (p2.y - p1.y) / (p2.x - p1.x);
    }

    //  渡された傾きと垂直な傾きを返す
    //  2つの直線が垂直なとき、2つの直線の傾きをかけ合わせると、その積は必ず-1になる法則を利用している
    //  今回は-1を割ることでもう一つの傾きを求めている
    private float PerpSlope(float m)
    {
        return -1 / m;
    }

    //  渡された2つの傾きが垂直かどうかを判定する
    //  2つの直線が垂直なとき、2つの直線の傾きをかけ合わせると、その積は必ず-1になる法則を利用している
    private bool CheckPerp(float m1,float m2)
    {
        if(m1*m2 == -1)
        {
            return true;
        }else{
            return false;
        }
    }
}
