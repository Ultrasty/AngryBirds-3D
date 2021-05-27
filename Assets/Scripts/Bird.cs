using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float maxDis;
    public Transform ori;
    private bool isClick = false;
    [HideInInspector]
    public SpringJoint2D sp;
    private Rigidbody2D rg;
    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();
    }
    private void OnMouseDown()
    {
        isClick = true;
        rg.isKinematic = true;
    }
    private void OnMouseUp()
    {
        isClick = false;
        rg.isKinematic = false;
        Invoke("fly", 0.15f);
    }
    private void Update()
    {
        if (isClick)
        {
            var mousePosition = Input.mousePosition;
            var tempMousePosition = new Vector3(mousePosition.x, mousePosition.y, -10);
            var temp = Camera.main.ScreenToWorldPoint(tempMousePosition);
            temp = new Vector3(temp.x, temp.y, 0);
            transform.position = temp;
            if (Vector3.Distance(transform.position, ori.position) > maxDis)
            {
                Vector3 pos = (transform.position - ori.position).normalized;
                pos *= maxDis;
                transform.position = pos + ori.position;
            }
        }
        
    }
    private void fly()
    {
        sp.enabled = false;
    }
}
