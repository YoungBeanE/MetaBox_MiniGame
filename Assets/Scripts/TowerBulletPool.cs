using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBulletPool : MonoBehaviour
{
    #region 싱글턴현재 안사용
    private static TowerBulletPool instance;
    public static TowerBulletPool Inst
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TowerBulletPool>();
                if (instance == null)
                {
                    instance = new GameObject(nameof(TowerBulletPool), typeof(TowerBulletPool)).GetComponent<TowerBulletPool>();
                }
            }
            return instance;
        }
    }

    #endregion

    TowerBullet prefabMob = null;
    Queue<TowerBullet> pool = new Queue<TowerBullet>();

    void Awake()
    {
        prefabMob = Resources.Load<TowerBullet>("Tower_Bullet");
    }

    public TowerBullet CreateBullet(Vector3 pos)
    {
        TowerBullet instMob = null;

        if(pool.Count == 0)
        {
            instMob = Instantiate(prefabMob, pos, Quaternion.identity, this.transform);

            return instMob;
        }

        instMob = pool.Dequeue();

        instMob.transform.position = pos;
        instMob.transform.rotation = Quaternion.identity;
        instMob.gameObject.SetActive(true);

        return instMob;
    }

    public void DestroyTowerBullet()
    {
        prefabMob.gameObject.SetActive(false);
        pool.Enqueue(prefabMob);

    }

}
