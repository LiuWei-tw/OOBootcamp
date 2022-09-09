using System.Collections.Generic;
using NUnit.Framework;

namespace OOBootcamp.Test;

public class SmartParkingBoyTest
{
    private const string LICENSE_PLATE = "MAT-001";
    private ParkingLot _parkingLot1 = null!;
    private ParkingLot _parkingLot2 = null!;
    private ParkingLot _parkingLot3 = null!;
    private List<ParkingLot> _parkingLots = null;
    
    [SetUp]
    public void Setup()
    {
        _parkingLots = new List<ParkingLot>();
        _parkingLot1 = new ParkingLot(1, 5, "cheap parking 1");
        _parkingLot2 = new ParkingLot(2, 5, "cheap parking 2");
        _parkingLot3 = new ParkingLot(3, 5, "cheap parking 3");
        _parkingLots.Add(_parkingLot1);
        _parkingLots.Add(_parkingLot2);
        _parkingLots.Add(_parkingLot3);
    }
    [Test]
    public void should_park_first_vehicle_to_parkingLot_which_has_largest_space()
    {
        var vehicle = new Vehicle(LICENSE_PLATE);
        var smartParkingBoy = new SmartParkingBoy(_parkingLots);
        var parkingLot = smartParkingBoy.Parking(vehicle);
        Assert.AreEqual("cheap parking 3",parkingLot.Name);
    }
}