using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnController : MonoBehaviour
{
    private bool yourTurn = true;

    public bool YourTurn { get => yourTurn; set => yourTurn = value; }
    [SerializeField]
    public bool inCombat = true;
    public Enemy enemy;
    public Player player;
    public TMP_Text drawText;
    public TMP_Text discardText;
    public GameObject overlay;
    public GameObject cardPrefab;
    public List<Card> drawPile = new List<Card>();
    public List<Card> discardPile = new List<Card>();
    public List<Card> hand = new List<Card>();
    public Transform[] cardSlots;
    public bool[] availableSlot;
    public List<GetCard> getCards = new List<GetCard>();
    public Transform[] getCardSlots;
    public bool[] availableGetSlot;
    public List<GetCard> chooseCards = new List<GetCard>();
    public List<GetCard> chosenCards = new List<GetCard>();

    [SerializeField]
    private Switch Switch;

    public void Draw(int draw)
    {
        if (inCombat == true)
        {
            for (int i = 0; i < draw; i++)
            {
                if (drawPile.Count < 1)
                {
                    Shuffle();
                }
                else
                {

                }
                DrawOne();
            }
        }
    }

    public void DrawOne()
    {
        if (drawPile.Count >= 1)
        {
            Card randCard = drawPile[Random.Range(0, drawPile.Count)];
            for (int j = 0; j < availableSlot.Length; j++)
            {
                if (availableSlot[j] == true)
                {
                    randCard.gameObject.SetActive(true);
                    randCard.handNumber = j;
                    hand.Add(randCard);
                    randCard.played = false;
                    randCard.transform.position = cardSlots[j].position;
                    availableSlot[j] = false;
                    drawPile.Remove(randCard);
                    return;
                }
            }
        }
    }
    public void Reward()
    {
        inCombat = false;
        overlay.SetActive(true);
        for (int i =0; i < 2; i++)
        {
            RewardCards();
        }
    }

    public void CloseReward()
    {
        inCombat = true;
        overlay.SetActive(false);
        {
            for (int k = 0; k < 2; k++)
            {
                availableGetSlot[k] = true;
            }
            foreach (GetCard getCard in chooseCards)
            {
                chosenCards.Add(getCard);
                getCard.gameObject.SetActive(false);
            }
            chooseCards.Clear();
        }
        StartCombat();
    }

    public void RewardCards()
    {
        GetCard getRandCard = getCards[Random.Range(0, getCards.Count)];
        for (int j = 0; j < availableGetSlot.Length; j++)
        {
            if (availableGetSlot[j] == true)
            {
                getRandCard.gameObject.SetActive(true);
                chooseCards.Add(getRandCard);
                getRandCard.transform.position = getCardSlots[j].position;
                availableGetSlot[j] = false;
                getCards.Remove(getRandCard);
                return;
            }
        }

    }

    public void Shuffle()
    {
        foreach(Card card in discardPile)
        {
            drawPile.Add(card);
        }
        discardPile.Clear();
    }

    public void DiscardHand()
    {
        for (int k = 0; k < 4; k++)
        {
            availableSlot[k] = true;
        }
        foreach (Card card in hand)
        {
            discardPile.Add(card);
            card.gameObject.SetActive(false);
        }
        hand.Clear();
    }

    void Start()
    {
        
    }

    public void StartCombat()
    {
        DiscardHand();
        Shuffle();
        if(YourTurn == true)
        {
            Draw(3);
        }
        else
        {

        }
        player.reset();
        enemy.SpawnEnemy();
    }

    
    void Update()
    {
        drawText.text = drawPile.Count.ToString();
        discardText.text = discardPile.Count.ToString();
    }
}
