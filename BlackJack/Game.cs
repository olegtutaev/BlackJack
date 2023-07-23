namespace BlackJack;

internal class Game
{
  public Game()
  {
    this.CardUtil = new CardUtil();
    this.IsNext = true;
  }

  public CardUtil CardUtil { get; }
  public bool IsNext { get; private set; }

  public void PlayGame(GameMode gameMode, int playerCount = 1)
  {
    CardUtil.ShuffleCardDeck(); // Перетасовка колоды.
    
    // Создать класс Player и положить его в List<Player> или класс, который будет хранить всех игроков и их состояние.
    // Создать Getter для игроков, точно так же как и для колоды карт.

    switch (gameMode)
    {
      case GameMode.PVE:
        // ...
        break;
      case GameMode.PVP:
        // ...
        break;
    }

    // ...
  }

  public void NextTurn()
  {
    // Тут главная логика, где ходят игроки.

    if (CheckWin()) IsNext = false; // <- тут спорно. Можно изменить.
  }

  private bool CheckWin()
  {
    // Проверка выйгрыша или проигрыша игрока.
    return false;
  }

  private void CalculateScoresUser(int score)
  {
    // Увеличить кол-во очков у игроока.
    // Можно перенести этот метод, по желанию, в утильный класс для игроков.
  }

  private void CalculateScoresComputer(int score)
  {
    // Увеличить кол-во очков у ИИ.
    // Можно перенести этот метод, по желанию, в утильный класс для игроков.
  }

  private void TakeOneMoreCardUser(Player player) 
  {
    // Хочет взять ещё пользователь или нет
    // Если да, то даём.
  }

  private void TakeOneMoreCardComputer(Player player)
  {
    // Логика взятия карт для ИИ.
  }

  private void GiveCard(Player player)
  {
    // Тут даём игроку карту через метод GiveCard из класса CardUtil.
  }
}