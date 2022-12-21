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

    bool isGaming = true;
    // Start is called before the first frame update
    void Start()
    {
        map = FindObjectOfType<Map>();
        if (waveStart == null) waveStart = GameObject.Find("WaveStart").GetComponent<Button>();
        waveStart.onClick.AddListener(delegate { OnClick_WaveStart(); });
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
    }

    IEnumerator SpawnMonster()
    {
        while (isGaming)
        {
            Monster mob = Instantiate<Monster>(monsterPref0, map.myPath[0], Quaternion.identity);
            mob.SettingPath(map.myPath);
        }
        yield return null;
    }
}
