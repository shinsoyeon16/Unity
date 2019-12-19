using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    Rigidbody rigid;
    Animator animator;
    public GameManager gameManager;
    public float moveSpeed;
    public float jumpSpeed;
    public bool isAlive;


    void Start()
    {
        //게임매니저를 싱글톤으로 불러온다.
        this.gameManager = GameManager.getInstance();

        //  토끼 정보를 게임매니저로부터 매칭시킨다.
        moveSpeed = gameManager.roundInfo[gameManager.round-1].rabbitMoveSpeed;
        jumpSpeed = gameManager.roundInfo[gameManager.round-1].rabbitJumpSpeed;
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.SetBool("Run", true);
        isAlive = true;
        transform.position = 
            new Vector3(Random.Range(50f, 100f),
            Random.Range(1f, 1.5f * jumpSpeed),
            Random.Range(-3.0f * gameManager.round, 3.0f * gameManager.round));
    }
    
    void Update()
    {
        rigid.velocity = new Vector3(-1 * moveSpeed, rigid.velocity.y, rigid.velocity.z);
    }
    
    public void DeadRabbit()
    {
        isAlive = false;
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
