using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EXPparticle : MonoBehaviour
{
    Vector2 DestinationPos;
    Vector2 currentPos;
    Vector3 localAngle;
    Transform myTransform;
    // Start is called before the first frame update
    void Start()
    {
        float rndPosX = Random.Range(-2.6f, 2.61f);//��ʂ̉��̒���
        float rndPosY = Random.Range(-4.5f, 4.51f);//��ʂ̏c�̒���
        currentPos.x = rndPosX;//�����_���l��������
        currentPos.y = 6f;//Y����\���͈͂�����ɐݒ肵�Ă���
        transform.position = currentPos;//���݈ʒu��ς���
        DestinationPos = transform.position;//�ړI�l��X������
        DestinationPos.y = rndPosY;//�ړI�l��Y������
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, DestinationPos, 4 * Time.deltaTime);
        currentPos = transform.position;
        if (currentPos.y == DestinationPos.y)
        {
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ExpManeger.instance.ExpBarDraw();
            Destroy(this.gameObject);
        }
    }
}