using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
  
    public GameObject RabbitPrefab;
    public GameObject MyGold;
    public GameObject MyRound;
    public GameManager gameManager;

    void Start()
    {
        //게임매니저를 싱글톤으로 불러온다.
        this.gameManager = GameManager.getInstance();
        MyRound.GetComponent<Text>().text = "Round " + gameManager.round.ToString();
        
        // 토끼객체를 계속 생성하는 메소드 호출. 라운드가 높아질수록 토끼 생성되는 시간이 짧아진다.
        InvokeRepeating("CreateRabbit", 0, 3.5f-gameManager.round);
    }

    void CreateRabbit() //토끼객체를 생성하는 메소드
    {
        Instantiate(RabbitPrefab);
    }

    void Update()
    {
        // 게임 오버
        if (gameManager.isGameOver)
        { 
            SceneManager.LoadScene("GameOver");
        }

        // 골드 획득시 텍스트에 반영
        MyGold.GetComponent<Text>().text = "Gold : " + gameManager.gold.ToString();

        // 라운드 제한시간이 지났을 때
        if (Time.timeSinceLevelLoad > gameManager.roundInfo[gameManager.round - 1].limitTime)
        {
            // 마지막 라운드 다음은 게임오버처리.
            if (gameManager.round == 3) gameManager.isGameOver = true;
            // 한 라운드 끝냈으면 업그레이드 샵으로 씬 전환.
            else
            {
                SceneManager.LoadScene("UpgradeShop");
            }
        }
           
    }
    
    public void OnClickBtnBack()
    {
        SceneManager.LoadScene("GameOver");
    }

}