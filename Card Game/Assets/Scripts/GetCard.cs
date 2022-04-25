using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetCard : MonoBehaviour
{
    [SerializeField]
    public CardDetails cardDetails;
    public TMP_Text cardName;
    public TMP_Text cardText;
    public TMP_Text manaCost;
    public Image cardArt;
    public Card card;
    public GameObject cardPrefab;
    public DummyCard dummyCard;

    public TurnController turnController;


    void Start()
    {
        cardName.text = cardDetails.cardName;
        cardText.text = cardDetails.cardText;
        manaCost.text = cardDetails.manaCost.ToString();
        cardArt.sprite = cardDetails.cardArt;
        turnController = GameObject.Find("TurnController").GetComponent<TurnController>();
        turnController.getCards.Add(this);
    }

    public void AddCard()
    {
        dummyCard.cardDetails = this.cardDetails;
        GameObject newCard = Instantiate(cardPrefab, new Vector3(-80.3f, 2.1f, 1f), Quaternion.identity);
        Card nextCard = newCard.GetComponent<Card>();
        nextCard.cardDetails = this.cardDetails;
        turnController.CloseReward();
    }

}
