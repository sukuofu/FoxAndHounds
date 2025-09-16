using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Utage;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    public Player CurrentPlayer { get; private set; }

    [HideInInspector]
    public GameCanvas CurrentGameCanvas { get; private set; }

    [HideInInspector]
    public List<Enemy> CurrentEnemies { get; private set; } = new List<Enemy>();

    [HideInInspector]
    public int CurrentStageIndex { get; set; } = 0;

    public bool HasEnemy => CurrentEnemies != null && 0 < CurrentEnemies.Count;

    public int EnemyActionCount { get; private set; } = 1;

    private int turnCount { get; set; } = 1;

    private Coroutine currentGameFlow;

    private static System.Random random = new System.Random();

    void Start()
    {
        currentGameFlow = StartCoroutine(GameFlow());
    }

    IEnumerator GameFlow()
    {
        yield return LoadStage();
        // TODO: map固定でなく、ステージに応じたmapを生成する
        yield return GenetateGameCanvas();
        var map = CurrentGameCanvas.CurrentMap;
        yield return GenetatePlayer(map);
        CurrentGameCanvas.player = CurrentPlayer;
        yield return GenetateEnemies(map);

        while (!CurrentPlayer.IsDead)
        {
            CurrentGameCanvas.GenerateLogAngle();
            CurrentGameCanvas.SetMapRoomColor(CurrentPlayer.CurrentRoomSymbol);
            CurrentGameCanvas.SetTurnCount(turnCount.ToString());
            yield return CurrentGameCanvas.ShowYourTurn();
            CurrentGameCanvas.GenerateMoveArrows(CurrentPlayer.CurrentRoomSymbol);
            var preRoom = CurrentPlayer.CurrentRoomSymbol;
            yield return CurrentPlayer.DoAction();
            // 部屋移動していたら
            if (preRoom != CurrentPlayer.CurrentRoomSymbol)
            {
                yield return CurrentGameCanvas.RoomChange();
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

    IEnumerator GenetatePlayer(Map map)
    {
        var playerInstance = Util.InstantiateObjectByName("Player");
        CurrentPlayer = playerInstance.GetComponent<Player>();
        CurrentPlayer.Initialize(5, map.StartRoomSymbol); // デバッグ用
        yield return null;
    }

    IEnumerator GenetateGameCanvas()
    {
        var gameCanvasInsetance = Util.InstantiateObjectByName("GameCanvas");
        CurrentGameCanvas = gameCanvasInsetance.GetComponent<GameCanvas>();
        yield return null;
    }

    void GenetateEnemy(RoomSymbol roomSymbol)
    {
        var enemyInstance = Util.InstantiateObjectByName("Enemy");
        CurrentEnemies.Add(enemyInstance.GetComponent<Enemy>());
    }

    IEnumerator GenetateEnemies(Map map)
    {
        var count = map.EnemyCount;
        var enemyRoomSymbols = new List<RoomSymbol>(map.EnemyRoomSymbols);

        for (int i = 0; i < count; i++)
        {
            // ランダムなインデックスを取得
            int index = random.Next(enemyRoomSymbols.Count);

            // ランダムに選ばれた要素を取得
            var selected = enemyRoomSymbols[index];

            // リストから削除
            enemyRoomSymbols.RemoveAt(index);
            GenetateEnemy(selected);

            if (enemyRoomSymbols.Count == 0)
            {
                break;
            }
        }
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
