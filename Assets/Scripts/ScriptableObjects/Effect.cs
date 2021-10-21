using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEffect", menuName = "Effect")]
public class Effect : ScriptableObject
{
    public string title;
    [TextArea] public string description;
    public EffectType type;
    public Color color;
    public Color textColor;
    public EffectEnum effectEnum;
}

[System.Serializable]
public enum EffectEnum
{
    Neutral,
    //actives choosen
    Water,
    ZigZag,
    Bouncing,
    Flash,
    Grenade,
    //passives choosen
    Reflect,
    Slow,
    Shield,
    RussianDoll,
    Moving
}

[System.Serializable]
public enum EffectType
{ 
    Active,
    Passive,
    ActivePassive
}