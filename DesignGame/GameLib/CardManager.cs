using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsDesign.GameLib
{
  /// <summary>
  /// Класс для работы с картами.
  /// </summary>
  public class CardManager
  {
    private Stack<Card> cardDeck;

    public CardManager()
    {
      cardDeck = FillDeck();
    }

    /// <summary>
    /// Инициализация типов и мастей карт с последующим заполнением колоды.
    /// </summary>
    /// <returns>Стек колоды карт.</returns>
    private Stack<Card> FillDeck()
    {
      var cardTypes = new List<CardType>
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

    /// <summary>
    /// Генерация колоды карт.
    /// </summary>
    /// <param name="cardTypes">Список типов карт.</param>
    /// <param name="cardSuites">Список мастей карт.</param>
    /// <returns>Стек колоды карт.</returns>
    private Stack<Card> GenerateCardDeck(List<CardType> cardTypes, List<CardSuite> cardSuites)
    {
      Console.WriteLine("Генерация карт...");

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
      Console.WriteLine("Перетасовка карт...");

      if (cardDeck.Count != 36)
      {
        cardDeck = FillDeck();
      }

      var random = new Random();
      cardDeck = new Stack<Card>(cardDeck.OrderBy(card => random.Next()));
    }

    /// <summary>
    /// Взять карту из колоды.
    /// </summary>
    /// <returns>Вернёт карту из стека и удалит её.</returns>
    public Card GiveCard()
    {
      return cardDeck.Pop();
    }
  }
}
