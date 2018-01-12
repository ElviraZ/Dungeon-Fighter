using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kernal;
using Global;
/// <summary>
/// 控制层：使用键盘移動
/// </summary>
namespace Ctrl
{
    public class Ctrl_HeroMovingByKey : BaseControl
    {
        private CharacterController cc;
        //重力
        private float gravity = 0.98f;
        public float MoveSpeed = 5f;
        private void Start()
        {
            cc = GetComponent<CharacterController>();
        }
        private void Update()
        {
            ControlMoving();
        }

        /// <summary>
        /// 控制移动 
        /// </summary>
        /// <param name="move"></param>
        void ControlMoving()
        {
            float h = Input.GetAxis("Horizontal");//x
            float v = Input.GetAxis("Vertical");//y
            if (h != 0 || v != 0)
            {
                transform.LookAt(new Vector3(transform.position.x - h, transform.position.y, transform.position.z - v));
                //transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
                //增加重力

                Vector3 movement = transform.forward * Time.deltaTime * MoveSpeed;
                movement.y -= gravity;
                cc.Move(movement);
                if (UnityHelper.GetInstance().GetSmallTime(0.1f))
                {
                    Ctrl_HeroAnimationCtrl._Instance.SetCurActionState(HeroActionState.Run);

                }


            }
            else
            {
                if (UnityHelper.GetInstance().GetSmallTime(0.2f))
                {
Ctrl_HeroAnimationCtrl._Instance.SetCurActionState(HeroActionState.Idle);
                }
               // 

            }

        }
    }
}