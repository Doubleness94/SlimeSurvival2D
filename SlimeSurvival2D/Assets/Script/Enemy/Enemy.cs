using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum Type {A,B};
    public Type enemyType;
    public Transform target;

    public bool isDead;
    //public GameObject[] crystals;

    public int speed;
    public int maxHealth;
    public int curHealth;
    public int attackPower;
    public int defencePower;

    Rigidbody2D rigid;
    SpriteRenderer sprite;
    CapsuleCollider2D col;
    Vector2 direction;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<CapsuleCollider2D>();
    }

    
    void FixedUpdate()
    {
        direction = (target.position - transform.position).normalized;
        if (!isDead)
            transform.Translate(direction.normalized * speed / 15f * Time.deltaTime);
        if(direction.x != 0)
        {
            sprite.flipX = direction.x < 0;
        }
    }

    public void LateUpdate()
    {
        FreezVelocity();
    }

    public void FreezVelocity()
    {
        rigid.velocity = Vector2.zero;
    }


    void KnockBack()
    {
        rigid.AddForce(direction * 2f, ForceMode2D.Impulse);
    }

    public void DecreaseHealth(int damage)
    {
        if(curHealth <= damage)
        {
            curHealth = 0;
            Die();
        }
        else
        {
            curHealth -= damage;
        }
        KnockBack();
    }

    public void Die()
    {
        DropCrystal();
        //킬카운트
        StartCoroutine(DieAnimation());
        rigid.velocity = Vector2.zero;
        EnemySpawner.instance.enemyCount--;

    }

    IEnumerator DieAnimation()
    {
        col.enabled = false;
        isDead = true;
        yield return new WaitForSeconds(0.1f);
        EnemyPooling.instance.ReturnEnemy(gameObject);
        gameObject.SetActive(false);
    }

    void DropCrystal()
    {
        GameObject crystal = CrystalPooling.instance.GetCrystal();
        crystal.transform.position = transform.position;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            GameManager.instance.player.DecreaseHp(attackPower);
    }
}
