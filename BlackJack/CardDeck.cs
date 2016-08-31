using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace BlackJack
{        
    public class Card
    {
        public string name { get; set; }
        public Image image   { get; set; }
        public List<int> values { get; set; }
        public int random { get; set; }
    }
    public class CardDeck
    {

        public Queue<Card> Queue { get; set; }
        
        public Image back = Image.FromFile(Properties.Settings.Default.BackImage);
        List<Card> cards;

        List<int> values(FileInfo image)
        {
            List<int> returnV = new List<int>();
            string valueString = image.Name;
            valueString = valueString.Replace(".gif", "").Substring(1);
            switch (valueString)
            {
                case "j":
                case "q":
                case "k":
                    valueString = "10";
                    break;
                default:
                    break;
            }
            returnV.Add(Convert.ToInt32(valueString));
            if (returnV[0] == 1)
            {
                returnV.Add(11);
            }
            return returnV;
        }
        public CardDeck()
        {
            cards = new List<Card>(52);
            foreach (FileInfo f in new DirectoryInfo(Properties.Settings.Default.ImageDir).EnumerateFiles())
            {
                cards.Add(
                    new Card
                    {
                        name = f.Name.Replace(".gif",""),
                        image = Image.FromFile(f.FullName),
                        values = values(f)
                    });
            }
        }
        public void Shuffle(int seed)
        {
            
            Random random = new Random(seed);
            foreach (Card c in cards.OrderBy(i => i.name))//OrderBy is used to make sure the card are set in the same order each time
            {
                c.random = random.Next();
            }
            Queue = new Queue<Card>(cards.OrderBy(c => c.random));
        }
        public Card Next
        {
            get
            {
                return Queue.Dequeue();
            }
        }
    }
}
