using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twister : Weapon
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.GetComponent<Enemy>().DecreaseHealth(RandomDamage(attackPower));
            audioSource.Play();
                
        }
    }
}
