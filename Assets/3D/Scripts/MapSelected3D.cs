using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelected3D : MonoBehaviour
{

    public GameObject map;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeSelected()
    {
        
        map.SetActive(false);
        panel.SetActive(true);
    }
}
