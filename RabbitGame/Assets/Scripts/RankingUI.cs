using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingUI : MonoBehaviour
{
    GameManager gameManager;
    public static int count = 0;
    public Text rank;
    public Text name;
    public Text score;
    public Text datetime;
    // Start is called before the first frame update
    void Start()
    {
        this.gameManager = GameManager.getInstance();
        rank.text = (count + 1).ToString();
        name.text = gameManager.ranking[count].name;
        score.text = gameManager.ranking[count].score.ToString();
        datetime.text = gameManager.ranking[count].datetime.ToString("yyyy년 MM월 dd일 HH:mm");
        RectTransform rt = gameObject.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector3(rt.anchoredPosition.x, (-count*90));
        count++;
        if (count == gameManager.ranking.Count) count = 0; // 정적변수 초기화....ㅠ
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
