
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;
using Model;
/*
*
*
*英雄的属性脚本
* 描述：
* 1、实例化并且初始化玩家的数据
* 2、提供其他脚本调用修改玩家属性的方法
* 
*/

namespace Ctrl
{
    public class Ctrl_HeroProperty : BaseControl
    {
        //核心数值
        public float playerCurrentHP;
        public float playerCurrentHPP;
        public float playerCurrentMP;
        public float playerCurrentMPP;
        public float _propattackPower;
        public float _defencePower;
        public float _propdefencePower;
        public float _Dexterity;//敏捷度
        public float _propDexterity;

        private float _MaxHP;
        private float _MaxMP;
        private float _MaxattackPower;
        private float _MaxdefencePower;
        private float _MaxDexterity;

        //扩展数值
        public int _EXP;
        public int _KillNum;
        public int _Level;
        public int _Gold;
        public int _Diamonds;

       void Start()
        {

            Model_PlayerKernalDataProxy playerdata = 
                new Model_PlayerKernalDataProxy(100, 100, 10, 5, 45, 100, 100, 10, 5, 50, 0, 0, 0);
            Model_PlayerExtendDataProxy playerextenddata = 
                new Model_PlayerExtendDataProxy(0, 0, 0, 0, 0);

        }
    }
}
