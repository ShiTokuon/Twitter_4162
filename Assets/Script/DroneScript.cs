using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DroneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject RayPrefab;
    [SerializeField]
    StatusData RayStatus;
    GameObject Player;
    Vector2 PlayerPos;
    Vector2 myPos;
    GameObject[] targets;
    int DroneQuantity;
    float localdistance;
    public AudioClip sound;
    AudioSource audioSource;
    private float currentTime;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");//Player�Ƃ���Tag�����I�u�W�F�N�g��������B
        PlayerPos = Player.transform.position;
        this.transform.parent = Player.transform;//�������ꂽ���������g���v���C���[�̎q�v�f�ɂ���
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > RayStatus.SPAN)
        {
            Debug.Log("RayStatus.SPAN:" + RayStatus.SPAN);
            RayGenerate();
            currentTime = 0f;
        }
    }
    public void RayGenerate()
    {
        audioSource.PlayOneShot(sound);
        var ray = Instantiate(RayPrefab, transform.position, transform.rotation);
        ray.tag = "Drone"; // �V�����������ꂽ�h���[����Drone�^�O��t����

        // �h���[�����������ꂽ��ɁA�h���[���̐��ƈʒu���X�V
        Search();
        PositionSet();
    }

    void Search()
    {
        targets = GameObject.FindGameObjectsWithTag("Drone");//Drone�^�O�����I�u�W�F�N�g����������
        foreach (var t in targets)
        {
            DroneQuantity = targets.Length;//Drone�^�O�̃I�u�W�F�N�g�̐���ۑ�����
        }
    }
    void PositionSet()
    {//���������ڂȂ̂��ɂ���ă|�W�V���������߂�
        localdistance = 0.5f;//��l���Ƃ̋���
        myPos = Player.transform.position;
        switch (DroneQuantity)
        {
            case 1://1�ڂ̏ꍇ
                myPos.x = localdistance;
                myPos.y = localdistance;
                transform.localPosition = myPos;
                break;
            case 2://2�ڂ̏ꍇ
                myPos.x = -1 * localdistance;
                myPos.y = -1 * localdistance;
                transform.localPosition = myPos;
                break;
            case 3://3��ڂ̏ꍇ
                myPos.x = -1 * localdistance;
                myPos.y = localdistance;
                transform.localPosition = myPos;
                break;
            case 4://4�ڂ̏ꍇ
                myPos.x = localdistance;
                myPos.y = -1 * localdistance;
                transform.localPosition = myPos;
                break;
            case 5://5�ڂ̏ꍇ
                myPos.x = 0;
                myPos.y = 2f;
                transform.localPosition = myPos;
                break;
        }
    }
}