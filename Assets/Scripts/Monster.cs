using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CallBackDie();

public class Monster : MonoBehaviour
{
    public CallBackDie callBackDie = null;

    //[SerializeField] ResourceObject monsterData = null;

    List<Vector2> mobPath = null;
    WaitForSeconds speed = new WaitForSeconds(0.7f);

    public void SettingPath(List<Vector2> path)
    {
        mobPath = path;
    }
    // Start is called before the first frame update
    void Start()
    {
        //findPath(2, 4, 1, 1);
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
        UIManager.Inst.PlayerHP_Minus();
        Destroy(this.gameObject);
        callBackDie();
        yield return null;
    }

    public void Die()
    {
        UIManager.Inst.Glod_Plus(5);
        callBackDie();
        Destroy(this.gameObject);
    }

}
