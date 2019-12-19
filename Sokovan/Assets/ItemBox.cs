using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    private Color originamColor;
    private Color touchColor = Color.red;
    public bool isOverlap = false;
    private Renderer myRenderer;
    // Start is called before the first frame update

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        originamColor = myRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider c)
    {
        if (c.tag == "EndPoint")
        {
            myRenderer.material.color = touchColor;
            isOverlap = true;
        }
    }
    private void OnTriggerExit(Collider c)
    {
        if (c.tag == "EndPoint")
        {
            myRenderer.material.color = originamColor;
            isOverlap = false;
        }
    }
    private void OnTriggerStay(Collider c)
    {
        if (c.tag == "EndPoint")
        {
            myRenderer.material.color = touchColor;
            isOverlap = true;
        }
    }
}
