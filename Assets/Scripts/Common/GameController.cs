using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    public Player CurrentPlayer { get; private set; }

    [HideInInspector]
    public GameCanvas CurrentGameCanvas { get; private set; }

    [HideInInspector]
    public List<Enemy> CurrentEnemies { get; private set; }

    [HideInInspector]
    public int CurrentStageIndex { get; set; } = 0;

    public bool HasEnemy => CurrentEnemies != null && 0 < CurrentEnemies.Count;

    public int EnemyActionCount { get; private set; } = 1;

    private int turnCount { get; set; } = 0;

    private Coroutine currentGameFlow;

    void Start()
    {
        currentGameFlow = StartCoroutine(GameFlow());
    }

    IEnumerator GameFlow()
    {
        yield return GenetatePlayer();
        yield return GenetateGameCanvas();
        yield return LoadStage();
        //yield return GenetateEnemies();
        while (!CurrentPlayer.IsDead)
        {
            yield return CurrentGameCanvas.ShowYourTurn();
            CurrentGameCanvas.GenerateMoveArrows(CurrentPlayer.CurrentRoomSymbol);
            var preRoom = CurrentPlayer.CurrentRoomSymbol;
            yield return CurrentPlayer.DoAction();
            // 部屋移動していたら
            if (preRoom != CurrentPlayer.CurrentRoomSymbol)
            {
                CurrentGameCanvas.RoomChange();
            }

            if (HasEnemy)
            {
                yield return CurrentGameCanvas.ShowEnemyTurn();
                yield return GetRandomEnemy().DoAction();
            }
            turnCount += 1;
            yield return null;
        }
        GameOver();
    }

    IEnumerator LoadStage()
    {
        // var rooms = Resources.Load("Prefabs/Rooms_Level_1") as GameObject;
        // Instantiate(rooms, new Vector3(0, 0, 0), Quaternion.identity);

        // var children = rooms.GetComponentsInChildren<Room>();

        // if (children != null)
        // {
        //     foreach (var child in children)
        //     {
        //         if (child.IsStart)
        //         {
        //             CurrentPlayer.ForceSetRoom(child);
        //             break;
        //         }
        //     }
        // }

        yield return null;
    }

    IEnumerator GenetatePlayer()
    {
        var playerInstance = Util.InstantiateObjectByName("Player");
        CurrentPlayer = playerInstance.GetComponent<Player>();
        CurrentPlayer.Initialize(5, RoomSymbol.D); // デバッグ用
        yield return null;
    }

    IEnumerator GenetateGameCanvas()
    {
        var gameCanvasInsetance = Util.InstantiateObjectByName("GameCanvas");
        CurrentGameCanvas = gameCanvasInsetance.GetComponent<GameCanvas>();
        CurrentGameCanvas.player = CurrentPlayer;
        yield return null;
    }

    IEnumerator GenetateEnemies()
    {
        var enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        CurrentEnemies = enemies != null ? enemies.ToList() : null;

        yield return null;
    }

    Enemy GetRandomEnemy()
    {
        if (HasEnemy)
        {
            return CurrentEnemies[UnityEngine.Random.Range(0, CurrentEnemies.Count)];
        }
        return null;
    }

    public void GameOver()
    {
        StopCoroutine(currentGameFlow);
    }

    public void QuitGame()
    {
        StopCoroutine(currentGameFlow);
    }
}
