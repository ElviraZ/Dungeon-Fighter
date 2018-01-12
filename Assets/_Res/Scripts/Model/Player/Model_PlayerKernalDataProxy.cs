using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Kernal;
using Global;
namespace Model
{
    /// <summary>
    /// 玩家的核心数据代理
    /// </summary>
    public class Model_PlayerKernalDataProxy : Model_PlayerKernalData
    {
        public static Model_PlayerKernalDataProxy _Instance;

        private float minEnemyAttack = 1f;
        public static Model_PlayerKernalDataProxy GetInstance()
        {
            if (_Instance!=null)
            {
                return _Instance;
            }
            else
            {
                return null;
            }
        }
        public Model_PlayerKernalDataProxy(float hp, float mp, float attack, float defence, float dextrity, 
            float maxhp, float maxmp, float maxattack, float maxdefence, float maxdextrity, 
            float propattack, float propdefence, float propdextrity) 
            : base(hp, mp, attack, defence, dextrity, maxhp, maxmp, maxattack, maxdefence, maxdextrity, propattack, propdefence, propdextrity)
        {
            if (_Instance==null)
            {
                _Instance =this;
            }
            else
            {
            
            }
    
        }

        #region 关于生命值的操作
        /// <summary>
        /// 加血
        /// </summary>
        public    void  HealthValuePlus(float  value)
        {
            base.HP += value;
            if (base.HP>=MaxHP)
            {
                base.HP = MaxHP;
            }
            this.UpdateAttackValue();
            this.UpdateDefenceValue();
            this.UpdateDexValue();
        }
        /// <summary>
        /// 减血，value=敌人的攻击力
        /// </summary>
        public void HealthValueDecrease(float value)
        {
            float realAttack = value - base.DefencePower - base.PropdefencePower;
            if (realAttack  > 0)
            {
                base.HP -= realAttack;
            }
            else
            {
                base.HP -= minEnemyAttack;
            }
            base.HP = Mathf.Clamp(base.HP, 0f, base.MaxHP);
            this.UpdateAttackValue();
            this.UpdateDefenceValue();
            this.UpdateDexValue();

        }
        /// <summary>
        /// 升级
        /// </summary>
        public void MaxHealthValuePlus(float value)
        {
            base.MaxHP +=Mathf.Abs( value);
        }
        /// <summary>
        /// 获得生命值
        /// </summary>
        public float GetHealthValue()
        {
            return base.HP;
        }
        /// <summary>
        /// 获得最大生命值
        /// </summary>
        public float GetMaxHealthValue()
        {
            return base.MaxHP;
        }
        #endregion

        #region 关于魔法值的操作
        /// <summary>
        /// 加蓝,value=蓝药品的蓝
        /// </summary>
        public void MPValuePlus(float value)
        {
            base.MP += value;
            //if (base.MP >= MaxMP)
            //{
            //    base.MP = MaxMP;
            //}
            base.MP = Mathf.Clamp(base.MP, 0f, base.MaxMP);
        }
        /// <summary>
        /// 减蓝，value=消耗的蓝
        /// </summary>
        public void MPValueDecrease(float value)
        {
           
            if (base.MP-value>=0)
            {
                base.MP -= value;

            }
          
        }
        /// <summary>
        /// 升级，改变蓝的上限
        /// </summary>
        public void MaxMPValuePlus(float value)
        {
            base.MaxMP += Mathf.Abs(value);
        }
        /// <summary>
        /// 获得魔法值
        /// </summary>
        public float GetMPValue()
        {
            return base.MP;
        }
        /// <summary>
        /// 获得最大魔法值
        /// </summary>
        public float GetMaxMPValue()
        {
            return base.MaxMP;
        }
        #endregion

        #region 关于攻击力值的操作
        /// <summary>
        /// 更新武器的攻击力，value=新的武器的攻击力
        /// </summary>
        public void UpdateAttackValue(float value=0)
        {
  
            if (value>0)
            {
                base.AttackPower = base.MaxattackPower / 2 * (base.HP / base.MaxHP) +value;
                base.PropattackPower = value;
            }
            else
            {
                base.AttackPower = base.MaxattackPower / 2 * (base.HP / base.MaxHP) + base.PropattackPower;

            }
            base.AttackPower = Mathf.Clamp(base.AttackPower, 0f, base.MaxattackPower);
        }

        /// <summary>
        /// 增加最大的攻击力
        /// </summary>
        public void IncreaseMaxATKValue(float value)
        {
            base.MaxattackPower += Mathf.Abs(value);
        }
        /// <summary>
        /// 获得攻击力
        /// </summary>
        public float GetATKValue()
        {
            return base.AttackPower;
        }
        /// <summary>
        /// 获得最大攻击力
        /// </summary>
        public float GetMaxATKValue()
        {
            return base.MaxattackPower;
        }
        #endregion

        #region 关于防御力值的操作
        public void UpdateDefenceValue(float value = 0)
        {

            if (value > 0)
            {
                base.DefencePower = base.MaxdefencePower / 2 * (base.HP / base.MaxHP) + value;
                base.PropdefencePower = value;
            }
            else
            {
                base.DefencePower = base.MaxattackPower / 2 * (base.HP / base.MaxHP) + base.PropdefencePower;

            }
            base.DefencePower = Mathf.Clamp(base.DefencePower, 0f, base.MaxdefencePower);

        }

        /// <summary>
        /// 增加最大的防御力
        /// </summary>
        public void IncreaseMaxDefValue(float value)
        {
            base.MaxdefencePower += Mathf.Abs(value);
        }
        /// <summary>
        /// 获得防御力
        /// </summary>
        public float GetDefValue()
        {
            return base.DefencePower;
        }
        /// <summary>
        /// 获得最大防御力
        /// </summary>
        public float GetMaxDefValue()
        {
            return base.MaxdefencePower;
        }
        #endregion


        #region 关于敏捷值的操作
        public void UpdateDexValue(float value = 0)
        {

            if (value > 0)
            {
                base.Dexterity = base.MaxDexterity / 2 * (base.HP / base.MaxHP) + value-base.DefencePower;
                base.PropDexterity = value;
            }
            else
            {
                base.Dexterity = base.MaxattackPower / 2 * (base.HP / base.MaxHP) + base.PropDexterity - base.DefencePower;

            }
            base.Dexterity = Mathf.Clamp(base.Dexterity, 0f, base.MaxDexterity);

        }

        /// <summary>
        /// 增加最大的敏捷度
        /// </summary>
        public void IncreaseMaxDexValue(float value)
        {
            base.MaxDexterity += Mathf.Abs(value);
        }
        /// <summary>
        /// 获得敏捷度
        /// </summary>
        public float GetDexValue()
        {
            return base.Dexterity;
        }
        /// <summary>
        /// 获得最大敏捷度
        /// </summary>
        public float GetMaxDexValue()
        {
            return base.MaxDexterity;
        }

        #endregion

        public void  DisplayAllValue()
        {
            base.HP = base.HP;
            base.MP = base.MP;
            base.AttackPower = base.AttackPower;
            base.DefencePower = base.DefencePower;
            base.Dexterity = base.Dexterity;

            base.MaxHP = base.MaxHP;
            base.MaxMP = base.MaxMP;
            base.MaxattackPower = base.MaxattackPower;
            base.MaxdefencePower = base.MaxdefencePower;
            base.MaxDexterity = base.MaxDexterity;


            base.PropattackPower = base.PropattackPower;
            base.PropdefencePower = base.PropdefencePower;
            base.PropDexterity = base.PropDexterity;
        }

    }
}
