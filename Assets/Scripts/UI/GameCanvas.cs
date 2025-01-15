using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField]
    GameObject arrowPrefabs;

    [SerializeField]
    Animator yourTurnPanel;
    [SerializeField]
    Animator enemyTurnPanel;

    public void ShowDialog()
    {

    }

    public void GenerateArrowFrom3D(Vector3 position)
    {

    }

    public IEnumerator ShowYourTurn()
    {
        yourTurnPanel.transform.parent.gameObject.SetActive(true);
        yield return new WaitForEndOfFrame();
        yield return new WaitUntil(() => yourTurnPanel.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
        yourTurnPanel.transform.parent.gameObject.SetActive(false);
    }

    public IEnumerator ShowEnemyTurn()
    {
        enemyTurnPanel.transform.parent.gameObject.SetActive(true);
        yield return new WaitForEndOfFrame();
        yield return new WaitUntil(() => enemyTurnPanel.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
        enemyTurnPanel.transform.parent.gameObject.SetActive(false);
    }
}
