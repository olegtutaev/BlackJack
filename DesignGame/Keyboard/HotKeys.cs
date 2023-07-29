using SettingsDesign;
using SettingsDesign.GameLib;
using SettingsDesign_Elemets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettingsDesign_Keyboard
{
  /// <summary>
  /// Отработка горячих клавиш
  /// </summary>
  class HotKeys
  {
    static bool start = false;
    static bool rejection = false;

    static Game game = new Game();
    bool GameStarted;
    static Player User = new Player(false);
    static Player Bot = new Player(true);
    /// <summary>
    /// Действия, которые происходят при нажатии клавиши клавиатуры
    /// </summary>
    /// <param name="sender">Объект элмента управления</param>
    /// <param name="e">Данные для события Control.KeyDown </param>
    public void KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.ControlKey)
      {
        DataClass.VisibleInfoHelp();
      }
      else if (e.KeyCode == Keys.Enter)
      {

        if (rejection == true)
        {
          rejection = !rejection;
          InfoToolTipPanel.gameStart = true;
        }

        if (InfoToolTipPanel.gameStart)
        {
          DataClass.VisibleInfoPoints();
          InfoToolTipPanel.rejection = false;
          DataClass.ResetСards();
          game = new Game();
          game.PlayGame();
          InfoToolTipPanel.gameStart = false;
          new InfoToolTipPanel().LoadToolTipPanel();

          User = new Player(false);
          Bot = new Player(true);

          var Card = game.GiveCard(User);
          DataClass.GiveCardUser(Card.CardType.ToString(), Card.CardSuite.ToString());

          Card = game.GiveCard(User);
          DataClass.GiveCardUser(Card.CardType.ToString(), Card.CardSuite.ToString());

          Card = game.GiveCard(Bot);
          DataClass.GiveCardBot(Card.CardType.ToString(), Card.CardSuite.ToString());

          Card = game.GiveCard(Bot);
          DataClass.GiveCardBot(Card.CardType.ToString(), Card.CardSuite.ToString());
        }
        else
        {
          if (!rejection)
          {
            if (start)
            {
              var Card = game.GiveCard(User);
              DataClass.GiveCardUser(Card.CardType.ToString(), Card.CardSuite.ToString());
            }
            else start = !start;
          }
        }
      }
      else if ((e.KeyCode == Keys.Space) && (rejection == false))
      {
        rejection = true;
        InfoToolTipPanel.rejection = true;
        new InfoToolTipPanel().LoadToolTipPanel();
        DataClass.SetPointsUser(User.CurrentScore);
        DataClass.AddElementsGameForm();

        var whileChecker = true;
        while (whileChecker)
        {
          whileChecker = game.TakeOneMoreCardComputer(Bot, out var Card);
          if (Card != null)
            DataClass.GiveCardBot(Card.CardType.ToString(), Card.CardSuite.ToString());
        }
        DataClass.VisibleCardsBot();
      }
      else if (e.KeyCode == Keys.Escape) Application.Exit();

      //DataClass.VisibleInfoPoints();

      //во все ифы которые устанавливают rejection НАДО
      //както обновляет табло с хоткеями, как будто новая игра. Ну или на то которое появляется после нажатия пробела.

      DataClass.SetPointsUser(User.CurrentScore);
      DataClass.informationBoardOfPoints.Focus();
      
      if (User.CurrentScore > 21)
      {
        rejection = true;
        DataClass.VisibleInfoLoosIsOverkill();
        InfoToolTipPanel.rejection = true;
        new InfoToolTipPanel().LoadToolTipPanel();
      }
      else if(User.CurrentScore == 21)
      {
        rejection = true;
        DataClass.VisibleInfoVicroryFull();
        InfoToolTipPanel.rejection = true;
        new InfoToolTipPanel().LoadToolTipPanel();
      }  
      else if ((Bot.CurrentScore > 21)
        && (rejection == true))
      {
        //у бота нет инфопанели о том что у него перебор
        DataClass.VisibleInfoVicroryMore(Bot.CurrentScore, User.CurrentScore);
      }
      else if((User.CurrentScore > Bot.CurrentScore)
        && (rejection == true))
      {
        DataClass.VisibleInfoVicroryMore(Bot.CurrentScore, User.CurrentScore);
      }
      else if ((User.CurrentScore < Bot.CurrentScore)
        && (rejection == true))
      {
        DataClass.VisibleInfoLoosIsLess(Bot.CurrentScore, User.CurrentScore);
      }
      else if ((User.CurrentScore == Bot.CurrentScore) 
        && (rejection == true))
      {
        DataClass.VisibleInfoDraw();
      }

    }

    /// <summary>
    /// Действия, которые происходят при отпускании клавиши клавиатуры
    /// </summary>
    /// <param name="sender">Объект элмента управления</param>
    /// <param name="e">Данные для события Control.KeyUp </param>
    public void KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.ControlKey)
      {
        DataClass.informationBoardHelp.Visible = false;
      }
      DataClass.informationBoardOfPoints.Focus();
    }
  }
}
