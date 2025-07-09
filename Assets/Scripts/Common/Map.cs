using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    [HideInInspector]
    public List<Room> CurrentRooms { get; private set; }

    [SerializeField]
    public Room.RoomSymbol StartRoomSymbol;

    [SerializeField]
    public Room.RoomSymbol EndRoomSymbol;

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
