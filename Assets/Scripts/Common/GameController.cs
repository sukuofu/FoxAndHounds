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
            var preRoom = CurrentPlayer.CurrentRoomSymbol;
            yield return CurrentPlayer.DoAction();
            // 部屋移動していたら
            if (preRoom != CurrentPlayer.CurrentRoomSymbol)
            {
                RoomChange();
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
        var player = Resources.Load("Prefabs/Player") as GameObject;
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        CurrentPlayer = player.GetComponent<Player>();
        CurrentPlayer.SetLifePoint(5);
        yield return null;
    }

    IEnumerator GenetateGameCanvas()
    {
        var gameCanvas = Resources.Load("Prefabs/GameCanvas") as GameObject;
        Instantiate(gameCanvas, new Vector3(0, 0, 0), Quaternion.identity);
        CurrentGameCanvas = gameCanvas.GetComponent<GameCanvas>();
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
            return CurrentEnemies[Random.Range(0, CurrentEnemies.Count)];
        }
        return null;
    }

    /// <summary>
    /// 部屋を移動するときの演出
    /// </summary>
    private void RoomChange()
    {

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
