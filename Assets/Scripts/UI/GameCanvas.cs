using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField]
    GameObject arrowPrefabs;

    [SerializeField]
    RectTransform yourTurnPanel;
    [SerializeField]
    RectTransform enemyTurnPanel;

    public void ShowDialog()
    {

    }

    public void GenerateArrowFrom3D(Vector3 position)
    {

    }

    public IEnumerator ShowYourTurn()
    {
        yourTurnPanel.transform.parent.gameObject.SetActive(false);
        yourTurnPanel.transform.parent.gameObject.SetActive(true);
        yield return null;
    }

    public IEnumerator ShowEnemyTurn()
    {
        yourTurnPanel.transform.parent.gameObject.SetActive(false);
        enemyTurnPanel.transform.parent.gameObject.SetActive(true);
        yield return null;
    }
}
