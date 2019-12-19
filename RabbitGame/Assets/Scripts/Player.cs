using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigid;
    public bool isLanding;
    public GameManager gameManager;
    public float moveSpeed;
    public float jumpSpeed;
    public int gainGold;

    void Start()
    {
        //게임매니저를 싱글톤으로 불러온다.
        this.gameManager = GameManager.getInstance();

        // 플레이어 정보를 게임매니저로부터 매칭시킨다.
        moveSpeed = gameManager.playerMoveSpeed;
        jumpSpeed = gameManager.playerJumpSpeed;
        gainGold = gameManager.gainGold;

        rigid = GetComponent<Rigidbody>();
        isLanding = false;
    }

    void Update()
    {
        // x축, z축 이동
        rigid.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rigid.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        // 점프
        if (Input.GetButton("Jump"))
        {
            if (isLanding)
            {
                rigid.velocity = new Vector3(rigid.velocity.x, jumpSpeed, rigid.velocity.z);
                isLanding = false;
            }
        }
    }

    private void LateUpdate() // 메인카메라 추적
    {
        Vector3 camPos = new Vector3(transform.position.x - 2.8f, 5.0f, -12f);
        Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, camPos, Time.deltaTime * 1.2f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        // 바닥에 있을 때만 점프가능
        if (collision.gameObject.tag == "Floor")
            isLanding = true;

        // 토끼를 잡았을 때 처리 (1. 골드획득  2. 토끼 객체 삭제)
        if (collision.gameObject.tag == "Rabbit")
        {
            GameObject rabbit = collision.gameObject;
            if (rabbit.GetComponent<Animator>().GetBool("Run"))
            {
                gameManager.gold += gainGold;
                gameManager.score++;
            }
            rabbit.GetComponent<Animator>().SetBool("Run", false);
            rabbit.GetComponent<Rigidbody>().velocity = Vector3.one * 0;
            Destroy(rabbit, 1.0f);
        }
    }
    // 플레이어가 제한시간내에 맵에서 떨어지면 게임오버 처리!!!!@@@###.  미구현ㄴㄴㄴㄴㄴㄴㄴㄴㄴㄹ
    //private void OnBecameInvisible()
    //{
    //    if (Time.time < gameManager.roundInfo[gameManager.round].limitTime)
    //        gameManager.isGameOver = true;
    //    Debug.Log("플레이어에서 멈춤 " + gameManager.isGameOver);
    //    Debug.Break();
    //}
}
