using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField]
    CrystalType crystalType;
    [SerializeField]
    int expValue;

    public enum CrystalType
    {
        Red,
        Green,
        Blue
    }    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.instance.player.IncreaseExp(expValue);
            CrystalPooling.instance.ReturnCrystal(gameObject);
        }
        
    }
}
