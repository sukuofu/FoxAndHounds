using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameUnit : MonoBehaviour
{
    public int LifePoint { get; protected set; }

    public bool IsDead => LifePoint <= 0;

    [HideInInspector]
    public RoomSymbol CurrentRoomSymbol;

    public virtual void GetDamaged(int damage)
    {
        LifePoint -= damage;
    }

    public abstract IEnumerator DoAction();

    public abstract void ChooseRoom(RoomSymbol roomSymbol);

    public abstract void MoveToRoom(RoomSymbol roomSymbol);
}
