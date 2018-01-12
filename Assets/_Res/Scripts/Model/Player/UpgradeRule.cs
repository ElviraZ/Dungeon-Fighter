using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;
using Kernal;
using Model;
/// <summary>
/// 升級的規則,开放-封闭原则，单一职责 原则
/// </summary>
namespace Model
{
    public class UpgradeRule 
    {
        private static UpgradeRule _Instance;
        private UpgradeRule() { }

        public   static UpgradeRule  GetInstance()
        {
            if (_Instance==null)
            {
                _Instance = new UpgradeRule();
            }
            return _Instance;
         }
        /// <summary>
        /// 升级条件
        /// </summary>
        public  void  UpgradeCondition(int  exp)
        {
            int curLevel = Model_PlayerExtendDataProxy.GetInstance().GetLevel();
            if (exp>=100&&exp<300&& curLevel==0)
            {
                Model_PlayerExtendDataProxy.GetInstance().AddLevel();
            }
            else if (exp >= 300 && exp < 500 && curLevel == 1)
            {
                Model_PlayerExtendDataProxy.GetInstance().AddLevel();

            }
            else if (exp >= 500 && exp < 1000 && curLevel == 2)
            {
                Model_PlayerExtendDataProxy.GetInstance().AddLevel();

            }
            else if (exp >= 1000 && exp < 3000 && curLevel == 3)
            {
                Model_PlayerExtendDataProxy.GetInstance().AddLevel();
            }
            else if (exp >= 3000 && exp < 5000 && curLevel == 4)
            {
                Model_PlayerExtendDataProxy.GetInstance().AddLevel();
            }
            else if (exp >= 5000 && exp < 10000 && curLevel == 5)
            {
                Model_PlayerExtendDataProxy.GetInstance().AddLevel();
            }
        }
        /// <summary>
        /// 升级的具体操作
        /// </summary>
        public  void  UpgradeOperation(LevelName   levelname)
        {
            switch (levelname)
            {
                case LevelName.Level_0:
                    UpgradeRuleOperation(10,10,2,1,10);
                    break;
                case LevelName.Level_1:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_2:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_3:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_4:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_5:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_6:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_7:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_8:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_9:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.Level_10:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                default:
                    break;
            }
        }
        private   void UpgradeRuleOperation(float  maxhp,float maxmp, float maxattack, float maxdef, float maxdex)
        {
            Model_PlayerKernalDataProxy.GetInstance().MaxHealthValuePlus(maxhp);
            Model_PlayerKernalDataProxy.GetInstance().MaxMPValuePlus(maxmp);
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxATKValue(maxattack);
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxDefValue(maxdef);
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxDexValue(maxdex);

            Model_PlayerKernalDataProxy.GetInstance().HealthValuePlus(Model_PlayerKernalDataProxy.GetInstance().GetMaxHealthValue());
            Model_PlayerKernalDataProxy.GetInstance().MPValuePlus(Model_PlayerKernalDataProxy.GetInstance().GetMaxMPValue());
            Model_PlayerKernalDataProxy.GetInstance().UpdateAttackValue(Model_PlayerKernalDataProxy.GetInstance().GetMaxATKValue());
            Model_PlayerKernalDataProxy.GetInstance().UpdateDefenceValue(Model_PlayerKernalDataProxy.GetInstance().GetMaxDefValue());
            Model_PlayerKernalDataProxy.GetInstance().UpdateDexValue(Model_PlayerKernalDataProxy.GetInstance().GetMaxDexValue());

        }
    }
}
