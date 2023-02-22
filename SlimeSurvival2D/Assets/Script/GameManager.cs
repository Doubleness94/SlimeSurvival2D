using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;    

    public Player player;
    public Inventory inventory;
    public WaterGunSpawner waterGun;
    public TwisterOrbit twister;

    //UI    
    [SerializeField]
    private RectTransform Hp_Bar;
    [SerializeField]
    private RectTransform Exp_Bar;
    [SerializeField]
    private Text level_Txt;
    [SerializeField]
    private GameObject select_Weapon;
    [SerializeField]
    private GameObject gameMenu;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameObject gameClear;
    [SerializeField]
    private Text timer;    
    public float timeMax;
    [SerializeField]
    private Text record;

    public bool isPause;
    private bool isEnded;

    //타이머
    float sec;
    int min;
    
    


    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        ResetTime();
    }


    void Update()
    {
        if(player != null)
        {
            LevelUp();
            CheckTime();
        }
            


        if(!isPause && Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = true;
        }

    }

    void LateUpdate()
    {
        if (player != null)
        {
            GameStop();
            LevelGroup();
            HpBar();
            GameMenu();
            GameOver();
            GameClear();
        }
            
    }

    void GameStop()
    {
        if (player.isSelect || player.isDead || isPause ||isEnded)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    
    void LevelUp()
    {
        if (player.isSelect)
            select_Weapon.gameObject.SetActive(true);
        else
            select_Weapon.gameObject.SetActive(false);
    }

    private void LevelGroup()
    {
        level_Txt.text = "Lv : " + player.level;
        Exp_Bar.localScale = new Vector3((float)player.curExp / player.maxExp, 1, 1);
        float perExp = ((float)player.curExp / (float)player.maxExp) * 100;
    }

    private void HpBar()
    {
        Hp_Bar.localScale = new Vector3((float)player.curHealth / player.maxHealth, 1, 1);
        float perHp = ((float)player.curHealth / (float)player.maxHealth * 100);
    }

    public void GameMenu()
    {
        if (isPause)
            gameMenu.SetActive(true);
        else
            gameMenu.SetActive(false);
    }

    public void GameOver()
    {
        if (player.isDead)
        {
            gameOver.SetActive(true);
            record.text = string.Format("기록 : "+"{0:00}:{1:00}", min, (int)sec);
        }
    }

    public void GameClear()
    {
        if (isEnded)
        {
            gameClear.SetActive(true);
            record.text = string.Format("기록 : " + "{0:00}:{1:00}", min, (int)sec);
        }
    }

    public void CheckTime()
    {
        sec += Time.deltaTime;
            

        if ((int)sec > 59)
        {
            sec = 0;
            min++;
        }

        if (min == timeMax && (int)sec == 0)
        {
            isEnded = true;
        }

        timer.text = string.Format("{0:00}:{1:00}", min, (int)sec);

    }
    public void ResetTime()
    {
        sec = 0;
        min = 0;
        isEnded = false;
        Debug.Log("Start");
    }

}
