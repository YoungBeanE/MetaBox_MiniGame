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
    [Header("��ȭ")]
    [SerializeField] TextMeshProUGUI GoldNumText = null;
    [Header("Ÿ�� ��ġ������ ����")]
    [SerializeField] TextMeshProUGUI towerNum = null;
    [Header("�÷��̾� ü��")]
    [SerializeField] GameObject[] playerHp = null;
    [Header("���� ����")]
    [SerializeField] GameObject GameOver = null;

    public Action<int> towerCountCheck;

    int Wave1_coin = 150;
    int tower_bycoin = 70;
    public int CreatTowerNum = 0;
    public int checkOriginCount = 0;

    void Awake()
    {
        GoldNumText.text = $"Gold : {Wave1_coin.ToString()}";
        CreatTowerNum = (Wave1_coin / tower_bycoin);
        checkOriginCount = CreatTowerNum;
        //Debug.Log(checkOriginCount);
        towerNum.text = $"Tower :{CreatTowerNum.ToString()}";
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
}
