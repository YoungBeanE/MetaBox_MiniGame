using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CallBackDie();

public class Monster : MonoBehaviour
{
    public CallBackDie callBackDie = null;

    [SerializeField] ResourceObject monsterData = null;
    [SerializeField] SpriteRenderer spriteRenderer = null;

    List<Vector2> mobPath = null;
    int monsterHP;
    float monsterSpeed;
    int monsterGold;
    int monsterDamage;

    WaitForSeconds speed = null;

    public void SettingPath(List<Vector2> path)
    {
        mobPath = path;
    }
    // Start is called before the first frame update
    void Start()
    {
        monsterHP = monsterData.monsterDatas[0].hp;
        monsterSpeed = monsterData.monsterDatas[0].speed;
        monsterGold = monsterData.monsterDatas[0].gold;
        monsterDamage = monsterData.monsterDatas[0].damage;
        speed = new WaitForSeconds(monsterSpeed * 0.1f);
        StartCoroutine(nameof(MoveMonster));
    }

    IEnumerator MoveMonster()
    {
        yield return speed;

        for (int i = 0; i < mobPath.Count; i++)
        {
            transform.position = mobPath[i];
            yield return speed;
        }
        UIManager.Inst.PlayerHP_Minus(monsterDamage);
        Destroy(this.gameObject);
        callBackDie();
        yield return null;
    }

    public void Attack()
    {
        monsterHP -= 10;
        
        if (monsterHP <= 0)
        {
            UIManager.Inst.Glod_Plus(monsterGold);
            callBackDie();
            Destroy(this.gameObject);
        }else
            spriteRenderer.color = Color.red;
    }

}
