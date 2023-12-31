﻿namespace BlackJack;

/// <summary>
/// Класс с игровой логикой.
/// </summary>
internal class Game
{
  public Game()
  {
    this.CardManager = new CardManager();
    this.PlayerManager = new PlayerManager();

    this.IsNext = true;
    this.Winner = new Player("There is no winner yet!", true);
  }

  private const int dangerSum = 11; // Некий пороог очков, превысив который ИИ может рандомно не брать доп. карту.

  public Player Winner { get; private set; }
  public bool IsNext { get; private set; }
  
  public CardManager CardManager { get; }
  public PlayerManager PlayerManager { get; }
  
  /// <summary>
  /// Инициализация игроков и колоды карт.
  /// </summary>
  /// <param name="players">Список игроков.</param>
  public void InitGame(List<Player> players)
  {
    Console.WriteLine("Инициализация игроков и перетасовка карт...");
    
    CardManager.ShuffleCardDeck();
    PlayerManager.AddPlayers(players);
  }

  /// <summary>
  /// Ходит ли игрок.
  /// Берёт игрока и проверяет, активный или нет.
  /// Если да, то игрок ходит, если нет, перемещает его в конец очереди.
  /// </summary>
  /// <returns></returns>
  public bool IsNextTurn()
  {
    var player = PlayerManager.NextPlayer();
    
    Console.WriteLine($"Ход игрока: {player.Name}, Score: {player.CurrentScore}");

    if (player.IsActive)
    {
      GiveCard(player);
      CheckWin(player);
      return true;
    }

    PlayerManager.GetNextPlayer();
    return false;
  }

  /// <summary>
  /// Нужна ли ещё карта, или нет.
  /// Перемещает игрока в конец очереди, и не важно, берёт ли доп. карту или нет.
  /// </summary>
  /// <param name="isMore">Нужна ещё карта или нет.</param>
  public void TakeOneMoreCard(bool isMore)
  {
    var player = PlayerManager.GetNextPlayer();

    if (isMore)
    {
      if (player.IsAi)
        TakeOneMoreCardComputer(player);
      else GiveCard(player);
    }

    CheckWin(player);
  }

  /// <summary>
  /// Проверка на количество игроков. Если остался 1 игрок, он автоматически выйгрывает.
  /// </summary>
  /// <returns></returns>
  public bool CheckPlayers()
  {
    var activeCount = PlayerManager.GetPlayersActiveCount();

    if (activeCount > 1) return true;

    Winner = PlayerManager.GetFirstActivePlayer();
    return false;
  }

  /// <summary>
  /// Проверка на выйгрыш или проигрышь игрока.
  /// </summary>
  /// <param name="player"></param>
  /// <returns>True в случае выйгрыша, False в ином случае.</returns>
  private bool CheckWin(Player player)
  {
    if (player.CurrentScore == 21)
    {
      IsNext = false;
      Winner = player;
      return true;
    }

    if (player.CurrentScore > 21)
    {
      player.IsActive = false;
      Console.WriteLine($"Игрок {player.Name} набрал больше 21 и выбывает!");
    }

    return false;
  }

  /// <summary>
  /// Если сумарное число очков ИИ больше или равно dangerSum, ИИ задумывается, брать ли ещё карту за счёт рандома. Если нет, то ход передаётся
  /// следующему игроку. dangerSum может быть изменено в процессе тестирования. Предварительно оно равно 11.
  /// </summary>
  /// <param name="player">Игрок</param>
  private void TakeOneMoreCardComputer(Player player)
  {
    if (player.CurrentScore >= dangerSum)
    {
      Random random = new Random();

      if (random.Next(100) < 50)
      {
        Console.WriteLine($"Бот {player.Name} решил взять ещё карту.");
        GiveCard(player);
      }
      else
        Console.WriteLine($"Бот {player.Name} отказался брать карту.");
    }
    else
    {
      GiveCard(player);
      Console.WriteLine($"Бот {player.Name} решил взять ещё карту.");
    }
    
  }

  /// <summary>
  /// Даём игроку карту.
  /// </summary>
  /// <param name="player">Игрок</param>
  private void GiveCard(Player player)
  {
    var card = CardManager.GiveCard();

    player.AddCard(card);
    
    Console.WriteLine($"Выдача карты {card.CardType}, {card.CardSuite}, {card.Point}\nИгроку: {player.Name}, Score: {player.CurrentScore}");
  }
}