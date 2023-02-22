using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUP : MonoBehaviour
{
    public WeaponData weapon;
    public Text weaponName;
    public Image weaponImage;
    public Text weaponDesc;


    private void Start()
    {
        if (weapon != null)
            AddItem(weapon);
    }

    public void AddItem(WeaponData _weapon, int _level =1)
    {
        weapon = _weapon;
        weaponName.text = weapon.weaponType.ToString();
        weaponImage.sprite = weapon.weaponSprite;
        weaponDesc.text = weapon.description;
    }

    public void SelectItem()
    {
        GameManager.instance.inventory.AcquireWeapon(weapon);        
    }

    public void SelectMeat()
    {
        GameManager.instance.player.IncreaseHp(100);
        GameManager.instance.player.isSelect = false;
    }

}
