using UnityEngine;
public class BaseAttribute
{
    public static string name;
    public static int hp;
    public static int mp;
    public static int level = 1;//等级
    public static int exp = 0;//当前拥有的经验值
    public static int exp2LevelUp;

    public static int maatk;//魔法攻击力
    public static int madef;//魔法防御力
    public static int atk;//物理攻击力
    public static int def;//物理防御力
    public static float crirRate = 0.2f;//暴击几率
    public static float crirRatio = 1.5f;//暴击伤害比率(造成普通攻击n倍伤害)

    public static int vit = 1;//体质
    public static int str = 1;//力量
    public static int spr = 1;//精神
    public static int inte = 1;//智力
    public static int sta = 1;//耐力

    public static float atk_range = 1;//物理攻击范围
    public static float atk_cd = 1;//物理攻击内置cd
    public static float speed = 0.05f;//移动速度
    public static float jumpHeight = 10;//跳跃高度

}

