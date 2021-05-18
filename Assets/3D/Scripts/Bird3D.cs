using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird3D : MonoBehaviour
{
    public Transform ori;
    private bool isClick = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                transform.position = new Vector3(hit.point.x, hit.point.y, 8);
            }
        }
    }
    
    private void OnMouseDown()
    {
        isClick = true;
    }
    private void OnMouseUp()
    {
        isClick = false;
    }
}
