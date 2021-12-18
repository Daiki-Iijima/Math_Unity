using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 直線移動させるロジックサンプル
/// </summary>
public class MoveStraightLine : MonoBehaviour
{
    [SerializeField] private Transform _startTransform;     //  出発位置Transform
    [SerializeField] private Transform _endTransform;       //  到着位置Transform
    [SerializeField] private Transform _moveObjTransform;   //  移動させるオブジェクト

    //  2点を結んだ直線の傾き
    private float slope = 0;

    //  2点を結んだ直線の切片
    private float intercept = 0;

    //  使用する座標
    private Vector2 _startPos;
    private Vector2 _endPos;

    //  最新のX座標
    private float latestX = 0;

    void Start()
    {
        //  座標のみを取り出す
        _startPos = _startTransform.position;
        _endPos = _endTransform.position;

        //  傾きを求める
        slope = GetSlope(_startPos,_endPos);

        //  切片を求める
        intercept = GetIntercept(_startPos, slope);

        //  最初の位置
        latestX = _startPos.x;

        //  移動させるオブジェクトを出発位置に移動
        _moveObjTransform.position = _startPos;
    }

    void Update()
    {
        //  ゴールチェック
        if (CheckGoal(_startPos, _endPos, _moveObjTransform.position))
        {
            //  毎フレーム1mで移動させる
            MoveConstantSpeed(1f);

            //  3秒で移動させる
            //MoveTime(3);
        }else{
            Debug.Log("ゴール");
        }
    }

    /// <summary>
    /// 指定した時間で移動させる
    /// </summary>
    /// <param name="time">何秒で到着させるか</param>
    private void MoveTime(float time)
    {
        Vector2 setPos = GetLinePoint(_startTransform.position, slope, latestX);

        _moveObjTransform.position = setPos;

        Vector3 p1 = _startTransform.position;
        Vector3 p2 = _endTransform.position;

        latestX += (p2.x - p1.x) * Time.deltaTime / time;      //  指定した時間で移動
    }

    /// <summary>
    /// 一定速度で移動させる
    /// </summary>
    /// <param name="speed">1秒間に移動する距離</param>
    private void MoveConstantSpeed(float speed)
    {
        //  傾き(tanθ)から角度を求める
        var radian = Mathf.Atan(slope);

        //  象限によって掛ける係数
        int isMinus = 1;

        //  象限のチェック
        OrthantCheck.Orthant orthan = OrthantCheck.Check(_startPos, _endPos);

        //  第3、第4象限(左半分)の場合は動く向きを反転
        switch (orthan)
        {
            case OrthantCheck.Orthant.Null:
                {
                    Debug.Log("象限:" + "重なっている");
                    return;
                }
            case OrthantCheck.Orthant.Two:
                {
                    Debug.Log("象限:" + "2");
                    isMinus = -1;
                }
                break;
            case OrthantCheck.Orthant.Three:
                {
                    Debug.Log("象限:" + "3");
                    isMinus = -1;
                }
                break;
        }

        //  角度から単位ベクトルを出す
        var nomalizeVecter = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));

        //  移動させる
        _moveObjTransform.position += new Vector3(nomalizeVecter.x, nomalizeVecter.y, 0) * Time.deltaTime * speed * isMinus;
    }

    /// <summary>
    /// ゴールについたかチェックする
    /// </summary>
    /// <param name="start">開始点</param>
    /// <param name="goal">目標点</param>
    /// <param name="target">移動している点</param>
    /// <returns>ゴールしているかどうか</returns>
    private bool CheckGoal(Vector2 start, Vector2 goal, Vector2 target)
    {
        //  どの象限にいるかチェック
        OrthantCheck.Orthant orthan = OrthantCheck.Check(_startPos, _endPos);

        switch (orthan)
        {
            case OrthantCheck.Orthant.Null:
                {
                    return true;
                }
            case OrthantCheck.Orthant.One:
                {
                    if (_endPos.x >= target.x)
                    {
                        return true;
                    }
                }
                break;
            case OrthantCheck.Orthant.Two:
                {
                    if (_endPos.x <= target.x)
                    {
                        return true;
                    }
                }
                break;
            case OrthantCheck.Orthant.Three:
                {
                    if (_endPos.x <= target.x)
                    {
                        return true;
                    }
                }
                break;
            case OrthantCheck.Orthant.Four:
                {
                    if (_endPos.x >= target.x)
                    {
                        return true;
                    }
                }
                break;
        }

        return false;
    }

    /// <summary>
    /// xの値を規定値として入れる
    /// </summary>
    /// <param name="p1">原点の座標</param>
    /// <param name="m">傾き</param>
    /// <param name="x">移動させるx座標</param>
    /// <returns>移動座標</returns>
    private Vector2 GetLinePoint(Vector2 p1, float m, float x)
    {
        //  (y1 - y2) = m(x1 - x2)の公式を使って直線の式を求める
        //  上の式を変形して、「y1 = (m * x1) - (m * x2) + y2」として、y1の数値を求める
        //  x1の数値は、適当でいい
        Vector2 retVec = new Vector2(x, 0);

        float y = (m * x) - (m * p1.x) + p1.y;

        retVec.y = y;

        return retVec;
    }

    /// <summary>
    /// 傾きを求める
    /// </summary>
    /// <param name="start">1点目</param>
    /// <param name="end">2点目</param>
    /// <returns>1点目2点目から導き出される傾き</returns>
    private float GetSlope(Vector2 start,Vector2 end){
        return (end.y - start.y) / (end.x - start.x);
    }

    /// <summary>
    /// 切片を求める
    /// </summary>
    /// <returns>切片</returns>
    private float GetIntercept(Vector2 pos, float m)
    {
        return pos.y - (pos.x * m);
    }
}
