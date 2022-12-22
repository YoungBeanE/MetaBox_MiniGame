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

    Transform target = null; // �߻��� ���

    void Start()
    {
        //�ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
    }


    void Update()
    {
        
        WavwStart_BulletSpawn();

    }

    public void WavwStart_BulletSpawn()
    {
        target = FindObjectOfType<Monster>().transform;

        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawntime)
        {
            // ������ �ð��� ����
            timeAfterSpawn = 0f;
            TowerBullet bullet = TowerBulletPool.Inst.CreateBullet(BulletPos.position);
        }
    }
}
