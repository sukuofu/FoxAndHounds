using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Room : MonoBehaviour
{

    [HideInInspector]
    public RoomSymbol myRoomSymbol { get; private set; }

    private static Color defaultColor = Color.white;
    private static Color chosenColor = Color.green;

    private void Awake()
    {
        SetRoomSymbolFromName();
    }

    private void SetRoomSymbolFromName()
    {
        var myName = gameObject.name;
        if (Enum.TryParse(myName, out RoomSymbol parsedSymbol))
        {
            myRoomSymbol = parsedSymbol;
        }
    }

    public static List<RoomSymbol> GetMovableRoomsByMyRoom(RoomSymbol myRoom, GameUnit gameUnit)
    {
        return GetMovableRoomsByMyRoom(myRoom, gameUnit is Player);
    }

    /// <summary>
    /// 自分の部屋から移動可能な部屋を取得
    /// プレイヤーかどうかで、右に進めるか判断
    /// </summary>
    /// <param name="myRoom"></param>
    /// <param name="isPlayer"></param>
    /// <returns></returns>
    public static List<RoomSymbol> GetMovableRoomsByMyRoom(RoomSymbol myRoom, bool isPlayer)
    {
        var result = new List<RoomSymbol>();
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
                    result.Add(RoomSymbol.G);
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

    public void SetDefaultColor()
    {
        GetComponent<Image>().color = defaultColor;
    }

    public void SetChosenColor()
    {
        GetComponent<Image>().color = chosenColor;
    }
}
