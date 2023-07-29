using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsDesign.GameLib
{
  /// <summary>
  /// Класс, представляющий игрока.
  /// </summary>
  public class Player
  {
    public Player(bool isAi)
    {
      this.IsAi = isAi;
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
      CurrentScore = CurrentScore + card.Point;
      // Добавляем карту в колоду.
      // Увеличиваем кол-во очков на кол-ко очков карты.
    }
  }
}
