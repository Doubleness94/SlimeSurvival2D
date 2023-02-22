using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    ItemType itemType;


    public enum ItemType
    {
        skull,
        etc
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch (itemType)
            {
                case ItemType.skull:
                    GameManager.instance.player.IncreaseHp(50);
                    gameObject.SetActive(false);
                    break;
                case ItemType.etc:

                    break;
            }            
        }
    }
}
