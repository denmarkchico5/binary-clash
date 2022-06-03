using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class DrawCards : MonoBehaviour
{
    //cards
    public GameObject card01, card02, card03, card04, card05, card11, card12, card13, card14, card15;
    public GameObject blockCard, draw2Card, resetCard;
    GameObject card;

    //User area
    public GameObject PlayerSide;

    //power card text counter
    public Text resetTextCounter, draw2TextCounter, blockTextCounter, alert;

    //draw button
    public Button drawButton;

    public GameObject panel;

    List<GameObject> cards = new List<GameObject>();

    private GameObject[] cardOnhand;

    //Max power card counter
    int maxReset = 5;
    int maxDraw2 = 5;
    int maxBlock = 5;

   
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

         //cards.Add(blockCard);
         cards.Add(draw2Card);
         cards.Add(resetCard);
       
    }

    public void draw() 
    {
        //mag random ng 1 card draw
        card = Instantiate(cards[Random.Range(0, cards.Count)], new Vector2(0, 0), Quaternion.identity);
        card.transform.SetParent(PlayerSide.transform, false);
        card.gameObject.tag = "Card Onhand";

        //powercard counter
        counter();
    }

    //powercard counter
    public void counter() 
    {
        if (card.name == "block(Clone)")
        {
            maxBlock--;
            print(maxBlock + "Block");
            blockTextCounter.text = "Block: " + maxBlock.ToString();
            if (maxBlock == 0)
            {
                cards.Remove(blockCard);
                print("block removed");
                foreach (var i in cards)
                {
                    print(i);
                }
            }
        }
        else if (card.name == "draw2(Clone)")
        {
            maxDraw2--;
            print(maxDraw2 + "draw2");
            draw2TextCounter.text = "Draw 2: " + maxDraw2.ToString();
            if (maxDraw2 == 0)
            {
                cards.Remove(draw2Card);
                print("Draw removed");
                foreach (var i in cards)
                {
                    print(i);
                }
            }
        }
        else if (card.name == "reset(Clone)")
        {
            maxReset--;
            print(maxReset + "Reset");
            resetTextCounter.text = "Reset: " + maxReset.ToString();
            if (maxReset == 0)
            {
                cards.Remove(resetCard);
                print("Reset Removed");
                {
                    foreach (var i in cards)
                    {
                        print(i);
                    }
                }
            }
        }
    }
    //CARD COUNTER TO DISABLE DECK IF CARD ONHAND IS MORE THAN 7
    
    public void cardOnHandCounter()
    {
        cardOnhand = GameObject.FindGameObjectsWithTag("Card Onhand");
        cardOnhand.ToList();
        if (cardOnhand.Count() >= 7)
        {
            drawButton.enabled = false;
            panel.SetActive(true);
            StartCoroutine(alertNotif("TOO MUCH CARD! DISCARD FIRST", 1));
            if (cardOnhand.Count() <= 7) 
            {
                drawButton.enabled = true;
            }
        }
        else 
        {
            draw();
        }
    }
    IEnumerator alertNotif(string text, int time)
    {
        alert.text = text;
        yield return new WaitForSeconds(time);
        alert.text = "";
        panel.SetActive(false);
    }
}
