using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Kernal;
using Global;
namespace Model
{
    /// <summary>
    /// 玩家的额外数据
    /// </summary>
    public class Model_PlayerExtendData 
    {
        public static event DEL_PlayerKernalModel evePlayerExtendData;

        private int _EXP;
        private int _KillNum;
        private int _Level;
        private int _Gold;
        private int _Diamonds;

        private Model_PlayerExtendData()
        { }
        public Model_PlayerExtendData(int exp, int killnum, int level, int gold, int diamonds)
        {
            _EXP = exp;
            _KillNum = killnum;
            _Level = level;
            _Gold = gold;
            _Diamonds = diamonds;
        }

        public int EXP
        {
            get
            {
                return _EXP;
            }
            set
            {
                _EXP = value;
                if (evePlayerExtendData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("EXP", EXP);
                    evePlayerExtendData(kv);
                }
            }
        }
        public int KillNum
        {
            get
            {
                return _KillNum;
            }
            set
            {
                _KillNum = value;
                if (evePlayerExtendData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("KillNum", EXP);
                    evePlayerExtendData(kv);
                }
            }
        }
        public int Level
        {
            get
            {
                return _Level;
            }
            set
            {
                _Level = value;
                if (evePlayerExtendData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Level", Level);
                    evePlayerExtendData(kv);
                }
            }
        }
        public int Gold
        {
            get
            {
                return _Gold;
            }
            set
            {
                _Gold = value;
                if (evePlayerExtendData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Gold", Gold);
                    evePlayerExtendData(kv);
                }
            }
        }
        public int Diamonds
        {
            get
            {
                return _Diamonds;
            }
            set
            {
                _Diamonds = value;
                if (evePlayerExtendData != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Diamonds", Diamonds);
                    evePlayerExtendData(kv);
                }
            }
        }
    }
}
