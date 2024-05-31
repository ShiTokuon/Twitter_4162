using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // UnityEngine.SceneManagemntの機能を使用

public class ChangeTitle : MonoBehaviour
{
    // 中に記述された処理が一定間隔で繰り返し実行される
    void Update()
    {
        // もし入力したキーがSpaceキーならば、中の処理を実行する
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Titleに切り替える
            SceneManager.LoadScene("TitleScene");
        }
    }
}