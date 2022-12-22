using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] GameObject TowerPerfab = null;

    GameObject Tower = null;

    bool isTowerCanInst = true;

    int check = 0;

    void Awake()
    {

    }

    // 타워 생성
    public void Inst_Towers(Transform instPos)
    {
        check = UIManager.Inst.CreatTowerNum;

        if (Tower != null) return;

        if (isTowerCanInst)
        {


            Tower = Instantiate(TowerPerfab, instPos.position, Quaternion.identity, this.transform);

            if (check == 0) return;
        }
    }

    // 타워 삭재
    public void Destroy_Towers()
    {
        Destroy(TowerPerfab.gameObject);
        Debug.Log("삭제함??");
    }

}






