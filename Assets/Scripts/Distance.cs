using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    [SerializeField] private Transform baseP1Transform;
    [SerializeField] private Transform baseP2Transform;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p1 = baseP1Transform.position;
        Vector3 p2 = baseP2Transform.position;

        Debug.Log("2次元のp1p2間の距離 = " + GetDistance2((Vector2)p1, (Vector2)p2));
        Debug.Log("3次元のp1p2間の距離 = " + GetDistance3(p1, p2));
        Debug.Log("2次元のp1p2間の中心座標 = " + GetCenter2((Vector2)p1, (Vector2)p2));
        Debug.Log("3次元のp1p2間の中心座標 = " + GetCenter3(p1, p2));

    }

    /// <summary>
    /// 2次元の距離を算出する
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    private float GetDistance2(Vector2 p1, Vector2 p2)
    {
        float tx = p2.x - p1.x;
        float ty = p2.y - p1.y;

        return Mathf.Sqrt(Mathf.Pow(tx, 2) + Mathf.Pow(ty, 2));
    }

    /// <summary>
    /// 3次元の距離を算出する
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    private float GetDistance3(Vector3 p1, Vector3 p2)
    {
        float tx = p2.x - p1.x;
        float ty = p2.y - p1.y;
        float tz = p2.z - p1.z;

        return Mathf.Sqrt(Mathf.Pow(tx, 2) + Mathf.Pow(ty, 2) + Mathf.Pow(tz, 2));
    }

    /// <summary>
    /// 2次元の中心座標を算出する
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    private Vector2 GetCenter2(Vector2 p1, Vector2 p2)
    {
        float tx = (p1.x + p2.x) / 2;
        float ty = (p1.y + p2.y) / 2;

        return new Vector2(tx, ty);
    }

    /// <summary>
    /// 3次元の中心座標を算出する
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    private Vector3 GetCenter3(Vector3 p1, Vector3 p2)
    {
        float tx = (p1.x + p2.x) / 2;
        float ty = (p1.y + p2.y) / 2;
        float tz = (p1.z + p2.z) / 2;

        return new Vector3(tx, ty,tz);
    }
}
