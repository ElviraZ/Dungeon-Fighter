using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Global;
using Kernal;
/// <summary>
/// 控制层：使用EasyTouch对主角进行移动控制
/// </summary>

namespace Ctrl
{
    public class Ctrl_HeroMovingByET : BaseControl
    {
       

        private CharacterController cc;
        //重力
        private float gravity = 0.98f;
        public float MoveSpeed=5f;
        private void Start()
        {
            cc = GetComponent<CharacterController>();
        }
        #region  事件的注册
        void OnEnable()
        {
            EasyJoystick.On_JoystickMove += On_JoystickMove;
            EasyJoystick.On_JoystickMoveEnd += On_JoystickMoveEnd;
        }

        void OnDisable()
        {
            EasyJoystick.On_JoystickMove -= On_JoystickMove;
            EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
        }

        void OnDestroy()
        {
            EasyJoystick.On_JoystickMove -= On_JoystickMove;
            EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
        }
#endregion

        /// <summary>
        /// 移动摇杆
        /// </summary>
        /// <param name="move"></param>
     void On_JoystickMove(MovingJoystick move)
        {
            if (move.joystickName != GloabalParameter.JoystickName)
                return;
            float joyPositionX = move.joystickAxis.x;
            float joyPositionY = move.joystickAxis.y;
            if (joyPositionX!=0||joyPositionY!=0)
            {
                transform.LookAt(new Vector3(transform.position.x - joyPositionX, transform.position.y, transform.position.z - joyPositionY));
                //transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
                //增加重力

                Vector3 movement = transform.forward * Time.deltaTime * MoveSpeed;
                movement.y -= gravity;
                cc.Move(movement);
                if (UnityHelper.GetInstance().GetSmallTime(0.1f))
                {
                Ctrl_HeroAnimationCtrl._Instance.SetCurActionState(HeroActionState.Run);

                }
               // GetComponent<Animation>().CrossFade(AniRun.name);

            }
      
        }
        /// <summary>
        /// 摇杆移动结束
        /// </summary>
        /// <param name="move"></param>
        void On_JoystickMoveEnd(MovingJoystick move)
        {
            if (move.joystickName == GloabalParameter.JoystickName)
            {
                Ctrl_HeroAnimationCtrl._Instance.SetCurActionState(HeroActionState.Idle);
                //GetComponent<Animation>().CrossFade(AniIdle.name);
            }
        }
   

    }
}