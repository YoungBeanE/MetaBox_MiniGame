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

    // 鸥况 积己
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

    // 鸥况 昏犁
    public void Destroy_Towers()
    {
        Destroy(TowerPerfab);
    }



}






