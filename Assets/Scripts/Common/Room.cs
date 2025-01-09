using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    public List<Room> MovableRooms = new List<Room>();

    private GameCanvas _gameCanvas;

    private GameCanvas gameCanvas
    {
        get
        {
            if (!_gameCanvas) _gameCanvas = GameObject.FindAnyObjectByType<GameCanvas>();
            return _gameCanvas;
        }
    }

    public bool HasPlayer
    {
        get
        {
            var result = false;
            foreach (var gameUnit in CurrentGameUnits)
            {
                if (gameUnit is Player)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }

    [HideInInspector]
    public List<GameUnit> CurrentGameUnits = new List<GameUnit>();

    public void DisplayArrowsToRoom()
    {

    }

    public Room GetEntered(GameUnit gameUnit)
    {
        CurrentGameUnits.Add(gameUnit);
        return this;
    }

    public void GetLeft(GameUnit gameUnit)
    {
        CurrentGameUnits.Remove(gameUnit);
    }
}
