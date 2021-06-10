using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Bird3D> birds;
    public List<pig> pigs;
    public static GameManager _instance;
    private Vector3 originPos;//初始化的位置
    public GameObject Lose;
    public GameObject Win;
    public GameObject[] stars;
    public AudioClip win;
    public AudioClip lose;

    void OnGUI()
    {

        GUI.Box(new Rect(10, 10, 100, 90), "Debug Menu");

        if (GUI.Button(new Rect(20, 40, 80, 20), "win"))
        {
            Win.SetActive(true);
            AudioPlay(win);
            showstars();
        }

        if (GUI.Button(new Rect(20, 70, 80, 20), "lose"))
        {
            Lose.SetActive(true);
            AudioPlay(lose);
        }
    }

    private void Awake()
    {
        _instance = this;
        originPos = birds[0].transform.position;
        
    }
    /// <summary>
    /// 初始化
    /// </summary>
    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0)
            {
                birds[i].transform.position = originPos;
                birds[i].sp.spring = 4;
            }
            else
            {
                birds[i].sp.spring = 0;
            }
        }
    }

    public void NextBird()
    {
        if (pigs.Count > 0)
        {
            if (birds.Count > 0)
            {
                //下一只
                Initialized();
            }
            else
            {
                //输了
                Lose.SetActive(true);
                AudioPlay(lose);
            }
        }
        else
        {
            //赢了
            Win.SetActive(true);
            AudioPlay(win);
            showstars();
        }
    }

    public void showstars()
    {
        StartCoroutine("show");
    }

    IEnumerator show()
    {
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.4f);
            stars[i].SetActive(true);
        }
    }

    public void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
