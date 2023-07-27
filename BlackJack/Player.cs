namespace BlackJack;

public class Player
{
  public Player(string name, List<Card> receivedCards)
  {
    this.Name = name;
    this.ReceivedCards = receivedCards;
  }

  public string Name { get; }
  public List<Card> ReceivedCards  { get; }
  // Игрок должен хранить: Имя, Колоду карт, которую он получил. Колода хранится в List<>
  // Необязательно: общее количество очков.
}