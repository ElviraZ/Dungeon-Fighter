/*
*响应玩家的点击处理
*
*
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;
using Kernal;
using Ctrl;
using Model;
namespace View
{
   public class View_PlayerInfoResponse : MonoBehaviour 
   {
        public GameObject playerDetailPanel;//玩家的详细信息面板
   
        private void Awake()
        {
            
        }
        // Use this for initialization
        void Start () 
	{
		
	}
public  void   DisplayDeatailPanel()
        {

            playerDetailPanel.SetActive(!playerDetailPanel.activeSelf);
        }
}
}