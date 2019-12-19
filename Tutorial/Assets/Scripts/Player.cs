using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected float jump = 12.0f;
    public bool isLanding = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isLanding)
        {

            if (Input.GetMouseButtonDown(0))
            {
                isLanding = false;
                GetComponent<Rigidbody>().velocity = Vector3.up * this.jump;
                
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Floor")
        isLanding = true;
    }
}
