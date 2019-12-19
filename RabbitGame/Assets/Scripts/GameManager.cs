using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameManager
{
    // 게임매니저 싱글톤 생성 후 초기화
    private static GameManager instance;
    public static GameManager getFirstInstance()
    {
        instance = new GameManager();
        instance.Init();
        return instance;
    }
    public static GameManager getInstance()
    {
        if (instance == null)
        {
            instance = new GameManager();
            instance.Init();
        }
        return instance;
    }
    public int round;
    public int gold;
    public bool isGameOver;
    public float playerMoveSpeed;
    public float playerJumpSpeed;
    public int gainGold;
    public Round[] roundInfo = new Round[3];
    public int[] prices = new int[4];
    public int score;
    public List<Ranking> ranking = new List<Ranking>();

    // 데이터를 초기화하는 메소드 (라운드마다 다른 정보)
    private void Init()
    {
        for (int i = 0; i < 3; i++)
        {
            roundInfo[i] = new Round(1 + i,40, 3.0f + (i * 1.0f), 1.0f + (i * 1.0f));
        }
        instance.round = 1;
        instance.gold = 0;
        instance.isGameOver = false;
        instance.playerMoveSpeed = 5f;
        instance.playerJumpSpeed = 10f;
        instance.gainGold = 10;
        instance.prices = new int[] { 20, 20, 100, 150 };
        instance.score = 0;
    }
}