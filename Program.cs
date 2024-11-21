using CA24111201;

string[] HERB_FISH_SPECIES = ["Parrotfish", "Surgeonfish", "Rabbitfish", "Blennies", "Damselfish", "Cichlids", "Plecostomus", "Goldfish", "Swordtail", "Guppy"];

string[] CARN_FISH_SPECIES = ["Great White Shark", "Barracuda", "Pike", "Walleye", "Piranha", "Tuna"];

List<Fish> fishlist = [];

for (int i = 0; i < 100; i++)
{
    bool pred = Random.Shared.Next(100) < 10;

    fishlist.Add(new(
        top: Random.Shared.Next(401),
        depth: Random.Shared.Next(10, 401),
        weight: Random.Shared.Next(5, 400) / 10F,
        predator: pred,
        species: pred 
        ? CARN_FISH_SPECIES[Random.Shared.Next(CARN_FISH_SPECIES.Length)] 
        : HERB_FISH_SPECIES[Random.Shared.Next(HERB_FISH_SPECIES.Length)]));

    //Console.ForegroundColor = pred
    //    ? ConsoleColor.Red
    //    : ConsoleColor.Green;

    //Console.WriteLine(fishlist.Last());
}

var f01 = fishlist.Count(f => f.Predator);
Console.WriteLine($"{f01} fish are predators");

var f02 = fishlist.Max(f => f.Weight);
Console.WriteLine($"the largest fish weights {f02} kg");

var f03 = fishlist.Count(f => f.Top <= 110 && 110 <= (f.Top + f.Depth));
Console.WriteLine($"{f03} fish can swim at a depth of 1.1 meters");

Console.WriteLine("----------------------------");

for (int i = 0; i < 100; i++)
{
    int aIndex = Random.Shared.Next(fishlist.Count);
    Fish a = fishlist[aIndex];

    int bIndex = aIndex;
    while(aIndex == bIndex) bIndex = Random.Shared.Next(fishlist.Count);
    Fish b = fishlist[bIndex];

    if (a.Top > b.Top) (a, b) = (b, a);

    Console.WriteLine($"---- round {i+1:000}. ------------");
    Console.WriteLine("the two selected fish:");
    Console.WriteLine(a);
    Console.WriteLine(b);

    if (a.Predator != b.Predator)
    {
        if (a.Top + a.Depth >= b.Top)
        {
            if (Random.Shared.Next(100) < 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (a.Predator)
                {
                    if (a.Weight < 40) a.Weight += .1f;
                    Console.WriteLine($"the {b.Species} eaten by {a.Species}");
                    fishlist.Remove(b);
                }
                else
                {
                    if (b.Weight < 40) b.Weight += .1f;
                    Console.WriteLine($"the {a.Species} eaten by {b.Species}");
                    fishlist.Remove(a);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("the predator have no apetite");
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("the two fish cant meet");
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"both fish are {(a.Predator ? "carnivore" : "herbivore")}");
    }
    Console.ResetColor();
}