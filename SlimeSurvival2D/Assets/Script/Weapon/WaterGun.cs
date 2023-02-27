using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : Weapon
{     
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            collision.GetComponent<Enemy>().DecreaseHealth(RandomDamage(attackPower));
            WeaponPooling.instance.ReturnWaterGun(gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        StartCoroutine(StartDestroy());
    }
}
