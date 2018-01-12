using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Global;
using Kernal;
/// <summary>
/// 主角的动画控制
/// </summary>
namespace Ctrl
{
    public class Ctrl_HeroAnimationCtrl : BaseControl
    {
        public static Ctrl_HeroAnimationCtrl _Instance;
        public AnimationClip AniIdle, AniRun, AninormalAttack1, AninormalAttack2, AninormalAttack3, AniMagicTrickA, AniMagicTrickB;

        private HeroActionState curActionState = HeroActionState.None;
        private Animation animHandle;
        private NormalATKComboState curATKState = NormalATKComboState.NormalATK1;
        //动画单次开关
        private bool isSinglePlay = true;

        public HeroActionState CurActionState
        {
            get
            {
                return curActionState;
            }

       
        }

        private void Awake()
        {
            _Instance = this;
            animHandle = GetComponent<Animation>();
        }
        // Use this for initialization
        void Start()
        {
            //默认动作状态
            curActionState = HeroActionState.Idle;
            StartCoroutine("ControlHeroAnimationState");
            //加快连招的速度
            animHandle[AninormalAttack1.name].speed = 2.5f;
            animHandle[AninormalAttack2.name].speed = 2.5f;
            animHandle[AninormalAttack3.name].speed = 2f;
        }
        /// <summary>
        /// 设置当前的动画状态
        /// </summary>
        public void SetCurActionState(HeroActionState state)
        {
            curActionState = state;
        }
        /// <summary>
        /// 主角的动画控制
        /// </summary>
        private IEnumerator ControlHeroAnimationState()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f);
                switch (curActionState)
                {
                    case HeroActionState.None:
                        break;
                    case HeroActionState.Idle:
                        animHandle.CrossFade(AniIdle.name);
                        break;
                    case HeroActionState.Run:
                        animHandle.CrossFade(AniRun.name);
                        break;
                    case HeroActionState.NormalAttack:
                        //连招处理
                        switch (curATKState)
                        {
                            case NormalATKComboState.NormalATK1:
                            
                                curATKState = NormalATKComboState.NormalATK2;
                                if (isSinglePlay)
                                {
                                    animHandle.CrossFade(AninormalAttack1.name);
                                    isSinglePlay = false;
                                    yield return new WaitForSeconds(AninormalAttack1.length/2.5f);
                                }
                                else
                                    StartCoroutine(ReturnToIdle());
                            
                                break;
                            case NormalATKComboState.NormalATK2:
                                curATKState = NormalATKComboState.NormalATK3;
                                if (isSinglePlay)
                                {
                                    animHandle.CrossFade(AninormalAttack2.name);
                                    isSinglePlay = false;
                                    yield return new WaitForSeconds(AninormalAttack2.length/2.5f);
                                }
                                else
                                    StartCoroutine(ReturnToIdle());
                                break;
                            case NormalATKComboState.NormalATK3:
                                curATKState = NormalATKComboState.NormalATK1;
                                if (isSinglePlay)
                                {
                                    animHandle.CrossFade(AninormalAttack3.name);
                                    isSinglePlay = false;
                                    yield return new WaitForSeconds(AninormalAttack3.length/2f);
                                }
                                else
                                    StartCoroutine(ReturnToIdle());
                                break;
                            default:
                                break;
                        }
                        if (isSinglePlay)
                        {
                            animHandle.CrossFade(AninormalAttack1.name);
                            isSinglePlay = false;
                            yield return new WaitForSeconds(AninormalAttack1.length);
                        }
                        else
                            StartCoroutine(ReturnToIdle());
                        break;
                    case HeroActionState.MagicTrickA:
                        if (isSinglePlay)
                        {
                            animHandle.CrossFade(AniMagicTrickA.name);
                            isSinglePlay = false;
                            yield return new WaitForSeconds(AniMagicTrickA.length);
                        }
                        else
                            StartCoroutine(ReturnToIdle());
                        break;
                    case HeroActionState.MagicTrickB:
                        if (isSinglePlay)
                        {
                            animHandle.CrossFade(AniMagicTrickB.name);
                            isSinglePlay = false;
                            yield return new WaitForSeconds(AniMagicTrickB.length);
                        }
                        else
                            StartCoroutine(ReturnToIdle());
                        break;
                    default:
                        break;
                }

            }
        }


        private IEnumerator ReturnToIdle()
        {

            curActionState = HeroActionState.Idle;
            yield return new WaitForSeconds(0.05f);
            isSinglePlay = true;
        }
    }

}