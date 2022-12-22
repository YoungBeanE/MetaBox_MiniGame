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

    void Awake()
    {
        myPos = transform.position;
    }
    public void Select()
    {
        IsBlock = false;
        spriteRenderer.sprite = road;
    }

    // 타워 생성
    public void Inst_Towers(Transform instPos)
    {
        check = UIManager.Inst.CreatTowerNum;

        if (Tower != null) return;

        Tower = Instantiate(TowerPerfab, instPos.position, Quaternion.identity, this.transform);

        if (check == 0) return;
    }


}