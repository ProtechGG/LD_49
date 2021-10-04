using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piddiAI : MonoBehaviour
{
    public Transform playerT;
    public PlyerControlller playerC;
    public Animator animator;
    bool c = false;
    float dist;
    void Update()
    {
        
        dist = Vector3.Distance(playerT.position, transform.position);
        if (dist < 5)
        {
            StartCoroutine("pip");
        }
        if (c == true)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator pip()
    {
        animator.SetBool("teh", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("teh", false);
        yield return new WaitForSeconds(1);
        c = true;
        if (dist < 4)
        {
            playerC.die = true;
        }
    }
}
