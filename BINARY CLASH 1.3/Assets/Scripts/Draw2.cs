using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw2 : MonoBehaviour
{
    //cards
    public GameObject card01, card02, card03, card04, card05, card11, card12, card13, card14, card15;
    public GameObject PlayerSide;
    GameObject card;

    List<GameObject> cards = new List<GameObject>();

    public void draw2() 
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

        for (int i = 0; i < 2; i++)
        {
            card = Instantiate(cards[Random.Range(0, cards.Count)], new Vector2(0, 0), Quaternion.identity);
            card.transform.SetParent(PlayerSide.transform, false);
            card.gameObject.tag = "Card Onhand";
           // Debug.Log("DRAW2 UPDATE");
        }
    }

}
