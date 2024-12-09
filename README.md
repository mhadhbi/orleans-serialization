This repository is containing an example to demonstrate the following unexpected behavior of Orleans serializer. 
We cannot use to serialize properly private fields of classes defined in an assembly that only reference `Microsoft.Orleans.Serialization.Abstractions` NuGet package.
Making the fields protected solve the problem.
