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
    // ...
  }

  /// <summary>
  /// Дать игрока из начала очереди и перемещает его в конец очереди.
  /// </summary>
  /// <returns>Вернёт игрока.</returns>
  public Player GetNextPlayer()
  {
    // ...
  }

  /// <summary>
  /// Дать игрока из начала очереди без перемещения его в конец очереди.
  /// </summary>
  /// <returns>Вернёт игрока.</returns>
  public Player NextPlayer()
  {
    // ...
  }

  /// <summary>
  /// Даст всех игроков.
  /// </summary>
  /// <returns>Список игроков</returns>
  public List<Player> GetAllPlayers()
  {
    // ...
  }

  /// <summary>
  /// Количество активных игроков.
  /// </summary>
  /// <returns>Число активных игроков.</returns>
  public int GetPlayersActiveCount()
  {
    // ...
  }

  /// <summary>
  /// Первый активный игрок, которого найдёт в очереди.
  /// </summary>
  /// <returns>Даст игрока.</returns>
  public Player GetFirstActivePlayer()
  {
    // ...
  }
}