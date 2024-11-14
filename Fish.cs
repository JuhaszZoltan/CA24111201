namespace CA24111201;

internal class Fish
{
    private int top;
    private float weight;
    private bool weightIsSet = false;
    private int depth;
    private string species;

    public float Weight
    {
        get => weight; 
        set
        {
            if (value < .5 || value > 40) throw new Exception(
                $"value = {value}, a weight értéke csak [0.5; 40] intervallumon belül valid");

            if (weightIsSet && (value < weight * .9 || value > weight * 1.1)) throw new Exception(
                $"value = {value}, a weight értéke legfeljebb 10%-al változhat a jelenlegi értékéhez képest (+/-{weight*.1})");

            weight = value;
            weightIsSet = true;
        }
    }
    public bool Predator { get; }
    public int Top
    {
        get => top;
        set
        {
            if (value < 0 || value > 400) throw new Exception(
                $"a top értékét {value}-ra szeretnéd beállítani, ami a megngedett határon kívükl esik. A top [0; 400] intervallumon belül valid");

            top = value;
        }
    }
    public int Depth
    {
        get => depth;
        set
        {
            if (value < 10 || value > 400) throw new Exception(
                $"a depth értékét {value}-ra szeretnéd beállítani, ami a megngedett határon kívükl esik. A depth [10; 400] intervallumon belül valid");

            depth = value;
        }
    }
    public string Species
    {
        get => species;
        set
        {
            if (value is null) throw new Exception("a species értéke nem lehet null");

            if (value.Length < 3 || value.Length > 30) throw new Exception(
                $"a species értékét {value}-ra szeretnéd beállítani. " +
                $"ennek hossza ({value.Length}), ami a megengedett határokon kívül esik. " +
                $"a species hossza [3, 30] között valid.");

            species = value;
        }
    }

    public override string ToString() => 
        $"{Species} " +
        $"({(Predator ? "carnivore" : "herbivore")}) " +
        $"[{Top} - {Top + Depth} cm] " +
        $"{Weight:00.0} kg";

    public Fish(float weight, bool predator, int top, int depth, string species)
    {
        Weight = weight;
        Predator = predator;
        Top = top;
        Depth = depth;
        Species = species;
    }
}
