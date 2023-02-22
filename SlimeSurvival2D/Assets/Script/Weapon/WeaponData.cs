using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Select Data", menuName = "Scriptable Object/Select Data", order = int.MaxValue)]
public class WeaponData : ScriptableObject
{
    public enum WeaponType
    {
        WaterGun,
        Twister,
        Meat
    }

    
    public WeaponType weaponType;
    public int attackPower;
    public float activeDelay;
    public Sprite weaponSprite;
    public string description;

}
