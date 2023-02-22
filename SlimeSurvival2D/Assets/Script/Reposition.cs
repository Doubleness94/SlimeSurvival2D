using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        /*
        float differX = Mathf.Abs(playerPos.x - myPos.x);
        float differY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1; 
        */
        
        float dirX = playerPos.x - myPos.x;
        float dirY = playerPos.y - myPos.y;

        float differX = Mathf.Abs(dirX);
        float differY = Mathf.Abs(dirY);

        dirX = dirX > 0 ? 1 : -1;
        dirY = dirY > 0 ? 1 : -1;
        

        switch (transform.tag)
        {
            case "Ground":
                if(differX > differY)
                {
                    transform.Translate(Vector3.right * dirX * 60);
                }
                else if (differX < differY)
                {
                    transform.Translate(Vector3.up * dirY * 60);
                }
                break;
            case "Enemy":

                break;
        }
    }
}
