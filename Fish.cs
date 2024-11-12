namespace CA24111201;

internal class Fish
{
    private int top;
    private float weight;
    private bool weightIsSet = false;

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
    public bool Predator { get; set; }
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
    public int Depth { get; set; }
    public string Species { get; set; }

    public override string ToString() => 
        $"{Species} " +
        $"({(Predator ? "carnivor" : "herbivor")}) " +
        $"[{Top} - {Top + Depth} cm] " +
        $"{Weight:00.0} kg";
}
