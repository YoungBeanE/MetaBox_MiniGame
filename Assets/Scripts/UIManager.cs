using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    #region 싱글턴
    private static UIManager instance;
    public static UIManager Inst
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<UIManager>();
                if(instance == null)
                {
                    instance = new GameObject(nameof(UIManager), typeof(UIManager)).GetComponent<UIManager>();
                }
            }
            return instance;
        }
    }
    #endregion

    [Header("게임 시작 판넬")]
    [SerializeField] GameObject TitlePanel = null;
    [SerializeField] GameObject block = null;

    [Header("인게임 UI")]
    [SerializeField] GameObject InGameUI = null;

    [Header("게임 종료 판넬")]
    [SerializeField] GameObject GameOver = null;

    [Header("재화UI")]
    [SerializeField] TextMeshProUGUI GoldNumText = null;
    [Header("타워 설치가능한 수량UI")]
    [SerializeField] TextMeshProUGUI towerNum = null;
    [Header("플레이어 체력UI")]
    [SerializeField] GameObject[] playerHp = null;

    [SerializeField] GameObject towerspawn = null;

    int Wave1_coin = 150;
    int tower_bycoin = 70;
    public int CreatTowerNum = 0;
    public int checkOriginCount = 0;

    void Awake()
    {
        TitlePanel.gameObject.SetActive(true);
        InGameUI.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(false);
        towerspawn.SetActive(false);
    }

    void Start()
    {
        GoldNumText.text = $"Gold : {Wave1_coin.ToString()}";
        CreatTowerNum = (Wave1_coin / tower_bycoin);
        checkOriginCount = CreatTowerNum;
        //Debug.Log(checkOriginCount);
        towerNum.text = $"Tower :{CreatTowerNum.ToString()}";
    }

    public void Glod_Minus()
    {
        // 코인 텍스트에 -70 해주기;
        Wave1_coin -= 70;
        if (Wave1_coin < 0) return;
        GoldNumText.text = $"Gold : {Wave1_coin.ToString()}";
        towerText_Minus();
    }

    public void Glod_DeldetTowerPlus()
    {
        Wave1_coin += 70;
        GoldNumText.text = $"Gold : {Wave1_coin.ToString()}";
        towerText_Plus();
    }

    int towerText_Plus()
    {
        CreatTowerNum += 1;
        towerNum.text = $"Tower :{CreatTowerNum.ToString()}";
        //Debug.Log("CreatTowerNum" + CreatTowerNum);
        return CreatTowerNum;

        if (CreatTowerNum > checkOriginCount) { return checkOriginCount;}
    }
     
    int towerText_Minus()
    {
        CreatTowerNum -= 1;
        towerNum.text = $"Tower :{CreatTowerNum.ToString()}";
        //Debug.Log("CreatTowerNum" + CreatTowerNum);
        return CreatTowerNum;

        if (CreatTowerNum < 0) return 0;
    }

    #region 스타트 판넬
    public void Onclick_StartButton()
    {
        if (TitlePanel.activeInHierarchy == true)
        {
            activeBlock();
            TitlePanel.SetActive(false);
            // 인게임 판넬 및 타워생성 활성화
            InGameUI.SetActive(true);
            towerspawn.SetActive(true);
        }
        else
            TitlePanel.SetActive(true);
    }

    public void activeBlock()
    {
        if (block.activeInHierarchy == false)
            block.SetActive(true);
        else
            block.SetActive(false);
    }

    #endregion
}
