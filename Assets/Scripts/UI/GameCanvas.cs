using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    [SerializeField]
    GameObject arrowPrefabs;

    [SerializeField]
    RectTransform yourTurnPanel;
    [SerializeField]
    RectTransform enemyTurnPanel;

    void Awake()
    {
        var player = GameObject.FindAnyObjectByType<Player>();
        Action action = (() => player.MoveToRoom(Room.RoomSymbol.B));
        arrowPrefabs.GetComponent<Button>().onClick.AddListener(() => Debug.Log("???"));
    }

    public void ShowDialog()
    {

    }

    public void GenerateArrowFrom3D(Vector3 position)
    {

    }

    public IEnumerator ShowYourTurn()
    {
        yourTurnPanel.transform.gameObject.SetActive(true);
        yield return null;
    }

    public IEnumerator ShowEnemyTurn()
    {
        enemyTurnPanel.transform.gameObject.SetActive(true);
        yield return null;
    }

}
