using System.Collections;
using System.Collections.Generic;

#region   项目的枚举
/// <summary>
/// 場景名稱
/// </summary>
public enum ScenesEnum
{
    StartScenes,
    LoadingScenes,
    LoginScenes,
    LevelOne,
    LevelTwo,
    BaseScenes

}
/// <summary>
/// 玩家的类型
/// </summary>
public enum PlayerType
{
    SwordHero,
    MagicHero,
    Other
}


/// <summary>
/// 主角的动作状态
/// </summary>
public enum HeroActionState
{
    None,
    Idle,
    Run,
    NormalAttack,
    MagicTrickA,
    MagicTrickB

}
/// <summary>
/// 普通攻击的连招
/// </summary>
public  enum NormalATKComboState
{
    NormalATK1,
    NormalATK2,
    NormalATK3
}



public  enum  LevelName
{
    Level_0=0,
    Level_1 = 1,
    Level_2 = 2,
    Level_3 = 3,
    Level_4 = 4,
    Level_5 = 5,
    Level_6 = 6,
    Level_7 = 7,
    Level_8 = 8,
    Level_9 = 9,
    Level_10 = 10
}
#endregion

#region   项目的委托  
/// <summary>
///  主角的控制委托
/// </summary>
/// <param name="controlType">控制的类型</param>
public delegate void DEL_playerControlWithStr(string controlType);



public delegate void DEL_PlayerKernalModel(KeyValueUpdate  kv);

public   class  KeyValueUpdate
{
    private string _key;
    private object _values;
    public string Key
    {
        get
        {
            return _key;
        }
    }
    public object Values
    {
        get
        {
            return _values;
        }
    }

    public KeyValueUpdate(string  key,object   value)
    {
        _key = key;
        _values = value;
    }
}
#endregion

#region 项目的标签
public  class  Tag
{
    public static string Enemy= "Enemy";

}
#endregion
public class GloabalParameter
{

    #region  系统的常量
 
    public const string JoystickName = "HeroJoystick";
    public const string NormalAttackInput= "NormalAttack";
    public const string MagicTrickAInput = "MagicTrickA";
    public const string MagicTrickBInput = "MagicTrickB";

    public const float waitfortime_0D1 = 0.1f;
    public const float waitfortime_0D2= 0.2f;
    public const float waitfortime_0D3 = 0.3f;
    public const float waitfortime_0D5 = 0.5f;
    public const float waitfortime_1 = 1f;
    public const float waitfortime_1D5 = 1.5f;
    public const float waitfortime_2 = 2f;
    public const float waitfortime_2D5= 2.5f;
    public const float waitfortime_3 = 3f;
    #endregion
    #region  系统的Tag
    

    #endregion
}
