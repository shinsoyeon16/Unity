using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject RankingUI;
    public GameObject content;
    string SelectDataUrl = "http://localhost:8080/RabbitGameDB/selectData.jsp";
    
    void Start()
    {
        this.gameManager = GameManager.getInstance();
        StartCoroutine(SelectDataCo());
    }

    IEnumerator SelectDataCo()
    {
        WWWForm form = new WWWForm();
        WWW webRequest = new WWW(SelectDataUrl, form);
        yield return webRequest;

        // jsp로부터 받은 mysql 데이터를 형식에 맞추어 분리
        string data = webRequest.text.Trim();
        string[] row = data.Split('#');
        gameManager.ranking = new List<Ranking>();
        for (int i=0;i<row.Length-1;i++)
        {
            string[] splitData = row[i].Split('&');
                gameManager.ranking.Add
                (new Ranking(splitData[0], splitData[1], splitData[2], splitData[3]));
        }

        // 발표 후에 말씀해주신 방법으로 수정한 부분입니다.

        // C#코드에서는 정렬하는 코드를 빼고,
        // jsp코드의 sql문 뒤에 order by 코드를 넣었습니다...!!
        /* 
        // 점수 순서대로 정렬
        gameManager.ranking.Sort(new myCompare());
        */


        // 스크롤뷰 동적 사이즈 제어
        GameObject.Find("Content").GetComponent<RectTransform>().sizeDelta =
            new Vector2(GameObject.Find("Content").GetComponent<RectTransform>().sizeDelta.x,
            gameManager.ranking.Count * 90);
        for (int i=0;i< gameManager.ranking.Count;i++)
        {
            Instantiate(RankingUI, content.transform); // db갯수만큼 랭킹UI 생성
        }
    }

    // 뒤로가기 버튼 - 메인으로 이동
    public void OnClickBtnBack()
    {
        SceneManager.LoadScene("Main");
    }

}

/*  sql 문으로 정렬 하기 전 코드 2 (발표 후 수정)
// 점수 순서대로 정렬
public class myCompare : IComparer<Ranking>
{
    public int Compare(Ranking x, Ranking y)
    {
        return y.score.CompareTo(x.score);
        throw new NotImplementedException();
    }
}
*/
