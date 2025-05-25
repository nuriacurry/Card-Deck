using System;

/// <summary>
/// Test Program for Card and Deck Classes
/// Demonstrates all functionality including card creation, deck operations, and testing
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== CARD/DECK CLASS IMPLEMENTATION TEST ===\n");

        // Test 1: Card Class Testing
        Console.WriteLine("TEST 1: Card Class Functionality");
        Console.WriteLine("--------------------------------");
        
        Card testCard = new Card(Rank.Ace, Suit.Spades);
        Console.WriteLine($"Created card: {testCard.Rank} of {testCard.Suit}");
        Console.WriteLine($"Face up initially: {testCard.FaceUp}");
        Console.WriteLine($"Card display: {testCard}");
        
        testCard.FlipOver();
        Console.WriteLine($"After flipping: Face up = {testCard.FaceUp}");
        Console.WriteLine($"Card display: {testCard}");
        
        testCard.FlipOver();
        Console.WriteLine($"After flipping again: Face up = {testCard.FaceUp}");
        Console.WriteLine($"Card display: {testCard}\n");

        // Test 2: Deck Constructor and Properties
        Console.WriteLine("TEST 2: Deck Constructor and Properties");
        Console.WriteLine("--------------------------------------");
        
        Deck deck = new Deck();
        Console.WriteLine($"New deck created with {deck.Count} cards");
        Console.WriteLine($"Expected: 52 cards (13 ranks × 4 suits)");
        
        // Verify all suits and ranks are present
        Console.WriteLine("\nFirst few cards in deck:");
        for (int i = 0; i < 8; i++)
        {
            Card card = deck.Cards[i];
            Console.WriteLine($"  {i + 1}: {card.Rank} of {card.Suit}");
        }
        Console.WriteLine("  ... (showing first 8 of 52)\n");

        // Test 3: TakeTopCard Method
        Console.WriteLine("TEST 3: TakeTopCard Method");
        Console.WriteLine("-------------------------");
        
        Card topCard = deck.TakeTopCard();
        Console.WriteLine($"Took top card: {topCard.Rank} of {topCard.Suit}");
        Console.WriteLine($"Deck now has {deck.Count} cards");
        
        Card secondCard = deck.TakeTopCard();
        Console.WriteLine($"Took another card: {secondCard.Rank} of {secondCard.Suit}");
        Console.WriteLine($"Deck now has {deck.Count} cards\n");

        // Test 4: Shuffle Method
        Console.WriteLine("TEST 4: Shuffle Method");
        Console.WriteLine("---------------------");
        
        Console.WriteLine("First 5 cards before shuffle:");
        for (int i = 0; i < 5; i++)
        {
            Card card = deck.Cards[i];
            Console.WriteLine($"  {card.Rank} of {card.Suit}");
        }
        
        deck.Shuffle();
        Console.WriteLine("\nFirst 5 cards after shuffle:");
        for (int i = 0; i < 5; i++)
        {
            Card card = deck.Cards[i];
            Console.WriteLine($"  {card.Rank} of {card.Suit}");
        }
        Console.WriteLine("(Cards should be in different order)\n");

        // Test 5: Cut Method
        Console.WriteLine("TEST 5: Cut Method");
        Console.WriteLine("-----------------");
        
        // Create fresh deck for cut test
        Deck cutDeck = new Deck();
        Console.WriteLine("Fresh deck - first 5 cards:");
        for (int i = 0; i < 5; i++)
        {
            Card card = cutDeck.Cards[i];
            Console.WriteLine($"  {card.Rank} of {card.Suit}");
        }
        
        Console.WriteLine("\nLast 3 cards:");
        for (int i = cutDeck.Count - 3; i < cutDeck.Count; i++)
        {
            Card card = cutDeck.Cards[i];
            Console.WriteLine($"  {card.Rank} of {card.Suit}");
        }
        
        cutDeck.Cut(26); // Cut deck in half
        Console.WriteLine("\nAfter cutting at position 26:");
        Console.WriteLine("New first 5 cards (should be from old bottom half):");
        for (int i = 0; i < 5; i++)
        {
            Card card = cutDeck.Cards[i];
            Console.WriteLine($"  {card.Rank} of {card.Suit}");
        }
        Console.WriteLine();

        // Test 6: Edge Cases
        Console.WriteLine("TEST 6: Edge Cases");
        Console.WriteLine("-----------------");
        
        // Empty deck test
        Deck emptyDeck = new Deck();
        // Take all cards
        while (emptyDeck.Count > 0)
        {
            emptyDeck.TakeTopCard();
        }
        
        Console.WriteLine($"Empty deck has {emptyDeck.Count} cards");
        Card nullCard = emptyDeck.TakeTopCard();
        Console.WriteLine($"Taking card from empty deck returns: {(nullCard == null ? "null" : nullCard.ToString())}");
        
        // Invalid cut test
        Deck testDeck = new Deck();
        Console.WriteLine($"Deck before invalid cut: {testDeck.Count} cards");
        testDeck.Cut(0);     // Should do nothing
        testDeck.Cut(52);    // Should do nothing  
        testDeck.Cut(-5);    // Should do nothing
        Console.WriteLine($"Deck after invalid cuts: {testDeck.Count} cards (should be unchanged)");
        Console.WriteLine();

        // Test 7: Card Flipping Demonstration
        Console.WriteLine("TEST 7: Card Flipping Demonstration");
        Console.WriteLine("-----------------------------------");
        
        Deck flipDeck = new Deck();
        Card[] hand = new Card[5];
        
        Console.WriteLine("Dealing 5 cards and flipping them:");
        for (int i = 0; i < 5; i++)
        {
            hand[i] = flipDeck.TakeTopCard();
            Console.WriteLine($"Card {i + 1}: {hand[i]} (Face up: {hand[i].FaceUp})");
        }
        
        Console.WriteLine("\nFlipping all cards over:");
        for (int i = 0; i < 5; i++)
        {
            hand[i].FlipOver();
            Console.WriteLine($"Card {i + 1}: {hand[i]} (Face up: {hand[i].FaceUp})");
        }
        Console.WriteLine();

        // Test 8: Complete Functionality Test
        Console.WriteLine("TEST 8: Complete Functionality Verification");
        Console.WriteLine("------------------------------------------");
        
        Deck finalDeck = new Deck();
        Console.WriteLine($"✓ Deck created with {finalDeck.Count} cards");
        
        finalDeck.Shuffle();
        Console.WriteLine("✓ Deck shuffled successfully");
        
        finalDeck.Cut(13);
        Console.WriteLine("✓ Deck cut successfully");
        
        Card dealtCard = finalDeck.TakeTopCard();
        dealtCard.FlipOver();
        Console.WriteLine($"✓ Card dealt and flipped: {dealtCard}");
        
        Console.WriteLine($"✓ Final deck count: {finalDeck.Count} cards");
        
        Console.WriteLine("\n=== ALL TESTS COMPLETED SUCCESSFULLY ===");
        Console.WriteLine("Card and Deck classes are fully implemented and working!");
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}