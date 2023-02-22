using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{    
    public int speed;
    public int maxHealth;
    public int curHealth;
    int defencePower;
    public int maxExp;
    public int curExp;
    public int level;

    public bool isDead;
    public bool isSelect;
    public Vector2 inputVec;
    Rigidbody2D rigid;
    public SpriteRenderer sprite;
    public Animator anim;
    Collider2D col;
    public ParticleSystem particle;
    AudioSource audioSource;
    

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!isDead && !isSelect)
            Move();
        if (isSelect)
        {
            inputVec = Vector2.zero;
        }
    }    

    void FixedUpdate()
    {
        Vector2 moveVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);
           
    }

    void Move()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void LateUpdate()
    {        
        if(inputVec.x != 0)
        {
            sprite.flipX = inputVec.x < 0;
        }
        anim.SetBool("isWalk", inputVec != Vector2.zero);
    }

    public void IncreaseHp(int amount)
    {
        if (curHealth + amount >= maxHealth)
            curHealth = maxHealth;
        else
        {
            curHealth += amount;
        }
    }

    public void DecreaseHp(int damage)
    {
        if(curHealth <= damage)
        {
            curHealth = 0;
            isDead = true;            
        }
        else
        {
            curHealth -= damage;
            particle.Play();
        }
    }

    public void IncreaseExp(int amount)
    {
        if(curExp+amount >= maxExp)
        {
            curExp = curExp + amount - maxExp;
            maxExp = maxExp * 2;
            LevelUp();
        }
        else
        {
            curExp += amount;
        }
    }

    public void LevelUp()
    {
        level++;
        isSelect = true;
        audioSource.Play();
    }
    
}
