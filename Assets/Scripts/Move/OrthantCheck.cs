using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OrthantCheck
{
    public enum Orthant
    {
        Null,
        One,
        Two,
        Three,
        Four,
    }

    /// <summary>
    /// 第2引数に指定された値が、第1引数から見てどの象限にいるかをチェックして返す
    /// </summary>
    /// <param name="baseVec">基準</param>
    /// <param name="targetVec">対象</param>
    /// <returns>targetVecのいる象限,Nullの場合重なっている</returns>
    public static Orthant Check(Vector3 baseVec,Vector3 targetVec)
    {
        Orthant retOrthant = Orthant.Null;

        //  重なっている
        if(baseVec == targetVec){
            return Orthant.Null;
        }
        
        if(baseVec.x <= targetVec.x && baseVec.y <= targetVec.y){
            retOrthant = Orthant.One;
        }else if(baseVec.x >= targetVec.x && baseVec.y <= targetVec.y){
            retOrthant = Orthant.Two;
        }else if(baseVec.x >= targetVec.x && baseVec.y >= targetVec.y){
            retOrthant = Orthant.Three;
        }else if(baseVec.x <= targetVec.x && baseVec.y >= targetVec.y){
            retOrthant = Orthant.Four;
        }

        return retOrthant;
    }
}
