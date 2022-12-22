using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class TowerSpawn_W : MonoBehaviour
{
    int check = 0;
    int CreatTower = 0;

    GameObject tower = null;
    GameObject map = null;
    Block block = null;

    void Awake()
    {
        map = GameObject.FindGameObjectWithTag("Map");
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

        if (hit)
        {
            int checks = UIManager.Inst.checkOriginCount;

            Debug.Log("## 0 Find Tower num : " + check);

            if (check < checks)
            {
                Debug.Log("## 1 Find Tower num : " + check);
                Debug.Log("checks : " + checks);

                if (hit.collider.name.Equals("Block(Clone)"))
                {
                    hit.transform.GetComponent<Block>().Inst_Towers(hit.transform);
                    check += 1;
                    UIManager.Inst.Glod_Minus();
                    Debug.Log("##타워 만들어 : " + check);
                }

                if (hit.collider.name.Equals("Tower(Clone)"))
                {
                    Destroy(hit.transform.gameObject);
                    check -= 1;
                    UIManager.Inst.Glod_DeldetTowerPlus();
                    Debug.Log("##타워 삭제함" + check);
                }
            }
            else if ( check == checks)
            {
                Debug.Log("checks 2: " + checks);
                Debug.Log("hit.name" + hit.collider.name);


            }
        }
    }
}
