using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public int dist;
    void Start()
    {
        for (int i = 1; i < transform.childCount; ++i)
        {
            transform.GetChild(i).position =  new Vector3(transform.GetChild(i - 1).position.x + dist, Random.Range(-1.75f, 2.5f));
        }
    }
}
