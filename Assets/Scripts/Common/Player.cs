using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameUnit
{
    private Action currentAction = null;

    public Player(int lifePoint)
    {
        LifePoint = lifePoint;
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

    public override void ChooseRoom(Room room)
    {
        CurrentRoom = room;
        currentAction = () => MoveToRoom(room);
    }

    public override void MoveToRoom(Room room)
    {

    }
}
