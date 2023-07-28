namespace BlackJack;

/// <summary>
/// Консольный стартер игры.
/// </summary>
public class ConsoleGameStarter
{
  private Game game = new();

  /// <summary>
  /// Запуск игры.
  /// </summary>
  public void Start()
  {
    // Заглушка, где инициализируется игрок и бот.
    game.InitGame(new List<Player> { new("Karusel'ka", false), new("Bot2000", true) });
    Console.WriteLine();
    
    PrintInfo();

    while (true)
    {
      Console.WriteLine();

      if (!game.IsNextTurn()) continue; // Ход игрока, если игрок не активен (набрал больше 21), он не ходит.

      if (!game.IsNext || !game.CheckPlayers()) break;

      TryTakeMore();

      if (!game.IsNext || !game.CheckPlayers()) break;

      Console.WriteLine();
      PrintInfo();
    }

    Console.WriteLine();
    PrintWinner();

    Console.ReadLine(); // Чтоб консоль мгновено не закрылась.
  }

  /// <summary>
  /// Логика дополнительных карт.
  /// </summary>
  private void TryTakeMore()
  {
    if (game.PlayerManager.NextPlayer().IsAi)
    {
      game.TakeOneMoreCard(true);
      return;
    }
      

    while (true)
    {
      Console.Write("Хотите взять ещё карту? Y/N: ");
      var readLine = Console.ReadLine();

      if (readLine is "Y" or "y")
      {
        game.TakeOneMoreCard(true);
        break;
      }

      if (readLine is "N" or "n")
      {
        game.TakeOneMoreCard(false);
        break;
      }
    }
  }

  private void PrintInfo()
  {
    Console.WriteLine("-------------------< Info >-------------------");

    var allPlayers = game.PlayerManager.GetAllPlayers();
    foreach (var player in allPlayers)
    {
      Console.WriteLine($"Name: {player.Name}, Score: {player.CurrentScore}, Active: {player.IsActive}");
    }
    
    Console.WriteLine("-------------------< Info >-------------------");
  }

  private void PrintCurrentPlayer()
  {
    Console.WriteLine("-------------------< Player Info >-------------------");

    var nextPlayer = game.PlayerManager.NextPlayer();
    Console.WriteLine($"Ход игрока: {nextPlayer.Name}. Текущее кол-во очков: {nextPlayer.CurrentScore}");
    
    Console.WriteLine("-------------------< Player Info >-------------------");
  }

  private void PrintWinner()
  {
    Console.WriteLine("-------------------< Winner! >-------------------");

    var winner = game.Winner;
    Console.WriteLine($"Победитель: {winner.Name}!");
    
    Console.WriteLine("-------------------< Winner! >-------------------");
  }
}