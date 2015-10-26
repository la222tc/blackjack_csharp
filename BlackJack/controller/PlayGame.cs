using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame : model.IGameObserver
    {
        private view.IView m_view;
        private model.Game m_game;

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            m_game = a_game;
            m_view = a_view;

            m_game.AddObserver(this);
        }

        private void DisplayTheGame()
        {
            m_view.DisplayWelcomeMessage();

            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }
        }

        public bool Play()
        {
           
            DisplayTheGame();

            view.userInput input = m_view.GetInput();

            if (input == view.userInput.Play)
            {
                m_game.NewGame();
            }
            else if (input == view.userInput.Hit)
            {
                m_game.Hit();
            }
            else if (input == view.userInput.Stand)
            {
                m_game.Stand();
            }

            return input != view.userInput.Quit;
        }

        public void CardDelay()
        {
            DisplayTheGame();
            System.Threading.Thread.Sleep(1500);
        }
    }
}
