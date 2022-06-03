using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;

public class MainGameLogic : MonoBehaviour
{
    //cards
    public GameObject card01, card02, card03, card04, card05, card11, card12, card13, card14, card15;
    public GameObject blockCard, draw2Card, resetCard;
    GameObject card;

    //User area
    public GameObject PlayerSide;

    //Card Area
    public GameObject cardArea1, cardArea2, cardArea3, cardArea4, cardArea5;

    //text alerts
    public Text pattern1Text, pattern2Text, pattern3Text, pattern4Text, pattern5Text;

    //list of cards to be instantiated
    List<GameObject> cards = new List<GameObject>();

    //patterns List
    List<GameObject> pattern1 = new List<GameObject>();
    List<GameObject> pattern2 = new List<GameObject>();
    List<GameObject> pattern3 = new List<GameObject>();
    List<GameObject> pattern4 = new List<GameObject>();
    List<GameObject> pattern5 = new List<GameObject>();

    //instantiated cards pattern
    public GameObject[] cardPattern;



    void Start()
    {
        cards.Add(card01);
        cards.Add(card02);
        cards.Add(card03);
        cards.Add(card04);
        cards.Add(card05);
        cards.Add(card11);
        cards.Add(card12);
        cards.Add(card13);
        cards.Add(card14);
        cards.Add(card15);
     
        
        //draw 5 cards on hand
        draw5();

        //display random binary pattern
        displayPattern();

        //display text pattern
        displayTextPattern();
    }

    
    void Update()
    {
       
    }

    //draw 5 cards on hand
    public void draw5() 
    {
        Shuffle(cards);
        //loop draw 5 cards on start
        for (int i = 0; i < 5; i++) 
        {
            card = Instantiate(cards[Random.Range(0, cards.Count)], new Vector2(0, 0), Quaternion.identity);
            card.transform.SetParent(PlayerSide.transform, false);
            card.gameObject.tag = "Card Onhand";
        }

    }
    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    //display binary pattern
    public void displayPattern() 
    {
        //add cards on respective area list
        pattern1.Add(card11);
        pattern1.Add(card01);
        pattern2.Add(card12);
        pattern2.Add(card02);
        pattern3.Add(card13);
        pattern3.Add(card03);
        pattern4.Add(card14);
        pattern4.Add(card04);
        pattern5.Add(card15);
        pattern5.Add(card05);
     
        //generate binary pattern and display on UI
        var random1 = (GameObject)Instantiate(pattern1[Random.Range(0, pattern1.Count)], new Vector2(0, 0), Quaternion.identity);
        random1.transform.SetParent(cardArea1.transform, false);
        random1.GetComponent<EventTrigger>().enabled = false;
        random1.GetComponent<BoxCollider2D>().enabled = false;
        random1.gameObject.tag = "Card Pattern";
  
        var random2 = (GameObject)Instantiate(pattern2[Random.Range(0, pattern2.Count)], new Vector2(0, 0), Quaternion.identity);
        random2.transform.SetParent(cardArea2.transform, false);
        random2.GetComponent<EventTrigger>().enabled = false;
        random2.GetComponent<BoxCollider2D>().enabled = false;
        random2.gameObject.tag = "Card Pattern";

        var random3 = (GameObject)Instantiate(pattern3[Random.Range(0, pattern3.Count)], new Vector2(0, 0), Quaternion.identity);
        random3.transform.SetParent(cardArea3.transform, false);
        random3.GetComponent<EventTrigger>().enabled = false;
        random3.GetComponent<BoxCollider2D>().enabled = false;
        random3.gameObject.tag = "Card Pattern";

        var random4 = (GameObject)Instantiate(pattern4[Random.Range(0, pattern4.Count)], new Vector2(0, 0), Quaternion.identity);
        random4.transform.SetParent(cardArea4.transform, false);
        random4.GetComponent<EventTrigger>().enabled = false;
        random4.GetComponent<BoxCollider2D>().enabled = false;
        random4.gameObject.tag = "Card Pattern";

        var random5 = (GameObject)Instantiate(pattern5[Random.Range(0, pattern5.Count)], new Vector2(0, 0), Quaternion.identity);
        random5.transform.SetParent(cardArea5.transform, false);
        random5.GetComponent<EventTrigger>().enabled = false;
        random5.GetComponent<BoxCollider2D>().enabled = false;
        random5.gameObject.tag = "Card Pattern";
     
    }
    public void displayTextPattern()
    {
        cardPattern = GameObject.FindGameObjectsWithTag("Card Pattern");
        cardPattern.ToList();

        foreach (var card in cardPattern)
        {
            if (card.name == "01(Clone)")
            {
                pattern1Text.text = "01";
            }
            else if (card.name == "11(Clone)")
            {
                pattern1Text.text = "11";
            }
            else if (card.name == "02(Clone)")
            {
                pattern2Text.text = "02";
            }
            else if (card.name == "12(Clone)")
            {
                pattern2Text.text = "12";
            }
            else if (card.name == "03(Clone)")
            {
                pattern3Text.text = "03";
            }
            else if (card.name == "13(Clone)")
            {
                pattern3Text.text = "13";
            }
            else if (card.name == "04(Clone)")
            {
                pattern4Text.text = "04";
            }
            else if (card.name == "14(Clone)")
            {
                pattern4Text.text = "14";
            }
            else if (card.name == "05(Clone)")
            {
                pattern5Text.text = "05";
            }
            else if (card.name == "15(Clone)")
            {
                pattern5Text.text = "15";
            }
        }
    }
}
