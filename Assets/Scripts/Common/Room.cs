using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    /// <summary>
    /// 部屋の記号
    /// 参考: https://traio.hatenablog.com/entry/2020/06/11/143656
    /// </summary>
    public enum RoomSymbol
    {
        A, B, C, D, E, F, G, H, I, J, K
    }

    /// <summary>
    /// 自分の部屋から移動可能な部屋を取得
    /// </summary>
    /// <param name="myRoom"></param>
    /// <param name="gameUnit"></param>
    /// <returns></returns>
    public List<RoomSymbol> GetMovableRoomsByMyRoom(RoomSymbol myRoom, GameUnit gameUnit)
    {
        var result = new List<RoomSymbol>();
        // プレイヤーかどうかで、右に進めるか判断
        var isPlayer = gameUnit is Player;
        // Dをスタート地点、Hをゴールとする
        switch (myRoom)
        {
            case RoomSymbol.A:
                {
                    if (isPlayer)
                    {
                        result.Add(RoomSymbol.B);
                        result.Add(RoomSymbol.F);
                    }
                    result.Add(RoomSymbol.D);
                    result.Add(RoomSymbol.E);
                    break;
                }
            case RoomSymbol.B:
                {
                    if (isPlayer)
                    {
                        result.Add(RoomSymbol.C);
                    }
                    result.Add(RoomSymbol.A);
                    result.Add(RoomSymbol.F);
                    break;
                }
            case RoomSymbol.C:
                {
                    if (isPlayer)
                    {
                        result.Add(RoomSymbol.H);
                    }
                    result.Add(RoomSymbol.B);
                    result.Add(RoomSymbol.F);
                    break;
                }
            case RoomSymbol.D:
                {
                    if (isPlayer)
                    {
                        result.Add(RoomSymbol.A);
                        result.Add(RoomSymbol.E);
                        result.Add(RoomSymbol.I);
                    }
                    break;
                }
            case RoomSymbol.E:
                {
                    if (isPlayer)
                    {
                        result.Add(RoomSymbol.F);
                    }
                    result.Add(RoomSymbol.A);
                    result.Add(RoomSymbol.D);
                    result.Add(RoomSymbol.I);
                    break;
                }
            case RoomSymbol.F:
                {
                    if (isPlayer)
                    {
                        result.Add(RoomSymbol.C);
                        result.Add(RoomSymbol.G);
                        result.Add(RoomSymbol.K);
                    }
                    result.Add(RoomSymbol.A);
                    result.Add(RoomSymbol.B);
                    result.Add(RoomSymbol.E);
                    result.Add(RoomSymbol.I);
                    result.Add(RoomSymbol.J);
                    break;
                }
            case RoomSymbol.G:
                {
                    if (isPlayer)
                    {
                        result.Add(RoomSymbol.H);
                    }
                    result.Add(RoomSymbol.C);
                    result.Add(RoomSymbol.F);
                    result.Add(RoomSymbol.K);
                    break;
                }
            case RoomSymbol.H:
                {
                    result.Add(RoomSymbol.C);
                    result.Add(RoomSymbol.G);
                    result.Add(RoomSymbol.K);
                    break;
                }
            case RoomSymbol.I:
                {
                    if (isPlayer)
                    {
                        result.Add(RoomSymbol.E);
                        result.Add(RoomSymbol.J);
                    }
                    result.Add(RoomSymbol.D);
                    result.Add(RoomSymbol.F);
                    break;
                }
            case RoomSymbol.J:
                {
                    if (isPlayer)
                    {
                        result.Add(RoomSymbol.K);
                    }
                    result.Add(RoomSymbol.F);
                    result.Add(RoomSymbol.I);
                    break;
                }
            case RoomSymbol.K:
                {
                    if (isPlayer)
                    {
                        result.Add(RoomSymbol.H);
                    }
                    result.Add(RoomSymbol.F);
                    result.Add(RoomSymbol.G);
                    result.Add(RoomSymbol.J);
                    break;
                }
        }
        return result;
    }
}
