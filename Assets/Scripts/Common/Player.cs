using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameUnit
{
    private Action currentAction = null;

    public void SetCurrentAction(Action action)
    {
        currentAction = action;
    }

    public void Initialize(int lifePoint, Room.RoomSymbol roomSymbol)
    {
        LifePoint = lifePoint;
        CurrentRoomSymbol = roomSymbol;
    }

    public override IEnumerator DoAction()
    {
        while (currentAction == null)
        {
            // 部屋移動orアイテム使用
            yield return new WaitForEndOfFrame();
        }
        currentAction.Invoke();
        currentAction = null;
    }

    public void SetLifePoint(int lifePoint)
    {
        LifePoint = lifePoint;
    }

    public override void ChooseRoom(Room.RoomSymbol roomSymbol)
    {
        CurrentRoomSymbol = roomSymbol;
        currentAction = () => MoveToRoom(roomSymbol);
    }

    public override void MoveToRoom(Room.RoomSymbol roomSymbol)
    {
        CurrentRoomSymbol = roomSymbol;
    }
}
