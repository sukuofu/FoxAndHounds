using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugController : MonoBehaviour
{

    public void OnUnloadScene()
    {
        StartCoroutine(CoUnload());
    }

    IEnumerator CoUnload()
    {
        //SceneAをアンロード
        var op = SceneManager.UnloadSceneAsync("DialogueTest");
        yield return op;

        //アンロード後の処理を書く

        //必要に応じて不使用アセットをアンロードしてメモリを解放する
        //けっこう重い処理なので、別に管理するのも手
        yield return Resources.UnloadUnusedAssets();
    }

    public void WriteLog()
    {
        Debug.Log("ログ出力");
    }
}
