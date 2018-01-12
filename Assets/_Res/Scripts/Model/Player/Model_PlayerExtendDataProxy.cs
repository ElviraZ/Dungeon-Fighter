using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kernal;
using Global;
namespace Model
{
    /// <summary>
    /// 玩家的额外数据代理
    /// </summary>
    public class Model_PlayerExtendDataProxy : Model_PlayerExtendData
    {
        public static Model_PlayerExtendDataProxy _Instance;

        private float minEnemyAttack = 1f;
        #region 构造函数
        public static Model_PlayerExtendDataProxy GetInstance()
        {
            if (_Instance != null)
            {
                return _Instance;
            }
            else
            {
                return null;
            }
        }
        public Model_PlayerExtendDataProxy(int exp, int killnum, int level, int gold, int diamonds) : base(exp, killnum, level, gold, diamonds)
        {
            if (_Instance == null)
            {
                _Instance = this;
            }
            else
            {

            }

        }

        #endregion
        #region 经验值
        public void  AddExp(int  value)
        {
            base.EXP += value;
            //升級處理
            UpgradeRule.GetInstance().UpgradeCondition(base.EXP);
        }
        public void  LostExp()
        { }
        public  int  GetExp()
        { return base.EXP; }
        #endregion
        #region 杀敌数量
        public void AddKillNum()
        {
            base.KillNum++;
        }

        public int GetKillNum()
        { return base.KillNum; }
        #endregion
        #region 等级
        public void AddLevel()
        {
            ++base.Level;
            UpgradeRule.GetInstance().UpgradeOperation((LevelName)base.Level);
        }

        public int GetLevel()
        { return base.Level; }
        #endregion
        #region 金币
        public void AddGlod(int value)
        {
            base.Gold +=Mathf.Abs(   value);
        }
        public void LostGold(int value)
        {
            base.Gold -= Mathf.Abs(value);
        }
        public int GetGold()
        { return base.Gold; }
        #endregion
        #region 砖石
        public void AddDiamonds(int value)
        {
            base.Diamonds += Mathf.Abs(value);
        }
        public void LostDiamonds(int value)
        { base.Diamonds -= Mathf.Abs(value); }
        public int GetDiamonds()
        { return base.Diamonds; }
        #endregion
        public void DisplayAllValue()
        {
            base.EXP = base.EXP;
            base.KillNum = base.KillNum;
            base.Level = base.Level;
            base.Gold = base.Gold;
            base.Diamonds = base.Diamonds;


        }

    }
}
