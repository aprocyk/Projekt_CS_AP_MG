using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;


using BJLogic;



namespace BlackJack_Game
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static int startXPos = 0; //Pozycja początkowa kart gracza
        private static int playerCardYPos = 0;
        private int playerCardXPos = startXPos;
        
        private static int dealerStartXPos = 294;
        private static int dealerCardYPos = 0;
        private int dealerCardXPos = dealerStartXPos;

        private string[] PlayerCardUpdate { get { string[] param = textboxPlayerCards.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); return param; } }
        private string[] DealerCardUpdate { get { string[] param = D1.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); return param; } }

        public List<System.Windows.Controls.Image> playerCardsToDisplay;
        public List<System.Windows.Controls.Image> dealerCardsToDisplay;


        public int totaldealerwithbolckcard = 0;
        public MainWindow()
        {
            InitializeComponent();
            playerCardsToDisplay = new List<System.Windows.Controls.Image>();
            dealerCardsToDisplay = new List<System.Windows.Controls.Image>();
            D1.Visibility = Visibility.Hidden;
            textboxPlayerCards.Visibility = Visibility.Hidden;
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new ImageSourceConverter().ConvertFromString(@"../../CardsSprites/Blacjacktable.png") as ImageSource;
            Board.Background = myBrush;
            




        }
        Game blackjack = new Game();
        private void Stand_Click(object sender, RoutedEventArgs e)
        {
            blackjack.DealerMove();

            dealerScore.Content = blackjack.GetTotalDealer().ToString();
            D1.Text = blackjack.DealerCards;

            info.Content = blackjack.EndMessage();

            labelHasA.Content = "";

            HitButton.Visibility = Visibility.Hidden;
            StandButton.Visibility = Visibility.Hidden;
            

            DealerCardsRemoveAndBackToStartPosition();
            DealerCardDraw();
        }
        public int gettotaldealerwithbolckcard()
        {
            return blackjack.GetTotalDealer() - Game.DealerSecondCard.GetValue(); ; //Punkty dealera bez zakrytej karty.
        }

        private void newGame_Click(object sender, EventArgs e)
        {


            // Pokaż wszystkie elementy po rozpoczęciu gry

            label1.Visibility = Visibility.Visible;
            label2.Visibility = Visibility.Visible;
            dealerScore.Visibility = Visibility.Visible;
            label4.Visibility = Visibility.Visible;
            dealerScore.Visibility = Visibility.Visible;
            label6.Visibility = Visibility.Visible;
            info.Visibility = Visibility.Visible;
            playerScore.Visibility = Visibility.Visible;

            label_Cards_left.Visibility = Visibility.Visible;
            Cards_left.Visibility = Visibility.Visible;

            if (CardLeftCheck())
            {
                PlayerCardsRemoveAndBackToStartPosition();
                DealerCardsRemoveAndBackToStartPosition();
                labelHasA.Content = "";
                blackjack.EndGame();
                blackjack.GameStart();

                Cards_left.Content = CardDeck.GetCardCount.ToString();



                //Wyświetl 2 pierwsze karty gracza
                D1.Text = blackjack.DealerCards;
                textboxPlayerCards.Text = blackjack.PlayerCards;
                //Punkty
                playerScore.Content = blackjack.GetTotalPlayer().ToString();

                dealerScore.Content = gettotaldealerwithbolckcard().ToString();


                HitButton.Visibility = Visibility.Visible;
                StandButton.Visibility = Visibility.Visible;

                if (blackjack.PlayerHasA())
                {
                    labelHasA.Content = "As(1 lub 11)";
                }

                info.Content = "Dobierz kartę albo spasuj";
                if (blackjack.GetTotalPlayer() == 21) HitButton.Visibility = Visibility.Hidden;


                PlayerCardDraw();
                DealerCardDraw();

                DrawBlockedDealer();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("W talii nie ma wystarczającej ilości kart, czy chcesz zacząć od nowa?",
                                  "Błąd",
                                 MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    blackjack.Shuffle_new_Deck();
                    Cards_left.Content = CardDeck.GetCardCount.ToString();

                    PlayerCardsRemoveAndBackToStartPosition();
                    DealerCardsRemoveAndBackToStartPosition();
                    labelHasA.Content = "";
                    blackjack.EndGame();
                    blackjack.GameStart();
                    Cards_left.Content = CardDeck.GetCardCount.ToString();
                    
                    D1.Text = blackjack.DealerCards;
                    textboxPlayerCards.Text = blackjack.PlayerCards;

                    playerScore.Content = blackjack.GetTotalPlayer().ToString();

                    dealerScore.Content = gettotaldealerwithbolckcard().ToString();
                    info.Content = "Dobierz kartę albo spasuj";
                    if (blackjack.GetTotalPlayer() == 21) HitButton.Visibility = Visibility.Hidden;
                    HitButton.Visibility = Visibility.Visible;
                    StandButton.Visibility = Visibility.Visible;
                    PlayerCardDraw();
                    DealerCardDraw();
                    DrawBlockedDealer();
                }
                else
                {
                    this.Close();
                }

            }

        }

        private void HitButton_Click(object sender, EventArgs e)
        {

            labelHasA.Content = "";

            blackjack.Hit(Game.PlayerCardsList);

            if (blackjack.PlayerHasA())
            {
                labelHasA.Content = "As (1 lub 11)";
            }



            if (blackjack.IsOverflow())
            {

                info.Content = "Dealer wygrywa!";
                HitButton.Visibility = Visibility.Hidden;
                StandButton.Visibility = Visibility.Hidden;

                DealerCardsRemoveAndBackToStartPosition();
                DealerCardDraw();
                dealerScore.Content = blackjack.GetTotalDealer().ToString();
            }

            playerScore.Content = blackjack.GetTotalPlayer().ToString();

            textboxPlayerCards.Text = blackjack.PlayerCards;
            if (blackjack.GetTotalPlayer() == 21) HitButton.Visibility = Visibility.Hidden;


            PlayerCardsRemoveAndBackToStartPosition();
            PlayerCardDraw();
        }

        private void StandButton_Click(object sender, EventArgs e)
        {
            blackjack.DealerMove();

            dealerScore.Content = blackjack.GetTotalDealer().ToString();
            D1.Text = blackjack.DealerCards;

            info.Content = blackjack.EndMessage();

            labelHasA.Content = "";

            HitButton.Visibility = Visibility.Hidden;
            StandButton.Visibility = Visibility.Hidden;


            DealerCardsRemoveAndBackToStartPosition();
            DealerCardDraw();
        }

        /// <summary>
        /// Rysowanie kart gracza
        /// </summary>
        /// <param name="card">Przenosimy karte ktora chcemy narysowac</param>
        private void DrawPlayer(String card)
        {
            playerCardXPos += 35;
            // BitmapImage bi = new BitmapImage();
            //bi.BeginInit();
            //bi.UriSource = new Uri(@"CardsSprites/2♠.png");
            //bi.EndInit();
            //string uriString = "CardsSprites/" + card + ".png";
            System.Windows.Controls.Image newCard = new System.Windows.Controls.Image
            {
                Name = "newCard",
                Height = 99,
                Width = 72,
                Source = new ImageSourceConverter().ConvertFromString(@"../../CardsSprites/" + card + ".png") as ImageSource
            };
            //newCard.Image = img;
            PlayerCards.Children.Add(newCard);
            Canvas.SetTop(newCard, playerCardYPos); //Location = new System.Drawing.Point(playerCardXPos, playerCardYPos);
            Canvas.SetLeft(newCard, playerCardXPos);
            Canvas.SetZIndex(newCard, 1);
            //this.Controls.Add(newCard);
            //newCard.BringToFront();
            playerCardsToDisplay.Add(newCard);
        }


        /// <summary>
        /// Losowanie 2 pierwszych kart gracza
        /// </summary>
        private void PlayerCardDraw()
        {
            string[] cardUpdate = PlayerCardUpdate;// Wprowadz dane do tablicy
            for (int i = 0; i < cardUpdate.Length; i = i + 2)
            {
                string card;
                card = cardUpdate[i] + cardUpdate[i + 1];
                DrawPlayer(card);
            }
        }

        /// <summary>
        /// Rysowanie kart dealera
        /// </summary>
        /// <param name="card">Przenosimy karte ktora chcemy narysowac</param>
        private void DrawDealer(string card)
        {
            dealerCardXPos -= 35;//Odleglosc miedzy kartami
            System.Windows.Controls.Image newCard = new System.Windows.Controls.Image
            {
                
                Name = "newCard",
                Height = 99,
                Width = 72,
                Source = new ImageSourceConverter().ConvertFromString(@"../../CardsSprites/" + card + ".png") as ImageSource
            };
            
            
            DealerCards.Children.Add(newCard);
            Canvas.SetTop(newCard, dealerCardYPos); //Location = new System.Drawing.Point(playerCardXPos, playerCardYPos);
            Canvas.SetLeft(newCard, dealerCardXPos);
            Canvas.SetZIndex(newCard, 1);
            dealerCardsToDisplay.Add(newCard);//Wyswietl karte
        }

        /// <summary>
        /// Losowanie 2 pierwszych kart Dealera
        /// </summary>
        private void DealerCardDraw()
        {
            string[] cardUpdate = DealerCardUpdate;
            for (int i = 0; i < cardUpdate.Length; i = i + 2)
            {
                string card;
                card = cardUpdate[i] + cardUpdate[i + 1];
                DrawDealer(card);
            }
        }


        /// <summary>
        /// Usuwamy karty Gracza i powracamy do domyslnej pozycji rysowania
        /// </summary>
        private void PlayerCardsRemoveAndBackToStartPosition()
        {
            PlayerCards.Children.Clear();
            playerCardXPos = startXPos;
        }

        /// <summary>
        /// Usuwamy karty Dealera i powracamy do domyslnej pozycji rysowania
        /// </summary>
        private void DealerCardsRemoveAndBackToStartPosition()
        {
            DealerCards.Children.Clear();
            dealerCardXPos = dealerStartXPos;
        }

        /// <summary>
        /// Dobierz zasłonieta karte
        /// </summary>
        private void DrawBlockedDealer()
        {
            //dealerCardYPos -= 35;
            System.Windows.Controls.Image newCard = new System.Windows.Controls.Image
            {
                Name = "newCardBack",
                Height = 99,
                Width = 72,
                Source = new ImageSourceConverter().ConvertFromString(@"../../CardsSprites/b2fv.png") as ImageSource
            };
            DealerCards.Children.Add(newCard);
            Canvas.SetTop(newCard, dealerCardYPos); //Location = new System.Drawing.Point(playerCardXPos, playerCardYPos);
            Canvas.SetLeft(newCard, dealerCardXPos);
            Canvas.SetZIndex(newCard, 2);

            //newCard.Location = new System.Drawing.Point(329, 18);

        }

        private bool CardLeftCheck()
        {
            if (Convert.ToInt64(Cards_left.Content) >= 11) return true;
            else return false;

        }

        private void label_Cards_left_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}

