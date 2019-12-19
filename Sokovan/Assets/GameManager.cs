using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject WinUI;
    public ItemBox[] itemBoxes;
    public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
        }
        if (isGameOver) return;
        int count = 0;
        for(int i = 0; i < 3; i++)
        {
            if (itemBoxes[i].isOverlap)
                count++;
        }
        if (count >= 3)
        {
            isGameOver = true;
            WinUI.SetActive(true);
        }
    }
}
