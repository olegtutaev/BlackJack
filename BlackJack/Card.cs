namespace BlackJack;

public class Card
{
  public Card(int point, CardType cardType, CardSuite cardSuite)
  {
    this.Point = point;
    this.CardType = cardType;
    this.CardSuite = cardSuite;
  }

  public int Point { get; }
  public CardType CardType { get; }
  public CardSuite CardSuite { get; }
}