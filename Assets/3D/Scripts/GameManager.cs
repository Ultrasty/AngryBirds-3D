using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Bird3D> birds;
    public List<pig> pigs;
    public static GameManager _instance;

    private void Awake()
    {
        _instance = this;
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
                birds[i].sp.spring = 6;
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
            }
        }
        else
        {
            //赢了
        }
    }
}
