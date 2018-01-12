using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Global;
/// <summary>
/// Ctrl：开始场景
/// </summary>
namespace Ctrl
{
    public class Ctrl_StartScenes : BaseControl
    {
        public static Ctrl_StartScenes _Instance;
        private void Awake()
        {
            _Instance = this;
        }

        public void NewGameBtnClick()
        {

            StartCoroutine(EnterNext());

        }
        public void ContinueGameBtnClick()
        {
            Debug.Log(GetType() + "          Continue");
        }
        IEnumerator  EnterNext()
        {
            AudioManager.instance.PlayFX("ButtonClickA");
            FadeInAndOut._Instance.SetSceneToBlack();
            yield return new WaitForSeconds(1f);
            // GlobalParameterManager.NextScenesName = ScenesEnum.LoginScenes;
            //SceneManager.LoadScene(ConvertEnumToStr.GetInstance().GetStrByEnumScenes(ScenesEnum.LoadingScenes));
            base.EnterNextScenes(ScenesEnum.LoginScenes);
        }
    }
}
