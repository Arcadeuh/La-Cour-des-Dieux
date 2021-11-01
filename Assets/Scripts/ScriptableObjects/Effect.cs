using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Est l� uniquement pour �tre affich�
 */
[CreateAssetMenu(fileName = "NewEffect", menuName = "Effect")]

/* 
FONCTIONNEMENT DES EFFETS :
La classe effet est un scriptable object permettant d'assigner un string du nom de l'effet en 
particulier ainsi que quelques propriétés communes.
A chaque boucle de jeu, dans la fonction update, on vérifie l'attribut "effectName" pour appliquer 
la fonction correspondante si besoin est.

Certaines de ces fonctions ne snt cependant appelées qu'à la création de planètes.

Les propriétés communes sont décrites plus bas
*/


// La Classe Effect est abstraite : on créé directement chaque effets qui vont hériter de cette classe
public abstract class Effect : ScriptableObject
{
    public string title; // Nom de l'effet
    [TextArea] public string description; // Description brève de l'effet
    public EnumType type; // Type de l'effet
    public Color color; // Couleur associée à l'effet
    public Color textColor; // Couleur texte
    public EffectEnum effectName; // Effet qui hérite
    public short bounceNumber; // Attribut de rebondissement, décrémente selon le nombre de rebonds restant
}

[System.Serializable]
public enum EffectEnum
{
    Null,
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