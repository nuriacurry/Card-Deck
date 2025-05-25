using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Card
{
    // Fields
    private Rank rank;
    private Suit suit;
    private bool faceUp;

    // Card Constructor
    public Card(Rank rank, Suit suit)
    {
        this.rank = rank;
        this.suit = suit;
        this.faceUp = false; // Cards start face down
    }

    // Properties for all fields
    public Rank Rank 
    { 
        get { return rank; } 
    }

    public Suit Suit 
    { 
        get { return suit; } 
    }

    public bool FaceUp 
    { 
        get { return faceUp; } 
    }

    // FlipOver method implementation
    public void FlipOver()
    {
        faceUp = !faceUp; // Toggle face up/down state
    }

    // Override ToString for easy display
    public override string ToString()
    {
        if (faceUp)
            return $"{rank} of {suit}";
        else
            return "Face Down Card";
    }
}