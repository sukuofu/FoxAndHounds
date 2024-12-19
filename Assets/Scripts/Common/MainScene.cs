using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainScene : MonoBehaviour
{

    public GameObject main;


    // Use this for initialization
    void Start()
    {
        //シーンが破棄されたときに呼び出されるようにする
        SceneManager.sceneUnloaded += OnSceneUnloaded;

    }

    //サブボタンが押された
    public void SubButton()
    {

        //サブシーンを呼び出しているときに非表示にするゲームオブジェクト
        //main.SetActive(false);
        //メインシーンにサブシーンを追加表示する
        SceneManager.LoadScene("DialogueTest", LoadSceneMode.Additive);
    }

    private void OnSceneUnloaded(Scene current)
    {
        //シーンが破棄されたときに呼び出される
        //今回の例では、サブシーンが破棄されたら呼び出されるようになっています
        Debug.Log("OnSceneUnloaded: " + current.name);

        //本当は、どのシーンが破棄されたのか確認してから処理した方が良いかもしれない

        //ゲームオブジェクトを表示する
        //main.SetActive(true);
    }

}