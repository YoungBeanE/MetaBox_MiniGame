using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBulletSpawn_W : MonoBehaviour
{
    [Header("총알 프리펩")]
    [SerializeField] TowerBullet bulletPrefab = null; // 총알 프리팹

    [Header("총알 정보")]
    [SerializeField] int attack = 5; // 공격치
    [SerializeField] float spawntime = 1.2f; // 생성 주기
    [SerializeField] Transform BulletPos = null;

    float timeAfterSpawn;

    Transform target = null; // 발사할 대상

    void Start()
    {
        //최근 생성 이후의 누적 시간을 0으로 초기화
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
            // 누적된 시간을 리셋
            timeAfterSpawn = 0f;
            TowerBullet bullet = TowerBulletPool.Inst.CreateBullet(BulletPos.position);
        }
    }
}
