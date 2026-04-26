// Copyright: 2026 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using BB84.SourceGenerators.Attributes;

namespace BB84.SourceGenerators.Tests;

[TestClass]
public sealed class FactoryGeneratorTests
{
  [TestMethod]
  public void FactoryShouldCreateByTypeName()
  {
    IAnimal animal = AnimalFactory.Create("Dog");

    Assert.IsInstanceOfType<Dog>(animal);
  }

  [TestMethod]
  public void FactoryShouldCreateDifferentTypes()
  {
    IAnimal dog = AnimalFactory.Create("Dog");
    IAnimal cat = AnimalFactory.Create("Cat");

    Assert.IsInstanceOfType<Dog>(dog);
    Assert.IsInstanceOfType<Cat>(cat);
  }

  [TestMethod]
  public void FactoryShouldThrowForUnknownKey()
  {
    Assert.ThrowsExactly<ArgumentException>(() => AnimalFactory.Create("Fish"));
  }

  [TestMethod]
  public void FactoryShouldCreateByCustomKey()
  {
    IVehicle vehicle = VehicleFactory.Create("sedan");

    Assert.IsInstanceOfType<Car>(vehicle);
  }

  [TestMethod]
  public void FactoryShouldCreateByCustomKeyForAllTypes()
  {
    IVehicle sedan = VehicleFactory.Create("sedan");
    IVehicle pickup = VehicleFactory.Create("pickup");

    Assert.IsInstanceOfType<Car>(sedan);
    Assert.IsInstanceOfType<Truck>(pickup);
  }

  [TestMethod]
  public void FactoryGetKeysShouldReturnAllKeys()
  {
    List<string> keys = [.. AnimalFactory.GetKeys()];

    Assert.IsTrue(keys.Contains("Dog"));
    Assert.IsTrue(keys.Contains("Cat"));
    Assert.AreEqual(2, keys.Count);
  }

  [TestMethod]
  public void FactoryGetKeysShouldReturnCustomKeys()
  {
    List<string> keys = [.. VehicleFactory.GetKeys()];

    Assert.IsTrue(keys.Contains("sedan"));
    Assert.IsTrue(keys.Contains("pickup"));
    Assert.AreEqual(2, keys.Count);
  }

  [TestMethod]
  public void FactoryShouldCreateNewInstanceEachTime()
  {
    IAnimal first = AnimalFactory.Create("Dog");
    IAnimal second = AnimalFactory.Create("Dog");

    Assert.AreNotSame(first, second);
  }
}

// --- Test interfaces and implementations ---

public interface IAnimal
{
  string Speak();
}

public class Dog : IAnimal
{
  public string Speak() => "Woof!";
}

public class Cat : IAnimal
{
  public string Speak() => "Meow!";
}

public interface IVehicle
{
  string Type { get; }
}

[GenerateFactoryKey("sedan")]
public class Car : IVehicle
{
  public string Type => "Car";
}

[GenerateFactoryKey("pickup")]
public class Truck : IVehicle
{
  public string Type => "Truck";
}

// --- Factory classes ---

[GenerateFactory(typeof(IAnimal))]
public partial class AnimalFactory
{ }

[GenerateFactory(typeof(IVehicle))]
public partial class VehicleFactory
{ }
