using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    public WeaponData weapon;
    public int weaponLevel;
    public Image weaponImage;

    [SerializeField]
    private Text text_Level;

    
    void Start()
    {
        if (weapon != null)
            AddWeapon(weapon);
    }

    void Update()
    {
        WeaponLevel();
    }


    public void AddWeapon(WeaponData _weapon, int _level = 1)
    {
        weapon = _weapon;
        weaponLevel = _level;
        weaponImage.sprite = weapon.weaponSprite;
        text_Level.text = weaponLevel.ToString();
        SetColor(1);
        GameManager.instance.player.isSelect = false;

    }

    public void SetSlotCount(int _level)
    {
        weaponLevel += _level;
        text_Level.text = weaponLevel.ToString();
        GameManager.instance.player.isSelect = false;

        if (weaponLevel <= 0)
            ClearSlot();
    }

    private void ClearSlot()
    {
        weapon = null;
        weaponLevel = 0;
        weaponImage.sprite = null;
    }

    private void SetColor(float _alpha)
    {
        Color color = weaponImage.color;
        color.a = _alpha;
        weaponImage.color = color;
    }

    private void WeaponLevel()
    {
        if(weapon != null)
        {
            if (weapon.weaponType == WeaponData.WeaponType.WaterGun)
            {
                if (weaponLevel == 1)
                    GameManager.instance.waterGun.delay = 0.5f;
                else if (weaponLevel == 2)
                    GameManager.instance.waterGun.delay = 0.4f;
                else if (weaponLevel == 3)
                    GameManager.instance.waterGun.delay = 0.3f;
                else if (weaponLevel == 4)
                    GameManager.instance.waterGun.delay = 0.2f;
            }

            if (weapon.weaponType == WeaponData.WeaponType.Twister)
            {
                if (weaponLevel == 1)
                    GameManager.instance.twister.twister_1.SetActive(true);
                else if (weaponLevel == 2)
                    GameManager.instance.twister.twister_2.SetActive(true);
                else if (weaponLevel == 3)
                    GameManager.instance.twister.twister_3.SetActive(true);
                else if (weaponLevel == 4)
                    GameManager.instance.twister.twister_4.SetActive(true);
            }
        }        
    }
}
