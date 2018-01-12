using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
namespace Global
{
    public class FadeInAndOut : MonoBehaviour
    {
        public static FadeInAndOut _Instance;
        public RawImage rawImage;
        //颜色的变化时间
        float colorChangeSpeedClear = 1f;
        float colorChangeSpeedBlack = 5f;
        private bool toClear = true;//逐渐清晰
        private bool toBlack = false;//逐渐黑
        private void Awake()
        {
            _Instance = this;
            rawImage = GameObject.Find("rawImage").GetComponent<RawImage>();
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (toClear)
            {
                ScenesToClear();

            }
            else if (toBlack)
            {
                ScenesToBlack();
            }
        }
        /// <summary>
        /// 屏幕 淡入(逐渐清晰 )
        /// </summary>
        void FadeToClear()
        {
            rawImage.color = Color.Lerp(rawImage.color, Color.clear, colorChangeSpeedClear * Time.deltaTime);
        }
        /// <summary>
        /// 屏幕淡出（逐渐黑）
        /// </summary>
        void FadeToBank()
        {
            rawImage.color = Color.Lerp(rawImage.color, Color.black, colorChangeSpeedBlack * Time.deltaTime);
        }
        /// <summary>
        /// 屏幕 淡入(逐渐清晰 )
        /// </summary>
        void ScenesToClear()
        {
         
            FadeToClear();
            if (rawImage.color.a <= 0.05f)
            {
                toClear = false;
                rawImage.color = Color.clear;
                rawImage.raycastTarget = false;
            }
        }
        /// <summary>
        /// 屏幕淡出（逐渐黑）
        /// </summary>
        void ScenesToBlack()
        {
            rawImage.gameObject.SetActive(true);
            FadeToBank();
            if (rawImage.color.a >= 0.95f)
            {
                toBlack = false;
                rawImage.color = Color.black;
                rawImage.raycastTarget = true;
            }
        }


        public void SetSceneToClear()
        {
            toClear = true;
            toBlack = false;
        }
        public void SetSceneToBlack()
        {
            toClear = false;
            toBlack = true;
        }
    }


}