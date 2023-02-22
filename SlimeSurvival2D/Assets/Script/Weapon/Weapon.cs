using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int attackPower;
    [SerializeField]
    protected int level;
    [SerializeField]
    protected float activeDelay;
    protected AudioSource audioSource;
    protected Rigidbody2D rigid;
    protected CircleCollider2D col;

    protected void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    public int RandomDamage(int damage)
    {
        int minDamage = (int)(damage * 0.8f);
        int maxDamage = (int)(damage * 1.2f);

        damage = Random.Range(minDamage, maxDamage + 1);
        return damage;
    }

    protected IEnumerator StartDestroy()
    {
        yield return new WaitForSeconds(activeDelay);
        WeaponPooling.instance.ReturnWaterGun(gameObject);
        this.gameObject.SetActive(false);

    }
}
