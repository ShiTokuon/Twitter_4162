using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeExplanation : MonoBehaviour
{
    void Update()
    {
        // Space�L�[�����ƃV�[���ڍs
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �Q�[�������ɐ؂�ւ���
            SceneManager.LoadScene("ExplanationScene");
        }
    }
}
