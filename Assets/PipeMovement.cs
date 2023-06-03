using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prevPipe;
    MyBird myBird;
    PipeGenerator myPipeGenerator;
    public bool isFirst;
    //public int dist;
    void Start()
    {
        myBird = FindObjectOfType<MyBird>();
        myPipeGenerator = FindObjectOfType<PipeGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myBird.isInGame)
        {
            transform.position -= new Vector3(Time.deltaTime, 0);
            if (transform.position.x < -8.85)
                transform.position = new Vector3(prevPipe.transform.position.x + myPipeGenerator.dist, Random.Range(-1.75f, 2.5f));
        }
    }


}
