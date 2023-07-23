namespace BlackJack;

public class CardUtil
{
  private Stack<Card> cardDeck;

  public CardUtil()
  {
    cardDeck = FillDeck();
  }
  
  private Stack<Card> FillDeck()
  {
    var cardTypes = new List<CardType> // Пока оставил как костыль. Тут все 36 карт.
    {
      CardType.Six,
      CardType.Seven,
      CardType.Eight,
      CardType.Nine,
      CardType.Ten,
      CardType.Jack,
      CardType.Queen,
      CardType.King,
      CardType.Ace
    };
    var cardSuites = new List<CardSuite>
    {
      CardSuite.Clubs,
      CardSuite.Diamonds,
      CardSuite.Hearts,
      CardSuite.Spades
    };

    return GenerateCardDeck(cardTypes, cardSuites);
  }
  
  private Stack<Card> GenerateCardDeck(List<CardType> cardTypes, List<CardSuite> cardSuites)
  {
    cardDeck = new Stack<Card>();
    
    foreach (var cardType in cardTypes)
    {
      foreach (var cardSuite in cardSuites)
      {
        cardDeck.Push(
          new Card((int)cardType, cardType, cardSuite)
        );
      }
    }

    return cardDeck;
  }

  /// <summary>
  /// Перетасовка карт.
  /// </summary>
  public void ShuffleCardDeck()
  {
    if (cardDeck.Count != 36) // Тоже временный костыль.
    {
      cardDeck = FillDeck();
    }
    
    var random = new Random();
    cardDeck = new Stack<Card>(cardDeck.OrderBy(card => random.Next()));
  }

  /// <summary>
  /// Взять карту из колоды.
  /// </summary>
  /// <returns>Возвращает карту.</returns>
  public Card GiveCard()
  {
    return cardDeck.Pop();
  }
}