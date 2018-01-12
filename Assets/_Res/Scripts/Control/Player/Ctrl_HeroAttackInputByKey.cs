using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kernal;
using Global;
/// <summary>
/// 主角攻击输入：键盘
/// </summary>
namespace Ctrl
{
    public class Ctrl_HeroAttackInputByKey : BaseControl
    {
        public static event DEL_playerControlWithStr evePlayerControl;
  
        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown(GloabalParameter.NormalAttackInput)    )
            {
                if (evePlayerControl!=null)
                {
                    evePlayerControl(GloabalParameter.NormalAttackInput);
                }
            }
            else if (Input.GetButtonDown(GloabalParameter.MagicTrickAInput))
            {
            
                if (evePlayerControl != null)
                {
                    evePlayerControl(GloabalParameter.MagicTrickAInput);
                }
            }
            else if (Input.GetButtonDown(GloabalParameter.MagicTrickBInput))
            {
                if (evePlayerControl != null)
                {
                    evePlayerControl(GloabalParameter.MagicTrickBInput);
                }
            }
        }
    }
}
