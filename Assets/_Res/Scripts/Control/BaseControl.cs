using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Global;
using Ctrl;
/// <summary>
/// 控制层的总父类，提取控制层的公共部分
/// </summary>
public class BaseControl : MonoBehaviour 
{

    /// <summary>
    /// 进入下一个场景，scenesEnumName为场景的枚举
    /// </summary>
    /// <param name="scenesEnumName"></param>
    protected void  EnterNextScenes(ScenesEnum  scenesEnumName)
    {
        GlobalParameterManager.NextScenesName = scenesEnumName;
        SceneManager.LoadScene(ConvertEnumToStr.GetInstance().GetStrByEnumScenes(ScenesEnum.LoadingScenes));


    }

}
