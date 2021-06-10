using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird3D : MonoBehaviour
{

    public float maxDis;
    public Transform ori;
    private bool isClick = false;
    // Start is called before the first frame update
    private Rigidbody rg;
    [HideInInspector]
    public SpringJoint sp;
    public GameObject boom;
    public float smooth = 3;

    public AudioClip select;
    public AudioClip flyaudio;
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
            //限定拖拽距离
            if (Vector3.Distance(transform.position, ori.position) > maxDis)
            {
                Vector3 pos = (transform.position - ori.position).normalized;
                pos *= maxDis;
                transform.position = pos + ori.position;
            }
        }

        float posX = transform.position.x;
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, 
            new Vector3(Mathf.Clamp(posX, 6.54f, 26.6f), Camera.main.transform.position.y, 
            Camera.main.transform.position.z), smooth*Time.deltaTime);
    }

    private void OnMouseDown()
    {
        AudioPlay(select);
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
        AudioPlay(flyaudio);
        sp.spring = 0;
        Invoke("Next", 5);
    }
    /// <summary>
    /// 下一只小鸟
    /// </summary>
    void Next()
    {

        GameManager._instance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameManager._instance.NextBird();
    }

    public void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
