using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MonsterSpawner : MonoBehaviour
{
    
    [SerializeField] Button waveStart = null;
    [SerializeField] Monster monsterPref0 = null;
    [SerializeField] Monster monsterPref1 = null;

    Map map = null;
    WaitForSeconds s1 = new WaitForSeconds(1);
    WaitForSeconds s5 = new WaitForSeconds(5);
    WaitUntil MonsterCount;
    bool isGaming = true;
    // Start is called before the first frame update
    void Start()
    {
        map = FindObjectOfType<Map>();
        if (waveStart == null) waveStart = GameObject.Find("WaveStart").GetComponent<Button>();
        waveStart.onClick.AddListener(delegate { OnClick_WaveStart(); });
        MonsterCount = new WaitUntil(() => aliveCount == 0);
        //���̺���۹�ư ������
        //1 -> ��1�� 5���� ����(1�� ����) �������� 5�� ��
        //2 -> ��1�� 10���� ���� ��2�� 3��������
        //3 -> ��1�� 10 //��2 5����
        //4 -> ��1�� 15 //��2 7����
        // �����̸� ����

    }

    void OnClick_WaveStart()
    {
        StartCoroutine(nameof(SpawnMonster));
        waveStart.gameObject.SetActive(false);
    }
    int aliveCount = 100;
    IEnumerator SpawnMonster()
    {
        aliveCount = 5;
        for (int i = 0; i < 5; i++)
        {
            Monster mob = Instantiate<Monster>(monsterPref0, map.myPath[0], Quaternion.identity,this.transform);
            mob.callBackDie = DeadMonster;
            mob.SettingPath(map.myPath);
            yield return s1;
        }
        yield return MonsterCount;

        aliveCount = 13;
        for (int i = 0; i < 13; i++)
        {
            if (i < 10)
            {
                Monster mob = Instantiate<Monster>(monsterPref0, map.myPath[0], Quaternion.identity, this.transform);
                mob.SettingPath(map.myPath);
                mob.callBackDie = DeadMonster;
            }
            else
            {
                Monster mob = Instantiate<Monster>(monsterPref1, map.myPath[0], Quaternion.identity, this.transform);
                mob.SettingPath(map.myPath);
                mob.callBackDie = DeadMonster;
            }
            yield return s1;
        }
        yield return MonsterCount;
        if (UIManager.Inst.playerHP > 0)
        {
            UIManager.Inst.Win();
            yield break;
        }
            

        aliveCount = 15;
        for (int i = 0; i < 15; i++)
        {
            if (i < 10)
            {
                Monster mob = Instantiate<Monster>(monsterPref0, map.myPath[0], Quaternion.identity, this.transform);
                mob.SettingPath(map.myPath);
            }
            else
            {
                Monster mob = Instantiate<Monster>(monsterPref1, map.myPath[0], Quaternion.identity, this.transform);
                mob.SettingPath(map.myPath);
            }
            yield return s1;
        }
        yield return MonsterCount;

        aliveCount = 22;
        for (int i = 0; i < 22; i++)
        {
            if (i < 15)
            {
                Monster mob = Instantiate<Monster>(monsterPref0, map.myPath[0], Quaternion.identity, this.transform);
                mob.SettingPath(map.myPath);
            }
            else
            {
                Monster mob = Instantiate<Monster>(monsterPref1, map.myPath[0], Quaternion.identity, this.transform);
                mob.SettingPath(map.myPath);
            }
            yield return s1;
        }
        yield return MonsterCount;
        
        yield return null;
    }

    void DeadMonster()
    {
        aliveCount--;
    }
}
