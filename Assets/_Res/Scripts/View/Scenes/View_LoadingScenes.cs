

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// View:場景加载
/// </summary>

public class View_LoadingScenes : MonoBehaviour 
{
   private  AsyncOperation async;
    public float imageFill;
    private void Awake()
    {
        imageFill = GameObject.Find("Float").GetComponent<Image>().fillAmount;
    }
    // Use this for initialization
    void Start () 
	{
        StartCoroutine(LoadScenesProgerss());
	}
	
	// Update is called once per frame
	void Update ()
	{
        imageFill = async.progress;
	}

    IEnumerator   LoadScenesProgerss()
    {
    
      async=  SceneManager.LoadSceneAsync(ConvertEnumToStr.GetInstance().GetStrByEnumScenes(GlobalParameterManager.NextScenesName));
    yield return async;
    }
}
