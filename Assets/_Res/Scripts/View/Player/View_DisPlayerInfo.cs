/*
*显示玩家的各种信息
*等级，hp   mp   exp  atk  。。。。。。。
*
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Global;
using Kernal;
using Ctrl;
using Model;
namespace View
{
    public class View_DisPlayerInfo : MonoBehaviour
    {
        #region     屏幕上的
        public Text levelTextByScreen;

        public Text curhpTextByScreen;
        public Text maxhpTextByScreen;

        public Text curmpTextByScreen;
        public Text maxmpTextByScreen;

        public Text curexpTextByScreen;
        public Text goldTextByScreen;
        public Text diaTextByScreen;



        public Text playerName;
        public Slider sliHP;
        public Slider sliMP;

        #endregion
        #region   玩家的详细信息   
        public Text curhpText;
        public Text maxhpText;

        public Text curmpText;
        public Text maxmpText;

        public Text curexpText;
        public Text goldText;
        public Text diaText;

        public Text curatkText;
        public Text maxatkText;

        public Text curdefText;
        public Text maxdefText;

        public Text curdexText;
        public Text maxdexText;

        public Text killnumText;
        public Text levelText;
        #endregion  
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
        private void Start()
        {
            //Model_PlayerKernalDataProxy playerdata = new Model_PlayerKernalDataProxy(100, 100, 10, 5, 45, 100, 100, 10, 5, 50, 0, 0, 0);
            //Model_PlayerExtendDataProxy playerextenddata = new Model_PlayerExtendDataProxy(0, 0, 0, 0, 0);
            //显示初始值
            Model_PlayerKernalDataProxy.GetInstance().DisplayAllValue();
            Model_PlayerExtendDataProxy.GetInstance().DisplayAllValue();
            if (string.IsNullOrEmpty(GlobalParameterManager.PlayerName))
            {
            playerName.text = GlobalParameterManager.PlayerName;

            }
        }

        #region   事件注册方法

        private void DisplayHp(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("HP"))
            {
                if (curhpTextByScreen&& curhpText)
                {
                    curhpTextByScreen.text = kv.Values.ToString();
                    curhpText.text = kv.Values.ToString();
                    //处理滑动条

                    sliHP.value = (float)kv.Values ;
                }
            }
        }
        private void DisplayMaxHp(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("MaxHP"))
            {
                if (maxhpTextByScreen&& maxhpText)
                {
                    maxhpTextByScreen.text = kv.Values.ToString();
                    maxhpText.text = kv.Values.ToString();

                    sliHP.minValue = 0;
                    sliHP.maxValue = (float)kv.Values;
                 //   sliHP.value = float.Parse(curhpText.text);
                }
            }
        }
        private void DisplayMp(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("MP"))
            {
                if (curmpTextByScreen&& curmpText)
                {
                    curmpTextByScreen.text = kv.Values.ToString();
                    curmpText.text = kv.Values.ToString();
              
                    sliMP.value = (float)kv.Values;
                }
            }
        }
        private void DisplayMaxMp(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("MaxMP"))
            {
                if (maxmpTextByScreen&& maxmpText)
                {
                    maxmpTextByScreen.text = kv.Values.ToString();
                    maxmpText.text = kv.Values.ToString();
                    sliMP.minValue = 0;

                    sliMP.maxValue = (float)kv.Values;
                 //   sliMP.value = float.Parse(curmpText.text);
                }
            }
        }
        private void DisplayATK(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("AttackPower"))
            {if ( curatkText)
            {
                    curatkText.text = kv.Values.ToString();
                    //curatkTextByScreen.text = kv.Values.ToString();
                }
            }
        }
        private void DisplayMaxATK(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("MaxattackPower"))
            {
                if ( maxatkText)
                {
                    //maxatkTextByScreen.text = kv.Values.ToString();
                    maxatkText.text = kv.Values.ToString();
                }
            }
        }
        private void DisplayDef(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("DefencePower"))
            {
                if (curdefText)
                {
                    curdefText.text = kv.Values.ToString();
                }
            }
        }
        private void DisplayMaxDef(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("MaxdefencePower"))
            {
                if (maxdefText)
                {
                    maxdefText.text = kv.Values.ToString();
                }
            }
        }
        private void DisplayDex(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Dexterity"))
            {
                if (curdexText)
                {
                    curdexText.text = kv.Values.ToString();
                }
            }
        }
        private void DisplayMaxDex(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("MaxDexterity"))
            {
                if (maxdexText)
                {
                    maxdexText.text = kv.Values.ToString();
                }
            }
        }
        private void DisplayExp(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("EXP"))
            {
                if (curexpText)
                {
                    curexpText.text = kv.Values.ToString();
                }
            }
        }
        private void DisplayKillNum(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("KillNum"))
            {
                if (killnumText)
                {
                    killnumText.text = kv.Values.ToString();
                }
            }
        }
        private void DisplayLevel(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Level"))
            {
                if (levelText&& levelTextByScreen)
                {
                    levelText.text = kv.Values.ToString();
                    levelTextByScreen.text = kv.Values.ToString();
                }
            }
        }
        private void DisplayGold(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Gold"))
            {
                if (goldText&& goldTextByScreen)
                {
                    goldText.text = kv.Values.ToString();
                    goldTextByScreen.text = kv.Values.ToString();
                }
            }
        }
        private void DisplayDiamonds(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Diamonds"))
            {
                if (diaText&&diaTextByScreen)
                {
                    diaText.text = kv.Values.ToString();
                    diaTextByScreen.text = kv.Values.ToString();
                }
            }
        }
        #endregion
    }
}