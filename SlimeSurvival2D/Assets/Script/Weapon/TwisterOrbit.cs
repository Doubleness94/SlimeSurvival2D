using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwisterOrbit : MonoBehaviour
{
    //공전
    [SerializeField]
    Transform player;
    const float speed = 200f;
    Vector3 offSet;

    //무기
    public GameObject twister_1;
    public GameObject twister_2;
    public GameObject twister_3;
    public GameObject twister_4;


    private void Update()
    {
        transform.position = player.position + offSet;
        transform.RotateAround(player.position, Vector3.back, speed * Time.deltaTime);
        offSet = transform.position - player.position;
    }

    public void ItemLevel()
    {

    }
}
