using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TowerSpawn_W : MonoBehaviour
{
    int check = 0;
    int CreatTower = 0;

    //GameObject MapParent = null;
    GameObject tower = null;


    void Update()
    {
        // 마우스가 클릭되었는지 확인
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mPosition = Input.mousePosition; // 마우스의 스크린 좌표를 입력받는다
            Vector3 target = Camera.main.ScreenToWorldPoint(mPosition); // 입력 받은 마우스의 좌표값을 월드좌표로 
            target.z = 0f; // 마우스 z 좌표값 0으로 고정

            RayCheck(mPosition);
        }
    }

    void RayCheck(Vector3 mousePos)
    {
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(mousePos);
        MousePosition.z = 0f;

        RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, 100f);
        Debug.DrawRay(MousePosition, transform.forward * 100, Color.blue, 0.3f);

        if (hit)
        {
            hit.transform.GetComponent<Block>().Inst_Towers(hit.transform);
            int chenctower = CheckMapTowerNum();
            UIManager.Inst.Glod_Minus();

            int check = UIManager.Inst.checkOriginCount;

            if(chenctower == check)
            {
                Debug.Log("## 들어갔니");
                hit.transform.GetComponent<Block>().Destroy_Towers();
            }
        }
    }

    int CheckMapTowerNum()
    {
        tower = GameObject.FindGameObjectWithTag("Tower");

        if (tower != null)
        {
            check += 1;
            //Debug.Log("## 몇개 만들어짐 " + check);

            return check;
        }

        return check;
    }

}
