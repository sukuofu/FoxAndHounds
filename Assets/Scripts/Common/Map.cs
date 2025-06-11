using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    [HideInInspector]
    public List<Room> CurrentRooms { get; private set; }

    public Room.RoomSymbol StartRoomSymbol { get; set; }

    public Room.RoomSymbol EndRoomSymbol { get; set; }

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
}
