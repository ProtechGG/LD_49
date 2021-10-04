using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dialogues : MonoBehaviour
{
    private int i = 0;
    public Text text;
    public PlyerControlller playerC;
    public Text pressum;
    public AudioSource sa;
    public Sans sans;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && playerC.isEnd)
        {
            SceneManager.LoadScene("WIN", LoadSceneMode.Single);
        }
        if (Input.GetKeyDown(KeyCode.N)){
            sa.Stop();
            i++;
            pressum.text = "";
        }
        if (i == 0)
        {
            sa.Play();
            text.text = "You are Sena Pati.";
        }
        if (i == 1)
        {
            sa.Play();
            text.text = "The flying animal you see is your Left Hand";
        }
        if (i == 2)
        {
            sa.Play();
            text.text = "You can double jump.";
        }
        if (i == 3)
        {
            sa.Play();
            text.text = "Kalasur and his soldiers Piddisur kill many people everyday";
        }
        if (i == 4)
        {
            sa.Play();
            text.text = "Their base is far on the right side";
        }
        if (i == 5)
        {
            sa.Play();
            text.text = "You have to plant bomb on their base and come back";
        }
        if (i == 6)
        {
            sa.Play();
            text.text = "If you get some stability problems press E";
        }

    }
    public void ded()
    {
        i = 100;
        StartCoroutine("deddf");
    }

    public void la()
    {
        i = 100;
        StartCoroutine("ds");
    }

    public void da()
    {
        text.text = "Press P to plant bomb";
        i = 10000;
    }

    IEnumerator ds()
    {
        if (sans.dist > 5)
        {
        text.text = "Go ahead and you will see a flying structure. Plant bomb there. It is source of Kalasur's power";
        yield return new WaitForSeconds(10);
        }
        else if(sans.dist < 5)
        {
            text.text = "Press P to plant bomb";
        }
        i = 1000;
    }
    IEnumerator deddf()
    {
        text.text = "You died. Press R to restart. Press Q 2 times to quit.";
        yield return new WaitForSeconds(10);
        i = 1000;
    }
}
