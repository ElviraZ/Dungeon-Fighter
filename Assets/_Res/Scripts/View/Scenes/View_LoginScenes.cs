using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Global;
using Ctrl;
using System;

namespace View
{
    public class View_LoginScenes : MonoBehaviour
    {
         GameObject swordHero, magicHero, swordinfo, maginInfo;

         Button swordBtn, magicBtn, submitBtn;
       
         InputField inputfield;
        private void Awake()
        {
            swordHero = GameObject.Find("SwordHero");
            magicHero = GameObject.Find("MagicHero");

            swordinfo = GameObject.Find("SwordInfo");
            maginInfo = GameObject.Find("MagicInfo");

            inputfield = GameObject.Find("InputField").GetComponent<InputField>();
            swordBtn = GameObject.Find("SwordBtn").GetComponent<Button>();
            magicBtn = GameObject.Find("MagicBtn").GetComponent<Button>();
            submitBtn = GameObject.Find("SubmitBtn").GetComponent<Button>();
            swordBtn.onClick.AddListener(ShowSwordHero);
            magicBtn.onClick.AddListener(ShowMagicHero);
            submitBtn.onClick.AddListener(SubmitClick);

            ShowSwordHero();
        }

        private void SubmitClick()
        {
            // 获得输入的名字
            GlobalParameterManager.PlayerName = inputfield.text;

            Ctrl_LoginScenes._Instance.EnterNextScenes();
        }

        private void ShowMagicHero()
        {
            magicHero.SetActive(true);
            maginInfo.SetActive(true);
            swordHero.SetActive(false);
            swordinfo.SetActive(false);
            GlobalParameterManager.playerType = PlayerType.MagicHero;
        }

        private void ShowSwordHero()
        {
            magicHero.SetActive(false);
            maginInfo.SetActive(false);
            swordHero.SetActive(true);
            swordinfo.SetActive(true);
            GlobalParameterManager.playerType = PlayerType.SwordHero;
           
        }

    }
}
