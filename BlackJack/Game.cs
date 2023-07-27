namespace BlackJack;

internal class Game
{
    public Game()
  {
    this.CardUtil = new CardUtil();
    this.IsNext = true;
  }

  public static int userScores;
  public static int computerScores;
  public static int dangerSum = 11;
  public CardUtil CardUtil { get; }
  public bool IsNext { get; private set; }

  public void PlayGame(GameMode gameMode, int playerCount = 1)
  {
    CardUtil.ShuffleCardDeck(); // Перетасовка колоды.
    
    List<Player> player = new List<Player>();

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

  /// <summary>
  /// Принимает значение последней полученной карты и суммирует с уже набранными очками.
  /// </summary>
  /// <param name="lastUserCardValue"></param>
  /// <returns></returns>
  private static int GetUserScores(int lastUserCardValue)
  {
    // Увеличить кол-во очков у игрока.
    // Можно перенести этот метод, по желанию, в утильный класс для игроков.

    return userScores += lastUserCardValue;
  }

  /// <summary>
  /// Принимает значение последней полученной карты и суммирует с уже набранными очками.
  /// </summary>
  /// <param name="lastComputerCardValue"></param>
  /// <returns></returns>
  private static int GetComputerScores(int lastComputerCardValue)
  {
    // Увеличить кол-во очков у ИИ.
    // Можно перенести этот метод, по желанию, в утильный класс для игроков.

    return computerScores += lastComputerCardValue;
  }

  private void TakeOneMoreCardUser(Player player) 
  {
    if (Console.ReadKey().Key == ConsoleKey.Y)
    {
      GiveCard(player);
      GetUserScores((int)player.ReceivedCards.Last().CardType);
    }
    TakeOneMoreCardComputer(computerScores);
    // Хочет взять ещё пользователь или нет
    // Если да, то даём.
  }

  /// <summary>
  /// Принимает значение суммарных очков у ИИ. Если оно больше или равно dangerSum, ИИ задумывается, брать ли ещё карту за счёт рандома. Если нет, то ход передаётся
  /// следующему игроку. dangerSum может быть изменено в процессе тестирования. Предварительно оно равно 11.
  /// </summary>
  /// <param name="computerScores"></param>
  private void TakeOneMoreCardComputer(int computerScores)
  {
    // Логика взятия карт для ИИ.

    if (computerScores >= dangerSum)
    {
      Random random = new Random();

      if (random.Next(100) < 50)
        GiveCard(player); // На 24.07.23 10:30 неизвестно, с какими параметрами передавать метод GiveCard, так как класс Player не реализован.
      else
        IsNext = true;
    }
    else
      GiveCard(player);   // На 24.07.23 10:30 неизвестно, с какими параметрами передавать метод GiveCard, так как класс Player не реализован.
  }

  private void GiveCard(Player player)
  {
    player.ReceivedCards.Add(CardUtil.GiveCard());
    // Тут даём игроку карту через метод GiveCard из класса CardUtil.
  }
}