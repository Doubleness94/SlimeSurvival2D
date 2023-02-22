using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{    
    [SerializeField]
    private GameObject slotParent;

    private Slot[] slots;

    void Start()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();        
    }

    public void AcquireWeapon(WeaponData _weapon, int _level = 1)
    {
        //���� ������
        for(int i = 0; i < slots.Length; i++)
        {
            if(slots[i].weapon != null)
            {
                if (slots[i].weapon.weaponType == _weapon.weaponType)
                {
                    if(slots[i].weaponLevel >= 4)
                    {
                        Debug.Log("�ִ� �����Դϴ�");
                        return;                        
                    }
                    slots[i].SetSlotCount(_level);                    
                    return;
                }
            }
        }

        //���� �߰�
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].weapon == null)
            {
                slots[i].AddWeapon(_weapon, _level);
                return;
            }
        }
    }
}
