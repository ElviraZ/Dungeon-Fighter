using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Kernal;
using Global;
namespace Model
{
    /// <summary>
    /// 玩家的核心数据
    /// </summary>
    public class Model_PlayerKernalData
    {
        //玩家核心数值的事件
        public  static   event   DEL_PlayerKernalModel   evePlayerKernalData;
        private float _HP;
        private float _MP;
        private float _attackPower;
        private float _propattackPower;
        private float _defencePower;
        private float _propdefencePower;
        private float _Dexterity;//敏捷度
        private float _propDexterity;

        private float _MaxHP;
        private float _MaxMP;
        private float _MaxattackPower;
        private float _MaxdefencePower;
        private float _MaxDexterity;

        public float HP
        {
            get
            {
                return _HP;
            }

            set
            {
                _HP = value;
                if (evePlayerKernalData!=null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("HP", HP);
                    evePlayerKernalData(kv);
                }
            }
        }
        public float MP
        {
            get
            {
                return _MP;
            }

            set
            {
                _MP = value;
                if (evePlayerKernalData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("MP", MP);
                    evePlayerKernalData(kv);
                }
            }
        }
        public float AttackPower
        {
            get
            {
                return _attackPower;
            }

            set
            {
                _attackPower = value;
                if (evePlayerKernalData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("AttackPower", AttackPower);
                    evePlayerKernalData(kv);
                }
            }
        }
        public float DefencePower
        {
            get
            {
                return _defencePower;
            }

            set
            {
                _defencePower = value;
                if (evePlayerKernalData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("DefencePower", DefencePower);
                    evePlayerKernalData(kv);
                }
            }
        }
        public float Dexterity
        {
            get
            {
                return _Dexterity;
            }

            set
            {
                _Dexterity = value;
                if (evePlayerKernalData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Dexterity", Dexterity);
                    evePlayerKernalData(kv);
                }
            }
        }

        public float MaxHP
        {
            get
            {
                return _MaxHP;
            }

            set
            {
                _MaxHP = value;
                if (evePlayerKernalData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("MaxHP", MaxHP);
                    evePlayerKernalData(kv);
                }
            }
        }
        public float MaxMP
        {
            get
            {
                return _MaxMP;
            }

            set
            {
                _MaxMP = value;
                if (evePlayerKernalData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("MaxMP", MaxMP);
                    evePlayerKernalData(kv);
                }
            }
        }
        public float MaxattackPower
        {
            get
            {
                return _MaxattackPower;
            }

            set
            {
                _MaxattackPower = value;
                if (evePlayerKernalData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("MaxattackPower", MaxattackPower);
                    evePlayerKernalData(kv);
                }
            }
        }
        public float MaxdefencePower
        {
            get
            {
                return _MaxdefencePower;
            }

            set
            {
                _MaxdefencePower = value;
                if (evePlayerKernalData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("MaxdefencePower", MaxdefencePower);
                    evePlayerKernalData(kv);
                }
            }
        }
        public float MaxDexterity
        {
            get
            {
                return _MaxDexterity;
            }

            set
            {
                _MaxDexterity = value;
                if (evePlayerKernalData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("MaxDexterity", MaxDexterity);
                    evePlayerKernalData(kv);
                }
            }
        }

        public float PropattackPower
        {
            get
            {
                return _propattackPower;
            }

            set
            {
                _propattackPower = value;
                if (evePlayerKernalData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("PropattackPower", PropattackPower);
                    evePlayerKernalData(kv);
                }
            }
        }
        public float PropdefencePower
        {
            get
            {
                return _propdefencePower;
            }

            set
            {
                _propdefencePower = value;
                if (evePlayerKernalData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("PropdefencePower", PropdefencePower);
                    evePlayerKernalData(kv);
                }
            }
        }
        public float PropDexterity
        {
            get
            {
                return _propDexterity;
            }

            set
            {
                _propDexterity = value;
                if (evePlayerKernalData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("PropDexterity", PropDexterity);
                    evePlayerKernalData(kv);
                }
            }
        }

        private Model_PlayerKernalData()
        { }
        public Model_PlayerKernalData(float hp, float mp, float attack, float defence, float dextrity,
                                                         float maxhp, float maxmp, float maxattack, float maxdefence, float maxdextrity,
                                                         float propattack, float propdefence, float propdextrity)
        {

            this._HP = hp;
            this._MP = mp;
            this._attackPower = attack;
            this._defencePower = defence;
            this._Dexterity = dextrity;

            this._MaxHP = maxhp;
            this._MaxMP = maxmp;
            this._MaxattackPower = maxattack;
            this._MaxdefencePower = maxdefence;
            this._MaxDexterity = maxdextrity;

            this._propattackPower = propattack;
            this._propdefencePower = propdefence;
            this._propDexterity = propdextrity;


        }
    }
}
