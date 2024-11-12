using CA24111201;

Fish fish = new()
{
    Species = "Keszeg",
    Predator = false,
    Weight = 20.0F,
    Top = 30,
    Depth = 80,
};

fish.Weight += 2;

Console.WriteLine(fish);