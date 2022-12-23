using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    #region �̱���
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

    [SerializeField] GameObject TitlePanel = null;
    [SerializeField] GameObject block = null;

    [SerializeField] GameObject InGameUI = null;

    [SerializeField] GameObject GameOver = null;
    [SerializeField] TextMeshProUGUI gameOverText = null;


    [SerializeField] TextMeshProUGUI GoldNumText = null;

    [SerializeField] TextMeshProUGUI towerNum = null;

    [SerializeField] TextMeshProUGUI playerHPText = null;
    [SerializeField] GameObject[] playerHps = null;

    [SerializeField] GameObject towerspawn = null;

    int Wave1_coin = 150;
    int tower_bycoin = 70;
    public int playerHP = 5;
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
        towerNum.text = $"Tower : {CreatTowerNum.ToString()}";
        playerHPText.text = $"HP : {playerHP}";
    }
    public void PlayerHP_Minus(int damage)
    {
        playerHP -= damage;
        if (playerHP <= 0)
        {
            playerHPText.text = $"HP : 0";
            GameOver.gameObject.SetActive(true);
            gameOverText.text = "You Lose";
        }
        else playerHPText.text = $"HP : {playerHP}";
    }
    public void Win()
    {
        GameOver.gameObject.SetActive(true);
        gameOverText.text = "You Win";
    }
    public void Glod_Plus(int glod)
    {
        Wave1_coin += glod;
        GoldNumText.text = $"Gold : {Wave1_coin.ToString()}";
    }

    public void Glod_Minus()
    {
        // ���� �ؽ�Ʈ�� -70 ���ֱ�;
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
        if (Wave1_coin >= 150) return;
    }

    int towerText_Plus()
    {
        CreatTowerNum += 1;
        towerNum.text = $"Tower : {CreatTowerNum.ToString()}";
        //Debug.Log("CreatTowerNum" + CreatTowerNum);
        return CreatTowerNum;

        if (CreatTowerNum > checkOriginCount) { return checkOriginCount;}
    }
     
    int towerText_Minus()
    {
        if (CreatTowerNum <= 0) return 0;

        CreatTowerNum -= 1;
        towerNum.text = $"Tower : {CreatTowerNum.ToString()}";
        //Debug.Log("CreatTowerNum" + CreatTowerNum);
        return CreatTowerNum;

    }

    #region ��ŸƮ �ǳ�
    public void Onclick_StartButton()
    {
        if (TitlePanel.activeInHierarchy == true)
        {
            activeBlock();
            TitlePanel.SetActive(false);
            // �ΰ��� �ǳ� �� Ÿ������ Ȱ��ȭ
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
