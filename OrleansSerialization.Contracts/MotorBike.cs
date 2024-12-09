using Orleans;

namespace OrleansSerialization.Contracts
{
    [GenerateSerializer]
    public class MotorBike
    {
        [Id(0)]
        private readonly string brand;
        [Id(1)]
        private readonly string model;

        public MotorBike(string brand, string model)
        {
            this.brand = brand;
            this.model = model;
        }

        public string Brand => this.brand;
        public string Model => this.model;
    }
}
