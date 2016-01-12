namespace Alix.Core.Interfaces
{
    public interface IDice
    {
        int Sides { get; set; }
        int Rolls { get; set; }
        int Modifier { get; set; }
        double Roll();
    }
}
