namespace BlackJack;

public class ConsoleGameStarter
{
  private Game game = new();
  
  public void Start()
  {
    game.PlayGame(GameMode.PVE); // Подготовка игры.
    
    while (game.IsNext)
    {
      PrintInfo();
      
      game.NextTurn();
    }
  }

  private void PrintInfo()
  {
    // Вывод актуальной информации в консоль.
  }
}