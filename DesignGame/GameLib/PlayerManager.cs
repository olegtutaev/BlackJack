using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsDesign.GameLib
{
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
      foreach (var player in players)
        queuePlayers.Enqueue(player);
    }

    /// <summary>
    /// Дать игрока из начала очереди и перемещает его в конец очереди.
    /// </summary>
    /// <returns>Вернёт игрока.</returns>
    public Player GetNextPlayer()
    {
      var player = queuePlayers.Peek();
      queuePlayers.Enqueue(player);
      return player;
    }

    /// <summary>
    /// Дать игрока из начала очереди без перемещения его в конец очереди.
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
    //public List<Player> GetAllPlayers()
    //{
    //  // ...
    //}

    ///// <summary>
    ///// Количество активных игроков.
    ///// </summary>
    ///// <returns>Число активных игроков.</returns>
    //public int GetPlayersActiveCount()
    //{
    //  // ...
    //}

    ///// <summary>
    ///// Первый активный игрок, которого найдёт в очереди.
    ///// </summary>
    ///// <returns>Даст игрока.</returns>
    //public Player GetFirstActivePlayer()
    //{
    //  // ...
    //}
  }
}
