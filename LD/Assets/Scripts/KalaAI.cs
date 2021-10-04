using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalaAI : MonoBehaviour
{
    public GameObject senan;
    public Transform playerT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform temep = playerT;
        temep.position = new Vector3(playerT.position.x - 3, playerT.position.x + 3, 0);
        float dist = Vector3.Distance(playerT.position, transform.position);
        int i = Random.Range(1, 10000);
        if (i == 1 && dist < 4)
        {
            Instantiate(senan, temep);
        }
    }
}
