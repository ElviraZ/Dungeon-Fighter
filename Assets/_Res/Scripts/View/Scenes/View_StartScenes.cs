using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ctrl;
/// <summary>
/// View：开始场景
/// </summary>
namespace View
{
    public class View_StartScenes : MonoBehaviour
    {
        public static View_StartScenes _Instance;
        public Button NewGameBtn, ContinueGameBtn;
        private void Awake()
        {
            _Instance = this;
            NewGameBtn = GameObject.Find("NewGameBtn").GetComponent<Button>();
            ContinueGameBtn = GameObject.Find("ContinueGameBtn").GetComponent<Button>();


            NewGameBtn.onClick.AddListener(NewGameBtnClick);
            ContinueGameBtn.onClick.AddListener(ContinueGameBtnClick);
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void NewGameBtnClick()
        {
            Ctrl_StartScenes._Instance.NewGameBtnClick();

        }
        public void ContinueGameBtnClick()
        {
            Ctrl_StartScenes._Instance.ContinueGameBtnClick();
        }
    }
}
