using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomMove : MonoBehaviour
{
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(pos.x+UnityEngine.Random.Range(0.0f,1.0f),
            pos.y+UnityEngine.Random.Range(0.0f,1.0f),
            pos.z+UnityEngine.Random.Range(0.0f,1.0f));
    }
}
