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
        //웨이브시작버튼 누르면
        //1 -> 몬1이 5마리 나옴(1초 간격) 다죽으면 5초 뒤
        //2 -> 몬1이 10마리 나옴 몬2가 3마리나옴
        //3 -> 몬1이 10 //몬2 5마리
        //4 -> 몬1이 15 //몬2 7마리
        // 다죽이면 유윈

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
