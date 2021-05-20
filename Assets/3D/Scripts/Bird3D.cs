using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird3D : MonoBehaviour
{


    public Transform ori;
    private bool isClick = false;
    // Start is called before the first frame update
    private Rigidbody rg;
    private SpringJoint sp;
    private void Awake()
    {
        sp = GetComponent<SpringJoint>();
        rg = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (isClick)
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.rigidbody.name == "redbird") {
                    transform.position = new Vector3(hit.point.x, hit.point.y, ori.position.z);
                }
            }
        }
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
        rg.constraints = RigidbodyConstraints.None;
        Invoke("fly", 0.2f);
    }

    private void fly()
    {
        sp.spring = 0;
    }
}
