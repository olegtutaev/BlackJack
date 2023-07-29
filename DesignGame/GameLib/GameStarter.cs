﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsDesign.GameLib
{
  /// <summary>
  /// Консольный стартер игры.
  /// </summary>
  public class GameStarter
  {
    private Game game = new Game();

    /// <summary>
    /// Запуск игры.
    /// </summary>
    public void Start()
    {
      // Заглушка, где инициализируется игрок и бот.
      //game.PlayGame(new List<Player> { new Player("Karusel'ka", false), new Player("Bot2000", true) });
      PrintInfo();

      while (true)
      {
        Console.WriteLine();
        PrintCurrentPlayer();

        if (!game.IsNextTurn()) continue;

        //if (!game.IsNext || !game.CheckPlayers()) break;

        //TryTakeMore();

        //if (!game.IsNext || !game.CheckPlayers()) break;

        PrintInfo();
      }

      Console.WriteLine();
      PrintWinner();
    }

    /// <summary>
    /// Логика взятия дополнительных карт.
    /// </summary>
    //private void TryTakeMore()
    //{
    //  if (game.PlayerManager.NextPlayer().IsAi)
    //  {
    //    game.TakeOneMoreCard(true);
    //    return;
    //  }


    //  while (true)
    //  {
    //    Console.Write("Хотите взять ещё карту? Y/N: ");
    //    var readLine = Console.ReadLine();

    //    if (readLine == "Y" || readLine == "y")
    //    {
    //      game.TakeOneMoreCard(true);
    //      break;
    //    }

    //    if (readLine == "N" || readLine == "n")
    //    {
    //      game.TakeOneMoreCard(false);
    //      break;
    //    }
    //  }
    //}

    private void PrintInfo()
    {
      Console.WriteLine("-------------------< Info >-------------------");

      //var allPlayers = game.PlayerManager.GetAllPlayers();
      //foreach (var player in allPlayers)
      //{
      //  Console.WriteLine($"Name: {player.Name}, Score: {player.CurrentScore}, Active: {player.IsActive}");
      //}
    }

    private void PrintCurrentPlayer()
    {
      Console.WriteLine("-------------------< Player Info >-------------------");

      var nextPlayer = game.PlayerManager.NextPlayer();
      Console.WriteLine($"Ход игрока: {nextPlayer.Name}. Current score: {nextPlayer.CurrentScore}");
    }

    private void PrintWinner()
    {
      Console.WriteLine("-------------------< Winner! >-------------------");

      var winner = game.Winner;
      Console.WriteLine($"Победитель: {winner.Name}!");
    }
  }
}