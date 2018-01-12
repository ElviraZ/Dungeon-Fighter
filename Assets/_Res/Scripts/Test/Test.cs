using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Global;
using Kernal;
using Model;
public class Test : MonoBehaviour 
{
    public  Text  hp,maxhp,mp,maxmp,atk,maxatk,def,maxdef,dex,maxdex,EXPText,killnumText,levelText,goldText,diamondsText;
    private void Awake()
    {
        #region 核心数值事件注册
        Model_PlayerKernalData.evePlayerKernalData += DisplayHp;
        Model_PlayerKernalData.evePlayerKernalData += DisplayMaxHp;
        Model_PlayerKernalData.evePlayerKernalData += DisplayMp;
        Model_PlayerKernalData.evePlayerKernalData += DisplayMaxMp;
        Model_PlayerKernalData.evePlayerKernalData += DisplayATK;
        Model_PlayerKernalData.evePlayerKernalData += DisplayMaxATK;
        Model_PlayerKernalData.evePlayerKernalData += DisplayDef;
        Model_PlayerKernalData.evePlayerKernalData += DisplayMaxDef;
        Model_PlayerKernalData.evePlayerKernalData += DisplayDex;
        Model_PlayerKernalData.evePlayerKernalData += DisplayMaxDex;

        #endregion

        #region 扩展数值事件注册

        Model_PlayerExtendData.evePlayerExtendData += DisplayExp;
        Model_PlayerExtendData.evePlayerExtendData += DisplayKillNum;
        Model_PlayerExtendData.evePlayerExtendData += DisplayLevel;
        Model_PlayerExtendData.evePlayerExtendData += DisplayGold;
        Model_PlayerExtendData.evePlayerExtendData += DisplayDiamonds;
        #endregion

    }

    #region 核心数值事件
    private void Start()
    {
        Model_PlayerKernalDataProxy playerdata = new Model_PlayerKernalDataProxy(100, 100, 10, 5, 45, 100, 100, 10, 5, 50, 0, 0, 0);
        Model_PlayerExtendDataProxy playerextenddata = new Model_PlayerExtendDataProxy(0, 0, 0, 0,0);
        //显示初始值
        Model_PlayerKernalDataProxy.GetInstance().DisplayAllValue();
        Model_PlayerExtendDataProxy.GetInstance().DisplayAllValue();
    }
    public  void  jiaxue()
    {
        Model_PlayerKernalDataProxy.GetInstance().HealthValuePlus(30);

            }
    public void jialan()
    {
        Model_PlayerKernalDataProxy.GetInstance().MPValuePlus(10);
        }
    
    public void jianxue()
    {
        Model_PlayerKernalDataProxy.GetInstance().HealthValueDecrease(30);

    }
    public void jianlan()
    {
        Model_PlayerKernalDataProxy.GetInstance().MPValueDecrease(15);
    }


    private void DisplayHp(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("HP"))
        {
            hp.text = kv.Values.ToString();
        }
    }
    private void DisplayMaxHp(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("MaxHP"))
        {
            maxhp.text = kv.Values.ToString();
        }
    }
    private void DisplayMp(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("MP"))
        {
            mp.text = kv.Values.ToString();
        }
    }
    private void DisplayMaxMp(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("MaxMP"))
        {
            maxmp.text = kv.Values.ToString();
        }
    }
    private void DisplayATK(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("AttackPower"))
        {
            atk.text = kv.Values.ToString();
        }
    }
    private void DisplayMaxATK(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("MaxattackPower"))
        {
            maxatk.text = kv.Values.ToString();
        }
    }
    private void DisplayDef(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("DefencePower"))
        {
            def.text = kv.Values.ToString();
        }
    }
    private void DisplayMaxDef(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("MaxdefencePower"))
        {
            maxdef.text = kv.Values.ToString();
        }
    }
    private void DisplayDex(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("Dexterity"))
        {
            dex.text = kv.Values.ToString();
        }
    }
    private void DisplayMaxDex(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("MaxDexterity"))
        {
            maxdex.text = kv.Values.ToString();
        }
    }

    #endregion

    #region 扩展数值事件

    public void jiaEXP()
    {
        Model_PlayerExtendDataProxy.GetInstance().AddExp(100);
    }
    private void DisplayExp(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("EXP"))
        {
            EXPText.text = kv.Values.ToString();
        }
    }
    private void DisplayKillNum(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("KillNum"))
        {
            killnumText.text = kv.Values.ToString();
        }
    }
    private void DisplayLevel(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("Level"))
        {
            levelText.text = kv.Values.ToString();
        }
    }
    private void DisplayGold(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("Gold"))
        {
            goldText.text = kv.Values.ToString();
        }
    }
    private void DisplayDiamonds(KeyValueUpdate kv)
    {
        if (kv.Key.Equals("Diamonds"))
        {
            diamondsText.text = kv.Values.ToString();
        }
    }

    #endregion
}
