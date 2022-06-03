using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PatternChecker : MonoBehaviour
{
    public int matched;
    int score;
    public GameObject cardArea1, cardArea2, cardArea3, cardArea4, cardArea5, panel;
    public Text alert, scoreText;
    public GameObject panel1, panel2, panel3, panel4, panel5;

    void Start() 
    {
        cardArea1 = GameObject.Find("Card Area 1");
        cardArea2 = GameObject.Find("Card Area 2");
        cardArea3 = GameObject.Find("Card Area 3");
        cardArea4 = GameObject.Find("Card Area 4");
        cardArea5 = GameObject.Find("Card Area 5");

    }
    public void PatternCheck() 
    {
        if (matched == 5) 
        {
            panel.SetActive(true);
            StartCoroutine(alertNotif("YOU COMPLETED THE PATTERN!", 1));
            scoreText.text = "Score: " + score.ToString();
            panel1.SetActive(false);
            panel2.SetActive(false);
            panel3.SetActive(false);
            panel4.SetActive(false);
            panel5.SetActive(false);
        }
    }
    public void resetPanel() 
    {
        while (matched != 0) 
        {
            matched--;
        }
    }

    public void cardPattern1() 
    {
        GameObject[] onArea1 = GameObject.FindGameObjectsWithTag("on Area 1");
        onArea1.ToList();

        Transform child = cardArea1.transform.GetChild(0);

        foreach (var card in onArea1) 
        {
            if (card.name == child.name) 
            {
                Debug.Log("MATCHED! 1");
                card.gameObject.tag = "matched1";
                matched++;
                cardArea1.GetComponent<BoxCollider2D>().enabled = false;
                panel1.SetActive(true);
                if (card.name == "11(Clone)")
                {
                    score += 16;
                }
            }
            
        }
        Debug.Log("matched: " + matched);
    }
    public void cardPattern2() 
    {
        GameObject[] onArea2 = GameObject.FindGameObjectsWithTag("on Area 2");
        onArea2.ToList();

        Transform child = cardArea2.transform.GetChild(0);

        foreach (var card in onArea2)
        {
            if (card.name == child.name)
            {
                Debug.Log("MATCHED! 2");
                card.gameObject.tag = "matched2";
                matched++;
                cardArea2.GetComponent<BoxCollider2D>().enabled = false;
                panel2.SetActive(true);
                if (card.name == "12(Clone)")
                {
                    score += 8;
                }
            }
        }
        Debug.Log("matched: " + matched);
    }
    public void cardPattern3() 
    {
        GameObject[] onArea3 = GameObject.FindGameObjectsWithTag("on Area 3");
        onArea3.ToList();

        Transform child = cardArea3.transform.GetChild(0);

        foreach (var card in onArea3)
        {
            if (card.name == child.name)
            {
                Debug.Log("MATCHED! 3");
                card.gameObject.tag = "matched3";
                matched++;
                cardArea3.GetComponent<BoxCollider2D>().enabled = false;
                panel3.SetActive(true);
                if (card.name == "13(Clone)")
                {
                    score += 4;
                }
            }
        }
        Debug.Log("matched: " + matched);
    }
    public void cardPattern4() 
    {
        GameObject[] onArea4 = GameObject.FindGameObjectsWithTag("on Area 4");
        onArea4.ToList();

        Transform child = cardArea4.transform.GetChild(0);

        foreach (var card in onArea4)
        {
            if (card.name == child.name)
            {
                Debug.Log("MATCHED! 4");
                card.gameObject.tag = "matched4";
                matched++;
                cardArea4.GetComponent<BoxCollider2D>().enabled = false;
                panel4.SetActive(true);
                if (card.name == "14(Clone)")
                {
                    score += 2;
                }
            }
        }
        Debug.Log("matched: " + matched);
    }
    public void cardPattern5() 
    {
        GameObject[] onArea5 = GameObject.FindGameObjectsWithTag("on Area 5");
        onArea5.ToList();

        Transform child = cardArea5.transform.GetChild(0);

        foreach (var card in onArea5)
        {
            if (card.name == child.name)
            {
                Debug.Log("MATCHED! 5");
                card.gameObject.tag = "matched5";
                matched++;
                cardArea5.GetComponent<BoxCollider2D>().enabled = false;
                panel5.SetActive(true);
                if (card.name == "15(Clone)")
                {
                    score += 1;
                }
            }
        }
        Debug.Log("matched: " + matched);
    }

    IEnumerator alertNotif(string text, int time)
    {
        alert.text = text;
        yield return new WaitForSeconds(time);
        alert.text = "";
        panel.SetActive(false);
    }

}
