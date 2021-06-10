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
            }
        }
        else
        {
            //赢了
            Win.SetActive(true);
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
            yield return new WaitForSeconds(0.8f);
            stars[i].SetActive(true);
        }
    }
}
