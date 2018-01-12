using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ctrl
{
    public class Ctrl_Enemy : BaseControl
    {

        public float maxHP = 100f;
        public float curHP = 100f;
        public bool isAlive = true;
        public bool IsAlive
        {   get  {      return isAlive; }
            set {    isAlive = value; }
        }

        private void Awake()
        {
            
        }
        void Start()
        {
            curHP = maxHP;
        }
        private void Update()
        {
            
        }
        public  void   CheckAlive()
        {
            if (curHP<=0)
            {
                isAlive = false;
                //增加猪脚经验和杀敌数量
                DestroyThis();
            }
        }


        private void DestroyThis()
        {
            Destroy(this.gameObject);
        }
        public  void OnHurt(float  hurtValue)
        {
//Debug.Log("101010101010101010101010");
            curHP -= hurtValue;
            if (curHP<=0)
            {
                curHP = 0;
                isAlive = false;
                DestroyThis();
            }
        }
    }
}
