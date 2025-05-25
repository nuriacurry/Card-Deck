using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Deck
{
    private List<Card> cards = new List<Card>();

    // Deck Constructor
    public Deck()
    {
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                // Create a new card and add it to the deck
                Card newCard = new Card(rank, suit);
                cards.Add(newCard);
            }
        }
    }

    // Property to get Cards
    public List<Card> Cards
    {
        get { return cards; }
    }

    // Property to get count of cards in deck
    public int Count
    {
        get { return cards.Count; }
    }

    // Takes top card from deck (if deck is not empty, otherwise return null)
    public Card TakeTopCard()
    {
        if (cards.Count > 0)
        {
            Card topCard = cards[0]; // Top card is first in list
            cards.RemoveAt(0);       // Remove it from deck
            return topCard;
        }
        else
        {
            return null; // Deck is empty
        }
    }

    // Shuffle Method using Fisher-Yates algorithm
    public void Shuffle()
    {
        Random random = new Random();
        
        // Fisher-Yates shuffle algorithm
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int randomIndex = random.Next(0, i + 1);
            
            // Swap cards at positions i and randomIndex
            Card temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    // Cut method - splits deck at index and puts bottom portion on top
    public void Cut(int index)
    {
        if (index > 0 && index < cards.Count)
        {
            // Take cards from index to end
            List<Card> bottomPortion = cards.GetRange(index, cards.Count - index);
            
            // Take cards from start to index
            List<Card> topPortion = cards.GetRange(0, index);
            
            // Clear current deck
            cards.Clear();
            
            // Add bottom portion first (becomes new top)
            cards.AddRange(bottomPortion);
            
            // Add top portion second (becomes new bottom)
            cards.AddRange(topPortion);
        }
    }

    // Helper method to display all cards in deck
    public void DisplayDeck()
    {
        Console.WriteLine($"Deck contains {cards.Count} cards:");
        for (int i = 0; i < cards.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {cards[i].Rank} of {cards[i].Suit}");
        }
        Console.WriteLine();
    }
}