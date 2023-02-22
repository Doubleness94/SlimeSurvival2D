using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunSpawner : MonoBehaviour
{
    public GameObject bullet;
    public float delay = 0.5f;
    public Transform pos;
    public float speed;

    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();        
    }

    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;

    }

    void Start()
    {
        StartCoroutine(StartAttack());
    }

    IEnumerator StartAttack()
    {
        while (true)
        {
            AttackWeapon();
            yield return new WaitForSeconds(delay);

        }
    }

    void AttackWeapon()
    {        
        GameObject weapon = WeaponPooling.instance.GetWaterGun();
        weapon.transform.position = pos.position;        
        weapon.transform.rotation = pos.rotation;
        Rigidbody2D weaponRigid = weapon.GetComponent<Rigidbody2D>();
        weaponRigid.velocity = pos.up * speed;
        audioSource.Play();
    }
}
