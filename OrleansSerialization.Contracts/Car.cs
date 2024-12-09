using Orleans;

namespace OrleansSerialization.Contracts
{
    [GenerateSerializer]
    public class Car
    {
        [Id(0)]
        protected readonly string brand;
        
        [Id(1)]
        protected readonly string model;

        public Car(string brand, string model)
        {
            this.brand = brand;
            this.model = model;
        }

        public string Brand => brand;

        public string Model => model;
    }
}
