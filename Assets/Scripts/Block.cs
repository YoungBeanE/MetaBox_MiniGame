using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer = null;
    [SerializeField] Sprite road = null;

    public bool IsBlock { get; set; } = true;
    Vector2 myPos;

    [SerializeField] GameObject TowerPerfab = null;

    GameObject Tower = null;

    int check = 0;
    int checkChild = 0;
    public int countUp = 0;

    void Awake()
    {
        myPos = transform.position;
    }
    public void Select()
    {
        IsBlock = false;
        spriteRenderer.sprite = road;

        //BoxCollider2D roadCollider = GetComponent<BoxCollider2D>();
        //roadCollider.enabled = false; // 콜라이더 컴포넌트 비활성화
        //Debug.Log("roadCollider" + roadCollider.enabled);
        //this.gameObject.GetComponent<Collider2D>().enabled = false;
    }

    // 타워 생성
    public void Inst_Towers(Transform instPos)
    {
        check = UIManager.Inst.CreatTowerNum;

        if (Tower == null)
        {
            Tower = Instantiate(TowerPerfab, instPos.position, Quaternion.identity, this.transform);
        }
        else if (Tower != null) { Destroy_Towers(instPos); }

        if (check == 0) return;
    }

    public void Destroy_Towers(Transform instPos)
    {
        //check = UIManager.Inst.CreatTowerNum;
        if (Tower != null) { Destroy(Tower); }
        if (check == 0) return;
    }

    public int checkChildCount()
    {
        checkChild = this.transform.GetChildCount();
        countUp += 1;

        return countUp;
    }
}