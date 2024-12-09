namespace OrleansSerialization.Tests
{
    [GenerateSerializer]
    public class Plane
    {
        [Id(0)]
        private readonly string brand;

        [Id(1)]
        private readonly string model;

        public Plane(string brand, string model)
        {
            this.brand = brand;
            this.model = model;
        }

        public string Brand => brand;

        public string Model => model;
    }
}