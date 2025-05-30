using System.Collections.Generic;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("*** DECK OF WONDERS ***");
if(args.Length == 0){
    Console.Error.WriteLine($"Error: No Arguments Provided");
    return 1;
}
Console.WriteLine($"Drawing {args[0]} cards!");
int number_of_cards = Convert.ToInt32(args[0]);
List<string> deck = new List<string>{"AD", "KD", "QD", "JD", "2D", "AC", "KC", "QC", "JC", "2C", 
                                        "AH", "KH", "QH", "JH", "2H", "AS", "KS", "QS", "JS", "2S", "J1", "J2"};

List<string> drawnCards = new List<string>();
Random random = new Random();
Console.WriteLine($"Starting Deck Items: {deck.Count}");
for(int i = 0; i < number_of_cards; i++){
    int index = random.Next(0, deck.Count);
    Console.WriteLine($"Adding {deck[index]}");
    drawnCards.Add(deck[index]);
    Console.WriteLine($"Removing {deck[index]}");
    deck.Remove(deck[index]);
    Console.WriteLine($"Current Deck Items: {deck.Count}");

}
foreach(var item in drawnCards){
    Console.WriteLine(item);
}
return 0;
