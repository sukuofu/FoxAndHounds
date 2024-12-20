using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Player CurrentPlayer { get; private set; }

    public List<Enemy> CurrentEnemies { get; private set; }

    public bool HasEnemy => CurrentEnemies != null && 0 < CurrentEnemies.Count;

    public int EnemyActionCount { get; private set; } = 1;

    private Coroutine currentGameFlow;

    public int CurrentStageIndex { get; set; } = 0;

    void Start()
    {
        currentGameFlow = StartCoroutine(GameFlow());
    }

    IEnumerator GameFlow()
    {
        yield return LoadStage();
        yield return GenetatePlayer();
        yield return GenetateEnemies();

        while (!CurrentPlayer.IsDead)
        {
            yield return CurrentPlayer.DoAction();
            if (HasEnemy)
            {
                yield return GetRandomEnemy().DoAction();
            }

            yield return null;
        }
        GameOver();
    }

    IEnumerator LoadStage()
    {
        GameObject prefabFromResources = Resources.Load("Prefabs/Prefab1") as GameObject;
        yield return null;
    }

    IEnumerator GenetatePlayer()
    {
        CurrentPlayer = FindAnyObjectByType<Player>();
        yield return null;
    }

    IEnumerator GenetateEnemies()
    {
        // TODO: 敵の生成、変数に保持

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

    public void GameOver()
    {
        StopCoroutine(currentGameFlow);

    }

    public void QuitGame()
    {
        StopCoroutine(currentGameFlow);

    }
}
