using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public GameManager gameManager;
    
    // 게임 시작 눌렀을 때 실행되는 메소드
    public void OnClickBtnGameStart()
    {
        //게임매니저를 싱글톤으로 불러온다.
        this.gameManager = GameManager.getFirstInstance();
        SceneManager.LoadScene("Round");
    }

    // 랭킹 보기 눌렀을 때 실행되는 메소드
    public void OnClickBtnRanking()
    {
        SceneManager.LoadScene("Ranking");
    }

    //닫기 버튼 눌렀을 때 실행되는 메소드
    public void OnClickBtnExit()
    {
        Application.Quit();
    }
}
