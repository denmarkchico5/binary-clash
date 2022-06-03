using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

public class DragDropCard : MonoBehaviour
{
    public GameObject canvas, checker, score;
    public GameObject cardArea1, cardArea2, cardArea3, cardArea4, cardArea5, powercard;

    private bool DraggingCard = false;
    private bool isOverDropZone;
    private GameObject startParent;
    private GameObject dropZone;
    string DropZone;
    private Vector2 startPosition;
    GameObject[] correct1, correct2, correct3, correct4, correct5;

    private bool match;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        cardArea1 = GameObject.Find("Card Area 1");
        cardArea2 = GameObject.Find("Card Area 2");
        cardArea3 = GameObject.Find("Card Area 3");
        cardArea4 = GameObject.Find("Card Area 4");
        cardArea5 = GameObject.Find("Card Area 5");
        powercard = GameObject.Find("Power Card");
        score = GameObject.Find("Score Manager");

        checker = GameObject.Find("Card Pattern Checker");
    }

    public void StartDrag()
    {
        setColliderOFF();

        correct1 = GameObject.FindGameObjectsWithTag("matched1");
        correct2 = GameObject.FindGameObjectsWithTag("matched2");
        correct3 = GameObject.FindGameObjectsWithTag("matched3");
        correct4 = GameObject.FindGameObjectsWithTag("matched4");
        correct5 = GameObject.FindGameObjectsWithTag("matched5");
        correct1.ToList();
        correct2.ToList();
        correct3.ToList();
        correct4.ToList();
        correct5.ToList();

        DraggingCard = true;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        this.GetComponent<BoxCollider2D>().enabled = true;

        if (this.gameObject.name == "01(Clone)" || this.gameObject.name == "11(Clone)")
        {
            cardArea1.GetComponent<BoxCollider2D>().enabled = true;
            if (correct1.Count() == 0)
            {
                this.GetComponent<BoxCollider2D>().enabled = true;
                cardArea1.GetComponent<BoxCollider2D>().enabled = true;
            }
            else if (correct1.Count() >= 1)
            {
                foreach (var item in correct1)
                {
                    if (item.tag == "matched1")
                    {
                        setColliderOFF();
                    }
                }
            }
        }
        else if (this.gameObject.name == "02(Clone)" || this.gameObject.name == "12(Clone)")
        {
            cardArea2.GetComponent<BoxCollider2D>().enabled = true;
            if (correct2.Count() == 0)
            {
                this.GetComponent<BoxCollider2D>().enabled = true;
                cardArea2.GetComponent<BoxCollider2D>().enabled = true;
            }
            else if (correct2.Count() >= 1)
            {
                foreach (var item in correct2)
                {
                    if (item.tag == "matched2")
                    {
                        setColliderOFF();
                    }
                }
            }
        }
        else if (this.gameObject.name == "03(Clone)" || this.gameObject.name == "13(Clone)")
        {
            cardArea3.GetComponent<BoxCollider2D>().enabled = true;
            if (correct3.Count() == 0)
            {
                this.GetComponent<BoxCollider2D>().enabled = true;
                cardArea3.GetComponent<BoxCollider2D>().enabled = true;
            }
            if (correct3.Count() >= 1)
            {
                foreach (var item in correct3)
                {
                    if (item.tag == "matched3")
                    {
                        setColliderOFF();
                    }
                }
            }
        }
        else if (this.gameObject.name == "04(Clone)" || this.gameObject.name == "14(Clone)")
        {
            cardArea4.GetComponent<BoxCollider2D>().enabled = true;
            if (correct4.Count() == 0)
            {
                this.GetComponent<BoxCollider2D>().enabled = true;
                cardArea4.GetComponent<BoxCollider2D>().enabled = true;
            }
            if (correct4.Count() >= 1)
            {
                foreach (var item in correct4)
                {
                    if (item.tag == "matched4")
                    {
                        setColliderOFF();
                    }
                }
            }
        }
        else if (this.gameObject.name == "05(Clone)" || this.gameObject.name == "15(Clone)")
        {
            cardArea5.GetComponent<BoxCollider2D>().enabled = true;
            if (correct5.Count() == 0)
            {
                this.GetComponent<BoxCollider2D>().enabled = true;
                cardArea5.GetComponent<BoxCollider2D>().enabled = true;
            }
            if (correct5.Count() >= 1)
            {
                foreach (var item in correct5)
                {
                    if (item.tag == "matched5")
                    {
                        setColliderOFF();
                    }
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
         if (collision.collider.gameObject.name == "Card Area 1")
         {
             dropZone = GameObject.Find("Card Area 1");
             Debug.Log("ENTER COL: "+dropZone);
            DropZone = "Card Area 1";
         }
         else if (collision.collider.gameObject.name == "Card Area 2")
         {
             dropZone = GameObject.Find("Card Area 2");
             Debug.Log("ENTER COL: "+dropZone);
            DropZone = "Card Area 2";
        }
         else if (collision.collider.gameObject.name == "Card Area 3")
         {
             dropZone = GameObject.Find("Card Area 3");
             Debug.Log(dropZone);
            DropZone = "Card Area 3";
        }
         else if (collision.collider.gameObject.name == "Card Area 4")
         {
             dropZone = GameObject.Find("Card Area 4");
             Debug.Log(dropZone);
            DropZone = "Card Area 4";
        }
         else if (collision.collider.gameObject.name == "Card Area 5")
         {
             dropZone = GameObject.Find("Card Area 5");
             Debug.Log(dropZone);
            DropZone = "Card Area 5";
        }
         else
         {
             isOverDropZone = false;
             dropZone = null;
             setColliderON();
         }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }
    public void EndDrag()
    {
        DraggingCard = false;
        if (isOverDropZone)
        {
            transform.SetParent(dropZone.transform, false);
            Debug.Log("drop: " + dropZone);
            if (DropZone == "Card Area 1")
            {
                this.gameObject.tag = "on Area 1";
                Debug.Log("CARD 1 AREA ");
                this.GetComponent<EventTrigger>().enabled = false;
                checker.GetComponent<PatternChecker>().cardPattern1();
                checker.GetComponent<PatternChecker>().PatternCheck();
            }
            else if (DropZone == "Card Area 2")
            {
                this.gameObject.tag = "on Area 2";
                Debug.Log("CARD 2 AREA");
                this.GetComponent<EventTrigger>().enabled = false;
                checker.GetComponent<PatternChecker>().cardPattern2();
                checker.GetComponent<PatternChecker>().PatternCheck();
            }
            else if (DropZone == "Card Area 3")
            {
                this.gameObject.tag = "on Area 3";
                this.GetComponent<EventTrigger>().enabled = false;
                checker.GetComponent<PatternChecker>().cardPattern3();
                checker.GetComponent<PatternChecker>().PatternCheck();
            }
            else if (DropZone == "Card Area 4")
            {
                this.gameObject.tag = "on Area 4";
                this.GetComponent<EventTrigger>().enabled = false;
                checker.GetComponent<PatternChecker>().cardPattern4();
                checker.GetComponent<PatternChecker>().PatternCheck();
            }
            else  if (DropZone == "Card Area 5")
            {
                this.gameObject.tag = "on Area 5";
                this.GetComponent<EventTrigger>().enabled = false;
                checker.GetComponent<PatternChecker>().cardPattern5();
                checker.GetComponent<PatternChecker>().PatternCheck();
            }
            Debug.Log("END DROP: " + dropZone);
            this.GetComponent<BoxCollider2D>().enabled = false;
            setColliderON();
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
            setColliderON();
        }
    }
    void Update()
    {
        if (DraggingCard)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(canvas.transform, true);
        }

    }
    public void setColliderON()
    {
        cardArea1.GetComponent<BoxCollider2D>().enabled = true;
        cardArea2.GetComponent<BoxCollider2D>().enabled = true;
        cardArea3.GetComponent<BoxCollider2D>().enabled = true;
        cardArea4.GetComponent<BoxCollider2D>().enabled = true;
        cardArea5.GetComponent<BoxCollider2D>().enabled = true;
        powercard.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void setColliderOFF()
    {
        cardArea1.GetComponent<BoxCollider2D>().enabled = false;
        cardArea2.GetComponent<BoxCollider2D>().enabled = false;
        cardArea3.GetComponent<BoxCollider2D>().enabled = false;
        cardArea4.GetComponent<BoxCollider2D>().enabled = false;
        cardArea5.GetComponent<BoxCollider2D>().enabled = false;
        powercard.GetComponent<BoxCollider2D>().enabled = false;

        GameObject[] cardBox = GameObject.FindGameObjectsWithTag("Card Onhand");
        cardBox.ToList();
        foreach (var box in cardBox)
        {
            box.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
