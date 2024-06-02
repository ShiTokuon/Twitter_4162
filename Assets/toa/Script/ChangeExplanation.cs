using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeExplanation : MonoBehaviour
{
    void Update()
    {
        // Spaceキー押すとシーン移行
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ゲーム説明に切り替える
            SceneManager.LoadScene("ExplanationScene");
        }
    }
}
