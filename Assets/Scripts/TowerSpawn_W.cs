using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class TowerSpawn_W : MonoBehaviour
{
    int check = 1;
    int CreatTower = 0;

    GameObject tower = null;
    Block block = null;

    void Awake()
    {
        block = GetComponent<Block>();
    }

    void Update()
    {
        // 마우스가 클릭되었는지 확인
        if (Input.GetMouseButtonDown(0))
        {
            RayCheck();
        }
    }

    void RayCheck()
    {
        Vector3 mPosition = Input.mousePosition;

        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(mPosition);
        MousePosition.z = 0f;

        RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, 20f);
        Debug.DrawRay(MousePosition, transform.forward * 100, Color.blue, 0.3f);

        if(hit)
        {
            int chenctower = CheckMapTowerNum();
            UIManager.Inst.Glod_Minus();
            int check = UIManager.Inst.checkOriginCount;

            if(chenctower <= check)
            {
                Debug.Log("## 들어갔니");
                hit.transform.GetComponent<Block>().Inst_Towers(hit.transform);
            }
        }
    }

    void RayCheckDoubleObj()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.forward, 100f);

        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log("hits.Length" + hits.Length);
            RaycastHit2D hit = hits[i];
        }
    }

    int CheckMapTowerNum()
    {
        tower = GameObject.FindGameObjectWithTag("Tower");

        if (tower != null)
        {
            check += 1;

            return check;
        }

        return check;
    }

}
