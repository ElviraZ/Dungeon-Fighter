using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 将枚举转换成字符
/// </summary>
public class ConvertEnumToStr  
{
    private static ConvertEnumToStr _Instance;
    Dictionary<ScenesEnum, string> scenesEnumLib;
    private ConvertEnumToStr()
    {
        scenesEnumLib = new Dictionary<ScenesEnum, string>();
        scenesEnumLib.Add(ScenesEnum.StartScenes, "1_StartScenes");
        scenesEnumLib.Add(ScenesEnum.LoginScenes, "2_LoginScenes");
        scenesEnumLib.Add(ScenesEnum.LoadingScenes, "LoadingScenes");
        scenesEnumLib.Add(ScenesEnum.LevelOne, "3_LevelOne");
        scenesEnumLib.Add(ScenesEnum.LevelTwo, "4_LevelTwo");
        scenesEnumLib.Add(ScenesEnum.BaseScenes, "BaseScenes");
    }
    public static  ConvertEnumToStr GetInstance()
    {
        if (_Instance==null)
        {
            _Instance = new ConvertEnumToStr();
        }

        return _Instance;
      
    }
    public  string  GetStrByEnumScenes(ScenesEnum  scenesEnum)
    {
        if (scenesEnumLib!=null&&scenesEnumLib.Count>=1)
        {
            return scenesEnumLib[scenesEnum];

        }
        else
        {
            return null;
        }
    }
}
