bool ProcessDrawnCardAndCheckIsolation(string cardKey, Dictionary<string, Cards> descriptionsDict, List<string> drawnCardsList, Dictionary<Augury, int> auguryEffectsDict)
{
    Console.WriteLine($"--- Processing: {cardKey} ---");
    drawnCardsList.Add($"{cardKey}: {descriptionsDict[cardKey].Description}");
    auguryEffectsDict[descriptionsDict[cardKey].Augury] = auguryEffectsDict.TryGetValue(descriptionsDict[cardKey].Augury, out int count) ? count + 1 : 1;

    if (cardKey == "Isolation")
    {
        Console.WriteLine("Isolation drawn! All drawing stops.");
        return true; // Signal to stop all drawing
    }
    return false; // Continue drawing
}

Console.WriteLine("*** DECK OF WONDERS ***");
int number_of_cards;
if (args.Length == 0)
{
    Console.Write("Please enter the number of cards to draw: ");
    string? userInput = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(userInput) || !int.TryParse(userInput, out number_of_cards) || number_of_cards <= 0)
    {
        Console.Error.WriteLine("Invalid input. Please enter a valid number.");
        return 1; // Exit with an error code
    }
}
else
{
    if (!int.TryParse(args[0], out number_of_cards) || number_of_cards <= 0)
    {
        Console.Error.WriteLine($"Error: Invalid argument '{args[0]}'. Must be a positive number.");
        return 1; // Exit with an error code
    }
    number_of_cards = Convert.ToInt32(args[0]);
}

List<string> deck = new List<string>{"Chancellor", "Day", "Night", "Dawn", "Dusk", "Destiny", "Crown", "Lock", "Champion", "Coin", 
                                        "Vulture", "Chaos", "Order", "Beginning", "Mystery", "Isolation", "End", "Monster", "Knife",
                                        "Justice", "Student", "Mischief"};

if(number_of_cards > deck.Count)
{
    Console.WriteLine($"Requested {number_of_cards} cards, but deck only has {deck.Count}. Drawing {deck.Count} cards instead for the initial request.");
    number_of_cards = deck.Count;
}

Dictionary<string, Cards> descriptions = new Dictionary<string,Cards>()
{
    {"Chancellor", new Cards("Within 8 hours of drawing this card, you can cast Augury once as an action, requiring no material components. Use your Intelligence, Wisdom, or Charisma as the spellcasting ability (your choice).", Augury.Weal)},
    {"Day", new Cards("You gain a +1 bonus to saving throws. This benefit lasts until you finish a long rest.", Augury.Weal)},
    {"Night", new Cards("You gain darkvision within a range of 300 feet. This darkvision lasts for 8 hours.", Augury.Weal)},
    {"Dawn", new Cards("This card invigorates you. For the next 8 hours, you can add your proficiency bonus to your initiative rolls.", Augury.Weal)},
    {"Dusk", new Cards("This card supernaturally saps your energy. You have disadvantage on initiative rolls. This effect lasts until you finish a long rest, but it can be ended early by a Remove Curse spell or similar magic.", Augury.Woe)},
    {"Destiny", new Cards("This card protects you against an untimely demise. The first time after drawing this card that you would drop to 0 hit points from taking damage, you instead drop to 1 hit point.", Augury.Weal)},
    {"Crown", new Cards("You learn the Friends cantrip. Use your Intelligence, Wisdom, or Charisma as the spellcasting ability (your choice). If you already know this cantrip, the card has no effect.", Augury.WealAndWoe)},
    {"Lock", new Cards("You gain the ability to cast Knock 1d3 times. Use your Intelligence, Wisdom, or Charisma as the spellcasting ability (your choice).", Augury.Weal)},
    {"Champion", new Cards("You gain a +1 bonus to weapon attack and damage rolls. This bonus lasts for 8 hours.", Augury.Weal)},
    {"Coin", new Cards("Five pieces of jewelry, each worth 100 gp, or ten gemstones, each worth 50 gp, appear at your feet.", Augury.Weal)},
    {"Vulture", new Cards("One nonmagical item or piece of equipment in your possession (chosen by the DM) disappears. The item remains nearby but concealed for a short time, so it can be found with a successful DC 15 Wisdom (Perception) check. If the item isnt recovered within 1 hour, it disappears forever.", Augury.Woe)},
    {"Chaos", new Cards("You gain resistance to one of the following damage types (chosen by the DM): acid, cold, fire, lightning, or thunder. This resistance lasts for 1d12 days.", Augury.Weal)},
    {"Order", new Cards("You gain resistance to one of the following damage types (chosen by the DM): force, necrotic, poison, psychic, or radiant. This resistance lasts for 1d12 days.", Augury.Weal)},
    {"Beginning", new Cards("Your hit point maximum and current hit points increase by 2d10. Your hit point maximum remains increased in this way for the next 8 hours.", Augury.Weal)},
    {"Mystery", new Cards("You have disadvantage on Intelligence saving throws for 1 hour. Discard this card and draw from the deck again; together, the two draws count as one of your declared draws.", Augury.WealAndWoe)},
    {"Isolation", new Cards("You disappear, along with anything you are wearing or carrying, and become trapped in a harmless extradimensional space for 1d4 minutes. You draw no more cards. You then reappear in the space you left or the nearest unoccupied space. When you reappear, you must succeed on a DC 11 Constitution saving throw or have the poisoned condition for 1 hour as your body reels from the extradimensional travel.", Augury.Woe)},
    {"End", new Cards("This card is an omen of death. You take 2d10 necrotic damage, and your hit point maximum is reduced by an amount equal to the damage taken. This effect can’t reduce your hit point maximum below 10 hit points. This reduction lasts until you finish a long rest, but it can be ended early by a Remove Curse spell or similar magic.", Augury.Woe)},
    {"Monster", new Cards("This cards monstrous visage curses you. While cursed in this way, whenever you make a saving throw, you must roll 1d4 and subtract the number rolled from the total. The curse lasts until you finish a long rest, but it can be ended early with a Remove Curse spell or similar magic.", Augury.Woe)},
    {"Knife", new Cards("An uncommon magic weapon youre proficient with appears in your hands. The DM chooses the weapon.", Augury.Weal)},
    {"Justice", new Cards("You momentarily gain the ability to balance the scales of fate. For the next 8 hours, whenever you or a creature within 60 feet of you is about to roll a d20 with advantage or disadvantage, you can use your reaction to prevent the roll from being affected by advantage or disadvantage.", Augury.Weal)},
    {"Student", new Cards("You gain proficiency in Wisdom saving throws. If you already have this proficiency, you instead gain proficiency in Intelligence or Charisma saving throws (your choice).", Augury.Weal)},
    {"Mischief", new Cards("You receive an uncommon wondrous item (chosen by the DM), or you can draw two additional cards beyond your declared draws.", Augury.Weal)}
};

