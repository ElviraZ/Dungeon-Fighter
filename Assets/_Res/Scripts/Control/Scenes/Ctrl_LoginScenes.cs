
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Ctrl
{

    public class Ctrl_LoginScenes : BaseControl
    {

        public static Ctrl_LoginScenes _Instance;
        private void Awake()
        {
            _Instance = this;
        }
        public void ShowMagicHero()
        {
            AudioManager.instance.PlayFX("2_FireBallEffect_MagicHero");

        }

        public void ShowSwordHero()
        {
            AudioManager.instance.PlayFX("1_LightSword_SwordHero");
        }
        public void EnterNextScenes()
        {

            // GlobalParameterManager.NextScenesName = ScenesEnum.LevelOne;
            //SceneManager.LoadScene(ConvertEnumToStr.GetInstance().GetStrByEnumScenes(ScenesEnum.LoadingScenes));
            base.EnterNextScenes(ScenesEnum.LevelOne);
        }
    }
}