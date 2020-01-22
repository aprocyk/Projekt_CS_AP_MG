using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJLogic
{
    public class Game
    {
        public int totaldealer = 0;
        protected int totalplayer = 0;

        public string DealerCards { get; protected set; }

        public static List<Card> PlayerCardsList { get; protected set; } = new List<Card>();

        public static List<Card> DealerCardsList { get; protected set; } = new List<Card>();

        public string PlayerCards { get; protected set; }


        protected Card PlayerFirstCard { get { return PlayerCardsList[0]; } }
        protected Card PlayerSecondCard { get { return PlayerCardsList[1]; } }


        protected Card DealerFirstCard { get { return DealerCardsList[0]; } }
        public static Card DealerSecondCard { get { return DealerCardsList[1]; } }


        protected int CardCount { get; set; }

        public Game(int cardCount = 11)
        {
            CardCount = cardCount;
        }

        protected CardDeck _deck = new CardDeck();

        /// <summary>
        /// Pobierz punkty gracza 
        /// </summary>
        public int GetTotalPlayer()
        {
            return totalplayer;
        }
        /// <summary>
        /// Pobierz punkty dealera  
        /// </summary> 
        public int GetTotalDealer()
        {
            return totaldealer;
        }

        /// <summary>
        /// Dealer dobiera 1 karte 
        /// </summary>
        public void DealerAddCard(List<Card> CurrentCardsList)
        {
            Card newcard = _deck.PickCard();

            totaldealer += newcard.GetValue();

            CurrentCardsList.Add(newcard);

            DealerCards += newcard.GetName() + " ";

            if (totaldealer > 21 & DealerHasA())
            {
                foreach (var CurrentCard in DealerCardsList)
                {
                    if (CurrentCard.cardNumber == 11)
                    {
                        CurrentCard.cardNumber = 1;
                        totaldealer -= 10;
                    }
                }
            }
        }

        /// <summary> 
        /// Gracz dobiera jedna karte 
        /// </summary> 
        public void PlayerAddCard(List<Card> CurrentCardList)
        {
            Card newcard = _deck.PickCard();

            totalplayer += newcard.GetValue();

            CurrentCardList.Add(newcard);

            PlayerCards += newcard.GetName() + " ";
        }

        /// <summary>
        /// Sprawdza czy gracz posiada Asa  
        /// </summary>
        /// <returns></returns>  
        public bool PlayerHasA()
        {
            foreach (var CurrentCard in PlayerCardsList)
            {
                if (CurrentCard.cardNumber == 11)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sprawdza czy dealer posiada Asa   
        /// </summary>  
        /// <returns></returns> 
        public bool DealerHasA()
        {
            foreach (var CurrentCard in DealerCardsList)
            {
                if (CurrentCard.cardNumber == 11)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Koniec gry: ustalenie zwycięzcy
        /// </summary>
        /// <returns></returns>
        public int EndCheck()
        {
            if ((totaldealer <= 21 & totaldealer > totalplayer) || totalplayer > 21)
            {

                return 0;
            }
            if ((totalplayer <= 21 & totalplayer > totaldealer) || totaldealer > 21)
            {

                return 1;
            }
            else
            {

            }
            return 2;
        }



        /// <summary>      
        /// Koniec gry: ustalenie sposobu wygranej
        /// </summary>
        /// <returns></returns> 
        public string EndMessage()
        {
            if (totaldealer == totalplayer)
            {
                return "Remis. Tyle samo punktów";
            }
            if (totaldealer > 21 & totalplayer > 21)
            {
                return "Remis. Sprawdzanie kart u dealera i gracza.";
            }
            if (totaldealer == 21)
            {
                return "Dealer wygrywa. Blackjack!";
            }
            if (totaldealer > 21)
            {
                return "Gracz wygrywa. Dealer przekroczył liczbę punktów.";
            }
            if (totalplayer == 21)
            {
                return "Gracz wygrywa. Blackjack!";
            }
            if (totalplayer > 21)
            {
                return "Dealer wygrywa. Gracz przekroczył ilośc punktów.";
            }
            if (totalplayer > totaldealer)
            {
                return "Gracz wygrywa punktowo.";
            }
            if (totaldealer > totalplayer)
            {
                return "Dealer wygrywa punktowo.";
            }

            EndGame();


            return "";
        }

        /// <summary>
        /// Reset punktow
        /// </summary>
        public void EndGame()
        {
            totaldealer = 0;
            totalplayer = 0;

            PlayerCardsList.Clear();

            DealerCardsList.Clear();

            PlayerCards = "";
            DealerCards = "";

        }



        /// <summary>
        /// Rozpoczecie gry: Gracz i Dealer otrzymują po 2 karty  
        /// </summary> 
        public void GameStart()
        {

            _deck.Shuffle(CardCount);

            PlayerAddCard(PlayerCardsList);
            PlayerAddCard(PlayerCardsList);

            DealerAddCard(DealerCardsList);
            DealerAddCard(DealerCardsList);

            if (GetTotalDealer() == 22)
                totaldealer = 2;
        }

        /// <summary>
        /// Ruch dealera, sprawdzenie sytuacji punktowej
        /// </summary>
        /// <returns></returns>
        public void DealerMove()
        {

            if (totalplayer > 21)
            {
                //do nothing
            }
            else if (totaldealer == 16)
            {
                //do nothing too
            }
            else
            {
                while (totaldealer < 17)
                {
                    DealerAddCard(DealerCardsList);
                }
            }

            EndCheck();
            EndMessage();
        }

        /// <summary>
        /// Przegrana gracza poprzez przekroczenie ilosci punktow
        /// </summary>
        /// <returns></returns>
        public bool IsOverflow()
        {
            if (totalplayer > 21 & !PlayerHasA())
            {

                return true;
            }

            return false;

        }

        /// <summary>
        /// Dobierz karte 
        /// </summary>
        /// <returns></returns>
        public void Hit(List<Card> CurrentCardList)
        {
            PlayerAddCard(CurrentCardList);

            if (totalplayer > 21 & PlayerHasA())
            {
                foreach (var CurrentCard in CurrentCardList)
                {
                    if (CurrentCard.cardNumber == 11)
                    {
                        CurrentCard.cardNumber = 1;
                        totalplayer -= 10;
                    }
                }
            }
        }

        public void Shuffle_new_Deck()
        {
            _deck.Shuffle_new_deck();
        }

    }
}