List<string> drawnCards = new List<string>();
Dictionary<Augury, int> auguryEffects = new Dictionary<Augury, int>();
Random random = new Random();
Console.WriteLine($"Drawing {number_of_cards} cards!");
Console.WriteLine($"Starting Deck Items: {deck.Count}");
for(int i = 0; i < number_of_cards; i++){
    if(deck.Count == 0)
    {
        Console.WriteLine("Deck is empty. Cannot fulfill all declared draws.");
        break;
    }

    int index = random.Next(0, deck.Count);
    string mainCardKey = deck[index];
    deck.Remove(mainCardKey);
    if (ProcessDrawnCardAndCheckIsolation(mainCardKey, descriptions, drawnCards, auguryEffects))
    {
        break; // Isolation was drawn, stop everything.
    }

    if (mainCardKey == "Mystery")
    {
        Console.WriteLine($"'{mainCardKey}' effect: Drawing 1 additional card.");
        if (deck.Count > 0)
        {
            int bonusIndex = random.Next(0, deck.Count);
            string bonusCardKey = deck[bonusIndex];
            deck.Remove(bonusCardKey); // Remove bonus card from deck
            Console.WriteLine($"Bonus draw for '{mainCardKey}': {bonusCardKey}");
            if (ProcessDrawnCardAndCheckIsolation(bonusCardKey, descriptions, drawnCards, auguryEffects))
            {
                break; // Isolation drawn as bonus, stop.
            }
        }
        else
        {
            Console.WriteLine("Deck is empty, cannot draw bonus card for 'Mystery'.");
        }
    }
    else if (mainCardKey == "Mischief")
    {
        Console.WriteLine($"'{mainCardKey}' effect: Drawing 2 additional cards.");
        for (int j = 0; j < 2; j++)
        {
            if (deck.Count > 0)
            {
                int bonusIndex = random.Next(0, deck.Count);
                string bonusCardKey = deck[bonusIndex];
                deck.Remove(bonusCardKey); // Remove bonus card from deck
                Console.WriteLine($"Bonus draw {j + 1}/2 for '{mainCardKey}': {bonusCardKey}");
                if (ProcessDrawnCardAndCheckIsolation(bonusCardKey, descriptions, drawnCards, auguryEffects))
                {
                    i = number_of_cards; // Force outer loop to terminate as well
                    break; // Stop Mischief's bonus draws and main draws
                }
            }
            else
            {
                Console.WriteLine($"Deck is empty, cannot draw bonus card {j + 1}/2 for 'Mischief'.");
                break; // Stop trying to draw bonus cards for Mischief
            }
        }

        if (i >= number_of_cards)
        {
            break; // If Isolation from Mischief's bonus forced loop termination
        }
    }
}

foreach(var item in drawnCards){
    Console.WriteLine(item);
}

foreach(var auguryEntry in auguryEffects)
{
    double percentage = (double)auguryEntry.Value / drawnCards.Count * 100;
    Console.WriteLine($"{auguryEntry.Key}: {auguryEntry.Value} time(s) ({percentage:F2}%)");
}
return 0;

public class Cards {
    public string Description { get; set; }
    public Augury Augury { get; set; }

    public Cards(string description, Augury auguryEffect = Augury.Nothing)
    {
        Description = description;
        Augury = auguryEffect;
    }
}

public enum Augury {
    Weal,
    Woe,
    WealAndWoe,
    Nothing
}