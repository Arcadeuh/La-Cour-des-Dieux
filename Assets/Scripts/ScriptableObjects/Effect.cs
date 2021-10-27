using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEffect", menuName = "Effect")]

// La Classe Effect est abstraite : on créé directement chaque effets qui vont hériter de cette classe
public abstract class Effect : ScriptableObject
{
    public string title; // Nom de l'effet
    [TextArea] public string description; // Description brève de l'effet
    public EnumType type; // Type de l'effet
    public Color color; // Couleur associée
    public Color textColor; // Couleur texte
    public EffectEnum effectEnum; // Effet qui hérite
    public bool canBounce;
}

[System.Serializable]
public enum EffectEnum
{
    Neutral,
    //actives choosen
    Big, // Planète + grosse
    Water,
    ZigZag,
    Bouncing,
    Flash,
    Grenade,
    //passives choosen
    BigPassive, // Planète + grosse passif
    Reflect,
    Slow,
    Shield,
    RussianDoll,
    Moving
}

[System.Serializable]
public enum EnumType
{ 
    Active,
    Passive,
    ActivePassive
}