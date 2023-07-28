namespace BlackJack;

/// <summary>
/// Класс, представляющий игрока.
/// </summary>
public class Player
{
  public Player(string name, bool isAi)
  {
    this.Name = name;
    this.IsAi = isAi;
    this.IsActive = true;

    Cards = new List<Card>();
  }

  public string Name { get; set; }
  public int CurrentScore { get; private set; }
  public bool IsActive { get; set; }
  public bool IsAi { get; set; }
  public List<Card> Cards { get; }

  /// <summary>
  /// Добавить карту в колоду игроку.
  /// </summary>
  /// <param name="card">Карта.</param>
  public void AddCard(Card card)
  {
    Cards.Add(card);
    CurrentScore += card.Point;
  }
}