using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJLogic
{
    public enum CardSuits
    {
        A = 1,
        J,
        Q,
        K
    }

    public enum CardColor
    {
        Spades = 0,
        Clubs,
        Diamods,
        Hearts
    }

    public class Card
    {
        public int cardNumber { get; set; }
        public CardColor Color { get; set; }
        public static string[] NumberName = new string[] { "", "A", "J", "Q", "K" }; // Nazwy uzywane do wybierania odpowiedniej figury
        public static string[] ColorName = new string[] { " \u2660", " \u2663", " \u2666", " \u2665" };  //Odpowiednio Spades, Clubs, Diamonds, Hearths uzywane do wybierania odpowiedniego koloru karty

        public static int GetPictureNumber(CardSuits color)
        {
            return 10 + (int)color;
        }

        public static int GetMaxSuit()
        {
            return GetPictureNumber(CardSuits.K);
        }

        public int GetValue()
        {
            if (cardNumber > 11)
            {
                return 10;
            }
            return cardNumber;
        }

        public string GetName()
        {
            string res = string.Empty;

            if (cardNumber >= 11)
            {
                res += NumberName[cardNumber - 10]; //Jezeli wartosc karty jest powyzej albo 11 wybieramy figury od Asa wzyż
            }
            else
            {
                res += cardNumber.ToString();
            }

            res += ColorName[(int)Color];
            return res;
        }
    }
}
