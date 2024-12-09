using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Orleans.Serialization;
using Orleans.TestingHost;
using OrleansSerialization.Contracts;

[assembly: GenerateCodeForDeclaringAssembly(typeof(Car))]
namespace OrleansSerialization.Tests
{
    [TestFixture]
    public class SerializationTests
    {
        private TestCluster? cluster;

        [OneTimeSetUp]
        public void Setup()
        {
            var builder = new TestClusterBuilder();
            cluster = builder.Build();
            cluster.Deploy();
        }


        [TestCaseSource(nameof(GetObjectsToCheck))]
        public void ShouldSerializeAndDeserializeObject<T>(T @object)
        {
            // Arrange
            var serializer = cluster!.ServiceProvider.GetRequiredService<Serializer>();

            // Act
            var binaryData = serializer.SerializeToArray(@object);
            var deserializedObject = serializer.Deserialize<T>(binaryData);

            // Assert
            deserializedObject.Should().BeEquivalentTo(@object);
        }

        private static IEnumerable<TestCaseData> GetObjectsToCheck()
        {
            yield return new TestCaseData(new Plane(brand: "Airbus", model: "A350"));
            yield return new TestCaseData(new Car(brand: "Alpine", model: "A110"));
            yield return new TestCaseData(new MotorBike(brand: "Honda", model: "CB1000R"));
            yield return new TestCaseData(new Train(brand: "Alstom", model: "TGV M"));

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (cluster != null)
            {
                cluster.Dispose();
            }
        }
    }
}