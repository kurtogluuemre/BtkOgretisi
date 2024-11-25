using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class DataManager : MonoBehaviour
{
    private int enemyKilled;
    private int shootBullet;

    public int totalEnemyKilled;
    public int totalShootBullet;

    public static DataManager instance;

    EasyFileSave myFile;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int EnemyKilled
    {
        get
        {
            return enemyKilled;
        }
        set 
        {
            enemyKilled = value;
            GameObject.Find("EnemyKilledText").GetComponent<Text>().text = "EnemyKilled :  " + enemyKilled.ToString();
            WinProcess();
        }
    }

    public int ShootBullet
    {
        get
        {
            return shootBullet;
        }

        set
        {
            shootBullet = value;
            GameObject.Find("ShotBulletText").GetComponent<Text>().text = "SHOT BULLET :  " + shootBullet.ToString();
        }
    }

    void StartProcess()
    {
        myFile = new EasyFileSave();
        LoadData();
    }

    public void SaveData()
    {
        totalEnemyKilled += enemyKilled;
        totalShootBullet += shootBullet;

        myFile.Add("totalShootBullet", totalShootBullet);
        myFile.Add("totalEnemyKilled", totalEnemyKilled);

        myFile.Save();
    }

    public void LoadData()
    {
        if (myFile.Load())
        {
            totalEnemyKilled = myFile.GetInt("totalEnemyKilled");
            totalShootBullet = myFile.GetInt("totalShootBullet");
        }
    }

    public void WinProcess()
    {
        if(enemyKilled >= 5)
        {
            print("KAZANDIN");
        }
    }

    public void LoseProcess()
    {
        print("Kaybettiniz");
    }
}
