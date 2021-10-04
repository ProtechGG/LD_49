using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sans : MonoBehaviour
{
    
    public Transform playerT;
    public PlyerControlller playerC;
    // Start is called before the first frame update
    public float dist;

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(playerT.position, transform.position);
        if (dist <= 5)
        {
            playerC.isEnd = true;
        }else
        {
            playerC.isEnd = false;
        }
    }
}
