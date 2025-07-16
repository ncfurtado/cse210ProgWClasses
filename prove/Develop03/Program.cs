using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        do
        {
            List<string> verses = new List<string>()
        {
            "And now, my sons, remember, remember that it is upon the rock of our Redeemer, who is Christ, the Son of God, that ye must build your foundation; that when the devil shall send forth his mighty winds, yea, his shafts in the whirlwind, yea, when all his hail and his mighty storm shall beat upon you, it shall have no power over you to drag you down to the gulf of misery and endless wo, because of the rock upon which ye are built, which is a sure foundation, a foundation whereon if men build they cannot fall.",
            "And it came to pass that these were the words which Helaman taught to his sons; yea, he did teach them many things which are not written, and also many things which are written."
        };

            Scripture scripture1 = new Scripture("And now, my sons, remember, remember that it is upon the rock of our Redeemer, who is Christ, the Son of God, that ye must build your foundation; that when the devil shall send forth his mighty winds, yea, his shafts in the whirlwind, yea, when all his hail and his mighty storm shall beat upon you, it shall have no power over you to drag you down to the gulf of misery and endless wo, because of the rock upon which ye are built, which is a sure foundation, a foundation whereon if men build they cannot fall.",
            "And it came to pass that these were the words which Helaman taught to his sons; yea, he did teach them many things which are not written, and also many things which are written.", eference);

            // using (StreamReader reader = new StreamReader("proverbs_3_5-6.txt"))
            // {
            //     Scripture scripture2 = new Scripture(reader);
            // }
        } while (true);
    }
    static void Menu()
    {

    }
}