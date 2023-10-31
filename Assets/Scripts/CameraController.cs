using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public BallController target;

    
    private float offset;
    // Start is called before the first frame update
    void Awake()
    {
       // offset = (transform.position.y - target.transform.position.y) + (transform.position.y - secondTarget.transform.position.y);
       offset = transform.position.y - target.transform.position.y;
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(offset);
        Vector3 curPos = transform.position;
        curPos.y = target.transform.position.y + offset;
        transform.position = curPos;
    }
}
