using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinCosTan : MonoBehaviour
{
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;

    [SerializeField] private GameObject point;

    // Start is called before the first frame update
    void Start()
    {
        float tx = p2.transform.position.x - p1.transform.position.x;
        float ty = p2.transform.position.y - p1.transform.position.y;
        float dis = Mathf.Sqrt(Mathf.Pow(tx, 2) + Mathf.Pow(ty, 2));

        //float rad = Mathf.Asin(ty / dis);
        //float deg = rad * 57.29577951f;
        //Debug.Log(deg);

        for (int i = 0; i <= 360; i++)
        {
            float x = dis * Mathf.Cos(i * 0.017453293f);
            float y = dis * Mathf.Sin(i * 0.017453293f);
            Instantiate(point, new Vector2(x, y), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float tx = p2.transform.position.x - p1.transform.position.x;
        float ty = p2.transform.position.y - p1.transform.position.y;
        float dis = Mathf.Sqrt(Mathf.Pow(tx, 2) + Mathf.Pow(ty, 2));

        float rad = Mathf.Atan(ty / tx);
        float deg = rad * 57.29577951f;

        if (p2.position.y > p1.position.y && p2.position.x > p1.position.x)
        {
            Debug.Log("第1象限");
        }
        else if ((p2.position.y < p1.position.y && p2.position.x < p1.position.x) || (p2.position.y > p1.position.y && p2.position.x < p1.position.x))
        {
            deg += 180f;
            Debug.Log("第2or第3象限");
        }
        else
        {
            deg += 360f;
            Debug.Log("第4象限");
        }

        Debug.Log(deg);
    }
}
