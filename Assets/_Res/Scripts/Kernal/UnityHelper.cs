using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 幫助类
/// </summary>
namespace Kernal
{
    public class UnityHelper 
    {
        public static UnityHelper _Instance=null;
        private UnityHelper  ()
        {

        }
        public  static   UnityHelper  GetInstance()
        {
            if (_Instance==null)
                _Instance = new UnityHelper ();
            return _Instance;
        }
        float deltaTime;
        public bool    GetSmallTime(float  delta)
        {
            deltaTime += Time.deltaTime;
            if (deltaTime>=delta)
            {
                deltaTime = 0;
                return true;
            }
            else
            {
                return false; 
            }
        }
   
    }
}
