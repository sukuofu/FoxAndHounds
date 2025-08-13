using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UtageExtensions;

public class GameCanvas : MonoBehaviour
{
    [SerializeField]
    GameObject arrowPrefabs;

    [SerializeField]
    RectTransform yourTurnPanel;
    [SerializeField]
    RectTransform enemyTurnPanel;
    [SerializeField]
    public Map currentMap;
    [SerializeField]
    RectTransform moveArrowsPanel;
    public Player player { private get; set; }

    public void ShowDialog()
    {

    }

    /// <summary>
    /// 部屋を移動するときの演出
    /// </summary>
    public void RoomChange()
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

    public void GenerateMoveArrows(RoomSymbol roomSymbol)
    {
        var angles = currentMap.GetMoveAnglesToMovableRooms(roomSymbol);

        // 画面中央を取得（Canvas直下にいることを想定）
        RectTransform canvasRect = GetComponent<Canvas>().GetComponent<RectTransform>();
        Vector2 center = canvasRect.rect.center;

        moveArrowsPanel.DestroyChildren();

        // 矢印を配置する半径（UIサイズに応じて調整）
        float radius = 200f;

        foreach (KeyValuePair<string, float> angle in angles)
        {
            // ラジアンに変換（Unityの座標系は時計回り、0°が右）
            float rad = angle.Value * Mathf.Deg2Rad;

            // 座標計算（中心から半径分オフセット）
            Vector2 offset = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * radius;
            Vector2 position = center + offset;

            // 矢印生成と配置
            GameObject arrow = Instantiate(arrowPrefabs, moveArrowsPanel);
            RectTransform arrowRect = arrow.GetComponent<RectTransform>();
            arrowRect.anchoredPosition = position;

            // 回転（Z軸まわりにangle度回転）
            arrowRect.localRotation = Quaternion.Euler(0, 0, angle.Value);

            arrowRect.gameObject.SetActive(true);

            if (Enum.TryParse(angle.Key, out RoomSymbol parsedSymbol))
            {
                Action action = () => player.MoveToRoom(parsedSymbol, currentMap);
                arrowRect.GetComponent<Button>().onClick.AddListener(() => player.SetCurrentAction(action));
            }
        }
    }
}
