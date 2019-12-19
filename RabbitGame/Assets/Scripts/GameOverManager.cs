using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Score;
    public GameObject MsgBox;
    public GameObject Msg;
    public InputField InputField;
    string RecordScoreUrl = "http://localhost:8080/RabbitGameDB/recordScore.jsp";
    void Start()
    {
        this.gameManager = GameManager.getInstance();
        Score.GetComponent<Text>().text += gameManager.score.ToString();
    }
    void Update()
    {
    }

    public void RecordScore()
    {
        StartCoroutine(RecordScoreCo());
        GameObject.Find("BtnRecordScore").GetComponent<Button>().interactable = false;
        ShowMsgBox("점수가 서버에 기록되었습니다.");
    }
    IEnumerator RecordScoreCo()
    {
        WWWForm form = new WWWForm();
        if (InputField.text == "") InputField.text = "Unknown";
        form.AddField("name", InputField.text);
        form.AddField("score", gameManager.score);
        form.AddField("datetime", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        WWW webRequest = new WWW(RecordScoreUrl, form);
        yield return webRequest;
        yield return null;
    }

    public void OnClickMsgBox()
    {
        MsgBox.SetActive(false);
        SceneManager.LoadScene("Main");
    }
    public void ShowMsgBox(string msg)
    {
        Msg.GetComponent<Text>().text = msg;
        MsgBox.SetActive(true);
    }
    // 뒤로가기 버튼 - 메인으로 이동
    public void OnClickBtnBack()
    {
        SceneManager.LoadScene("Main");
    }
}
