using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameUnit : MonoBehaviour
{
    public int LifePoint { get; protected set; }

    public bool IsDead => LifePoint <= 0;

    public Room CurrentRoom;

    public virtual void GetDamaged(int damage)
    {
        LifePoint -= damage;
    }

    public abstract IEnumerator DoAction();

    public abstract void ChooseRoom(Room room);

    public abstract void MoveToRoom(Room room);

}
