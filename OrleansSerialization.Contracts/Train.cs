using Orleans;

namespace OrleansSerialization.Contracts
{
    [GenerateSerializer]
    public class Train
    {
        public Train(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }

        [Id(0)]
        public string Brand { get; set; }

        [Id(1)]
        public string Model { get; set; }
    }
}
