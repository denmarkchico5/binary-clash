using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DragDropPowerCards : MonoBehaviour
{
    public PatternChecker matchChange;

    public GameObject canvas;
    public GameObject reset, draw2,offDrag;
    public GameObject cardArea1, cardArea2, cardArea3, cardArea4, cardArea5, powercard;
    public GameObject resetPanel, panel1, panel2, panel3, panel4, panel5;

    private bool DraggingCard = false;
    private bool isOverDropZone;
    private GameObject startParent;
    private GameObject dropZone;
    private Vector2 startPosition;

    public GameObject[] discardedCards;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        reset = GameObject.Find("Reset Pattern");
        draw2 = GameObject.Find("Draw2");

        cardArea1 = GameObject.Find("Card Area 1");
        cardArea2 = GameObject.Find("Card Area 2");
        cardArea3 = GameObject.Find("Card Area 3");
        cardArea4 = GameObject.Find("Card Area 4");
        cardArea5 = GameObject.Find("Card Area 5");
        powercard = GameObject.Find("Power Card");

        resetPanel = GameObject.Find("Card Pattern Checker");

        panel1 = GameObject.Find("Panel1");
        panel2 = GameObject.Find("Panel2");
        panel3 = GameObject.Find("Panel3");
        panel4 = GameObject.Find("Panel4");
        panel5 = GameObject.Find("Panel5");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        if (collision.gameObject.name == "Power Card")
        {
            dropZone = GameObject.Find("Power Card");
            Debug.Log("POWER CARD ZONE");
        }
        else
        {
            isOverDropZone = false;
            dropZone = null;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        DraggingCard = true;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        setColliderOFF();
    }

    public void EndDrag()
    {
        DraggingCard = false;

        if (isOverDropZone)
        {
            transform.SetParent(dropZone.transform, false);
            this.GetComponent<BoxCollider2D>().enabled = false;
            powercard.GetComponent<PowerCardAreaUpdate>().offDrag();
            destroyDiscarded();
            if (this.name == "reset(Clone)")
            {
                destroy();
                resetPanel.GetComponent<PatternChecker>().resetPanel();
               // Debug.Log("RESET CARD");
            }
            else if (this.name == "draw2(Clone)")
            {
                draw2.GetComponent<Draw2>().draw2();
               // Debug.Log("DRAW2 CARD");
            }
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
    public void destroyDiscarded()
    {
        discardedCards = GameObject.FindGameObjectsWithTag("Discarded");
        discardedCards.ToList();

        foreach (var card in discardedCards)
        {
            Destroy(card);
        }
    }
    public void destroy()
    {
        GameObject[] matched1 = GameObject.FindGameObjectsWithTag("matched1");
        GameObject[] matched2 = GameObject.FindGameObjectsWithTag("matched2");
        GameObject[] matched3 = GameObject.FindGameObjectsWithTag("matched3");
        GameObject[] matched4 = GameObject.FindGameObjectsWithTag("matched4");
        GameObject[] matched5 = GameObject.FindGameObjectsWithTag("matched5");
        GameObject[] onArea1 = GameObject.FindGameObjectsWithTag("on Area 1");
        GameObject[] onArea2 = GameObject.FindGameObjectsWithTag("on Area 2");
        GameObject[] onArea3 = GameObject.FindGameObjectsWithTag("on Area 3");
        GameObject[] onArea4 = GameObject.FindGameObjectsWithTag("on Area 4");
        GameObject[] onArea5 = GameObject.FindGameObjectsWithTag("on Area 5");

        matched1.ToList();
        matched2.ToList();
        matched3.ToList();
        matched4.ToList();
        matched5.ToList();
        onArea1.ToList();
        onArea2.ToList();
        onArea3.ToList();
        onArea4.ToList();
        onArea5.ToList();

       

        foreach (var dcard in matched1)
        {
            Destroy(dcard);
        }
        foreach (var dcard in matched2)
        {
            Destroy(dcard);
        }
        foreach (var dcard in matched3)
        {
            Destroy(dcard);
        }
        foreach (var dcard in matched4)
        {
            Destroy(dcard);
        }
        foreach (var dcard in matched5)
        {
            Destroy(dcard);
        }
        foreach (var dcard in onArea1)
        {
            Destroy(dcard);
        }
        foreach (var dcard in onArea2)
        {
            Destroy(dcard);
        }
        foreach (var dcard in onArea3)
        {
            Destroy(dcard);
        }
        foreach (var dcard in onArea4)
        {
            Destroy(dcard);
        }
        foreach (var dcard in onArea5)
        {
            Destroy(dcard);
        }
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        panel4.SetActive(false);
        panel5.SetActive(false);
    }
    public void setColliderON() 
    {
        cardArea1.GetComponent<BoxCollider2D>().enabled = true;
        cardArea2.GetComponent<BoxCollider2D>().enabled = true;
        cardArea3.GetComponent<BoxCollider2D>().enabled = true;
        cardArea4.GetComponent<BoxCollider2D>().enabled = true;
        cardArea5.GetComponent<BoxCollider2D>().enabled = true;
        

    }
    public void setColliderOFF() 
    {
        cardArea1.GetComponent<BoxCollider2D>().enabled = false;
        cardArea2.GetComponent<BoxCollider2D>().enabled = false;
        cardArea3.GetComponent<BoxCollider2D>().enabled = false;
        cardArea4.GetComponent<BoxCollider2D>().enabled = false;
        cardArea5.GetComponent<BoxCollider2D>().enabled = false;
        
    }
}
