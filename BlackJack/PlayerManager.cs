namespace BlackJack;

/// <summary>
/// Класс для работы с игроками.
/// </summary>
public class PlayerManager
{
  private Queue<Player> queuePlayers;

  public PlayerManager()
  {
    queuePlayers = new Queue<Player>();
  }

  /// <summary>
  /// Добавляет игроков в очередь.
  /// </summary>
  /// <param name="players">Список игроков.</param>
  public void AddPlayers(List<Player> players)
  {
    Console.WriteLine("Добавление игроков в очередь...");
    
    queuePlayers.Clear();
    
    foreach (var player in players)
      queuePlayers.Enqueue(player);
  }

  /// <summary>
  /// Берёт игрока из начала очереди и перемещает его в конец очереди.
  /// </summary>
  /// <returns>Вернёт игрока.</returns>
  public Player GetNextPlayer()
  {
    var player = queuePlayers.Dequeue();
    queuePlayers.Enqueue(player);

    Console.WriteLine($"Игрок {player.Name} встал в конец очереди...");
    
    return player;
  }

  /// <summary>
  /// Берёт игрока из начала очереди без перемещения его в конец очереди.
  /// </summary>
  /// <returns>Вернёт игрока.</returns>
  public Player NextPlayer()
  {
    var player = queuePlayers.Peek();
    return player;
  }

  /// <summary>
  /// Даст всех игроков.
  /// </summary>
  /// <returns>Список игроков</returns>
  public List<Player> GetAllPlayers()
  {
    return queuePlayers.ToList();
  }

  /// <summary>
  /// Количество активных игроков.
  /// </summary>
  /// <returns>Число активных игроков.</returns>
  public int GetPlayersActiveCount()
  {
    return queuePlayers.Count(player => player.IsActive);
  }

  /// <summary>
  /// Первый активный игрок, которого найдёт в очереди.
  /// </summary>
  /// <returns>Даст игрока.</returns>
  public Player GetFirstActivePlayer()
  {
    return queuePlayers.FirstOrDefault(player => player.IsActive);
  }
}