using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameUnit
{
    public override IEnumerator DoAction()
    {
        yield return new WaitForEndOfFrame();
    }

    public override void ChooseRoom(RoomSymbol room)
    {

    }

    public override void MoveToRoom(RoomSymbol room)
    {

    }
}
