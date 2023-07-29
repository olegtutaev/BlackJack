using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsDesign.GameLib
{
  /// <summary>
  /// Класс, представляющий собой игровую карту.
  /// </summary>
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
}
