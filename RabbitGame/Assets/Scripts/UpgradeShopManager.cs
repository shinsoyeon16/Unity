using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeShopManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject MsgBox;
    public GameObject Msg;
    public GameObject[] prices;
    public GameObject MyGold;
    int round;

    // Start is called before the first frame update
    void Start()
    {
        this.gameManager = GameManager.getInstance();
        round = gameManager.round;
        for (int i = 0; i < 4; i++) {
            prices[i].GetComponent<Text>().text = (gameManager.prices[i] * round).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MyGold.GetComponent<Text>().text = "Gold : "+gameManager.gold.ToString();
    }

    public void OnClickBtn1()
    {
        if (gameManager.gold < int.Parse(prices[0].GetComponent<Text>().text)) ShowMsgBox("골드가 부족합니다.");
        else
        {
            gameManager.gold -= int.Parse(prices[0].GetComponent<Text>().text);
            gameManager.playerMoveSpeed += (2 * round);
            ShowMsgBox("구매가 완료되었습니다.");
            GameObject.Find("Button").GetComponent<Button>().interactable = false;
        }
    }
    public void OnClickBtn2()
    {
        if (gameManager.gold < int.Parse(prices[1].GetComponent<Text>().text)) ShowMsgBox("골드가 부족합니다.");
        else
        {
            gameManager.gold -= int.Parse(prices[1].GetComponent<Text>().text);
            gameManager.playerJumpSpeed += (2 * round);
            ShowMsgBox("구매가 완료되었습니다.");
            GameObject.Find("Button (1)").GetComponent<Button>().interactable = false;
        }
    }
    public void OnClickBtn3()
    {
        if (gameManager.gold < int.Parse(prices[2].GetComponent<Text>().text)) ShowMsgBox("골드가 부족합니다.");
        else
        {
            gameManager.gold -= int.Parse(prices[2].GetComponent<Text>().text);
            gameManager.gainGold += (10 * round);
            ShowMsgBox("구매가 완료되었습니다.");
            GameObject.Find("Button (2)").GetComponent<Button>().interactable = false;
        }
    }
    public void OnClickBtn4()
    {
        if (gameManager.gold < int.Parse(prices[3].GetComponent<Text>().text)) ShowMsgBox("골드가 부족합니다.");
        else
        {
            gameManager.gold -= int.Parse(prices[3].GetComponent<Text>().text);
            gameManager.roundInfo[round].limitTime += 40;
            ShowMsgBox("구매가 완료되었습니다.");
            GameObject.Find("Button (3)").GetComponent<Button>().interactable = false;
            }
    }
    public void OnClickMsgBox()
    {
        MsgBox.SetActive(false);
    }
    public void ShowMsgBox(string msg)
    {
        Msg.GetComponent<Text>().text = msg;
        MsgBox.SetActive(true);
    }
    public void OnClickBtnNext()
    {
        gameManager.round++;
        SceneManager.LoadScene("Round");
    }
}
