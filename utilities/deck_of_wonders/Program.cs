using System.Collections.Generic;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("*** DECK OF WONDERS ***");
if(args.Length == 0){
    Console.Error.WriteLine($"Error: No Arguments Provided");
    return 1;
}
Console.WriteLine($"Drawing {args[0]} cards!");
int number_of_cards = Convert.ToInt32(args[0]);
List<string> deck = new List<string>{"Chancellor", "Day", "Night", "Dawn", "Dusk", "Destiny", "Crown", "Lock", "Champion", "Coin", 
                                        "Vulture", "Chaos", "Order", "Beginning", "Mystery", "Isolation", "End", "Monster", "Knife",
                                        "Justice", "Student", "Mischief"};

Dictionary<string,string> descriptions = new Dictionary<string,string>()
{
    {"Chancellor","Within 8 hours of drawing this card, you can cast Augury once as an action, requiring no material components. Use your Intelligence, Wisdom, or Charisma as the spellcasting ability (your choice)."},
    {"Day", "You gain a +1 bonus to saving throws. This benefit lasts until you finish a long rest."},
    {"Night", "You gain darkvision within a range of 300 feet. This darkvision lasts for 8 hours."},
    {"Dawn", "This card invigorates you. For the next 8 hours, you can add your proficiency bonus to your initiative rolls."},
    {"Dusk", "This card supernaturally saps your energy. You have disadvantage on initiative rolls. This effect lasts until you finish a long rest, but it can be ended early by a Remove Curse spell or similar magic."},
    {"Destiny", "This card protects you against an untimely demise. The first time after drawing this card that you would drop to 0 hit points from taking damage, you instead drop to 1 hit point."},
    {"Crown", "You learn the Friends cantrip. Use your Intelligence, Wisdom, or Charisma as the spellcasting ability (your choice). If you already know this cantrip, the card has no effect."},
    {"Lock", "You gain the ability to cast Knock 1d3 times. Use your Intelligence, Wisdom, or Charisma as the spellcasting ability (your choice)."},
    {"Champion", "You gain a +1 bonus to weapon attack and damage rolls. This bonus lasts for 8 hours."},
    {"Coin", "Five pieces of jewelry, each worth 100 gp, or ten gemstones, each worth 50 gp, appear at your feet."},
    {"Vulture", "One nonmagical item or piece of equipment in your possession (chosen by the DM) disappears. The item remains nearby but concealed for a short time, so it can be found with a successful DC 15 Wisdom (Perception) check. If the item isnt recovered within 1 hour, it disappears forever."},
    {"Chaos", "You gain resistance to one of the following damage types (chosen by the DM): acid, cold, fire, lightning, or thunder. This resistance lasts for 1d12 days."},
    {"Order", "You gain resistance to one of the following damage types (chosen by the DM): force, necrotic, poison, psychic, or radiant. This resistance lasts for 1d12 days."},
    {"Beginning", "Your hit point maximum and current hit points increase by 2d10. Your hit point maximum remains increased in this way for the next 8 hours."},
    {"Mystery", "You have disadvantage on Intelligence saving throws for 1 hour. Discard this card and draw from the deck again; together, the two draws count as one of your declared draws."},
    {"Isolation", "You disappear, along with anything you are wearing or carrying, and become trapped in a harmless extradimensional space for 1d4 minutes. You draw no more cards. You then reappear in the space you left or the nearest unoccupied space. When you reappear, you must succeed on a DC 11 Constitution saving throw or have the poisoned condition for 1 hour as your body reels from the extradimensional travel."},
    {"End", "This card is an omen of death. You take 2d10 necrotic damage, and your hit point maximum is reduced by an amount equal to the damage taken. This effect can’t reduce your hit point maximum below 10 hit points. This reduction lasts until you finish a long rest, but it can be ended early by a Remove Curse spell or similar magic."},
    {"Monster", "This cards monstrous visage curses you. While cursed in this way, whenever you make a saving throw, you must roll 1d4 and subtract the number rolled from the total. The curse lasts until you finish a long rest, but it can be ended early with a Remove Curse spell or similar magic."},
    {"Knife", "An uncommon magic weapon youre proficient with appears in your hands. The DM chooses the weapon."},
    {"Justice", "You momentarily gain the ability to balance the scales of fate. For the next 8 hours, whenever you or a creature within 60 feet of you is about to roll a d20 with advantage or disadvantage, you can use your reaction to prevent the roll from being affected by advantage or disadvantage."},
    {"Student", "You gain proficiency in Wisdom saving throws. If you already have this proficiency, you instead gain proficiency in Intelligence or Charisma saving throws (your choice)."},
    {"Mischief", "You receive an uncommon wondrous item (chosen by the DM), or you can draw two additional cards beyond your declared draws."}
};

List<string> drawnCards = new List<string>();
Random random = new Random();
Console.WriteLine($"Starting Deck Items: {deck.Count}");
for(int i = 0; i < number_of_cards; i++){
    int index = random.Next(0, deck.Count);
    string key = deck[index];
    Console.WriteLine($"Adding {key} to Drawn Cards");
    drawnCards.Add($"{key}: " + descriptions[key]);
    Console.WriteLine($"Removing {key} from Current Deck");
    deck.Remove(key);
    Console.WriteLine($"Current Deck Items: {deck.Count}");

}
foreach(var item in drawnCards){
    Console.WriteLine(item);
}
return 0;
