using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBulletSpawn_W : MonoBehaviour
{
    [Header("�Ѿ� ������")]
    [SerializeField] TowerBullet bulletPrefab = null; // �Ѿ� ������

    [Header("�Ѿ� ����")]
    [SerializeField] int attack = 5; // ����ġ
    [SerializeField] float spawntime = 1.2f; // ���� �ֱ�
    [SerializeField] Transform BulletPos = null;

    float timeAfterSpawn;

    Transform target; // �߻��� ���

    void Start()
    {
        //�ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;

        target = FindObjectOfType<Monster>().transform;
    }



    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        //Debug.Log("timeAfterSpawn : " + timeAfterSpawn);

        if(timeAfterSpawn >= spawntime) 
        {
            //Debug.Log("timeAfterSpawn : " + timeAfterSpawn);

            // ������ �ð��� ����
            timeAfterSpawn = 0f;

            TowerBullet bullet = TowerBulletPool.Inst.CreateBullet(BulletPos.position);
        }


    }


}
