using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ctrl
{
    public class Ctrl_DisplayHero : MonoBehaviour
    {
        public AnimationClip AniIdle;
        public AnimationClip AniRun;
        public AnimationClip AniAttack;
        private Animation currentAnimation;
        private float times = 3f;
        private int randomIndex = 0;
        // Use this for initialization
        void Start()
        {
            currentAnimation = GetComponent<Animation>();
        }
        /// <summary>
        /// 展示idle，run和attack这三个动作
        /// </summary>
        private void DisplayIdle()
        {
            if (currentAnimation)
            {
                currentAnimation.CrossFade(AniIdle.name);
            }
        }
        private void DisplayRun()
        {
            if (currentAnimation)
            {
                currentAnimation.CrossFade(AniRun.name);
            }
        }
        private void DisplayAttack()
        {
            if (currentAnimation)
            {
                currentAnimation.CrossFade(AniAttack.name);
            }
        }

        private void Update()
        {
            times -= Time.deltaTime;
            if (times<=0)
            {
                times = 3f;
                randomIndex = Random.Range(1, 4);
                DisplayAnim(randomIndex);
            }
        }

        private void DisplayAnim(int i)
        {
            switch (i)
            {
                case 1:
                    DisplayIdle();
                    break;
                case 2:
                    DisplayRun();

                    break;
                case 3:
                    DisplayAttack();
                    break;
        
            }
        }
    }
}
