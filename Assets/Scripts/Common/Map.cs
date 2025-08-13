using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    [HideInInspector]
    public List<Room> CurrentRooms { get; private set; }

    [SerializeField]
    public RoomSymbol StartRoomSymbol;

    [SerializeField]
    public RoomSymbol EndRoomSymbol;

    void Awake()
    {
        GetRooms();
    }

    void GetRooms()
    {
        if (CurrentRooms == null)
        {
            CurrentRooms = FindObjectsByType<Room>(0).ToList();
        }
    }

    /// <summary>
    /// あるマップと自分の部屋記号から、角度を取得
    /// </summary>
    /// <param name="map"></param>
    /// <returns></returns>
    public Dictionary<string, float> GetMoveAnglesToMovableRooms(RoomSymbol roomSymbol)
    {
        var result = new Dictionary<string, float>();
        var myName = roomSymbol.ToString();
        var rooms = new List<GameObject>();

        var movableRooms = Room.GetMovableRoomsByMyRoom(roomSymbol, isPlayer: true);

        for (var i = 0; i < transform.GetChild(0).childCount; i++)
        {
            rooms.Add(transform.GetChild(0).GetChild(i).gameObject);
        }
        GameObject originRoom = null;
        foreach (var room in rooms)
        {
            var thisName = room.name;
            if (thisName == roomSymbol.ToString())
            {
                originRoom = room;
                break;
            }
        }
        foreach (var room in rooms)
        {
            if (room.name == originRoom.name) continue;

            foreach (var movableRoom in movableRooms)
            {
                if (room.name == movableRoom.ToString())
                {
                    result[movableRoom.ToString()] = GetAngle(originRoom.transform.position, room.transform.position);
                }
            }
        }
        return result;
    }

    private float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 dt = target - start;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;
        return degree;
    }

    public void SetRoomColorToChosen(RoomSymbol roomSymbol)
    {
        foreach (var room in CurrentRooms)
        {
            if (room.gameObject.name == roomSymbol.ToString())
            {
                room.SetChosenColor();
            }
            else
            {
                room.SetDefaultColor();
            }
        }
    }
}
