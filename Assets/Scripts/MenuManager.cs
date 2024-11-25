using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject dataBoard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton ()
    {
        SceneManager.LoadScene(1);
    }

    public void DataBoardButton()
    {
        DataManager.instance.LoadData();

        dataBoard.transform.GetChild(1).GetComponent<Text>().text = "Toplam atýlan shuringen : " + DataManager.instance.totalShootBullet.ToString();
        dataBoard.transform.GetChild(2).GetComponent<Text>().text = "Toplam öldürülen düþman : " + DataManager.instance.totalEnemyKilled.ToString();
        dataBoard.SetActive(true);
    }

    public void XButton()
    {
        dataBoard.SetActive(false);
    }
}
