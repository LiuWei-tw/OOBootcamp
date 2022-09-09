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
    private readonly List<ParkingLot> _emptyParkingLots = new List<ParkingLot>(){new ParkingLot(0,5,"empty parking")};
    
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
        var parkingLot = smartParkingBoy.ParkVehicle(vehicle);
        Assert.AreEqual("cheap parking 3",parkingLot.Name);
    }
    [Test]
    public void should_park_first_vehicle_to_parkingLot_which_has_largest_space_rate_when_the_largest_space_is_the_same_with_others()
    {
        var vehicle1 = new Vehicle(LICENSE_PLATE+1);
        var vehicle2 = new Vehicle(LICENSE_PLATE+2);
        var smartParkingBoy = new SmartParkingBoy(_parkingLots);
        smartParkingBoy.ParkVehicle(vehicle1);
        var parkingLot = smartParkingBoy.ParkVehicle(vehicle2);
        Assert.AreEqual("cheap parking 2",parkingLot.Name);
    }
    [Test]
    public void should_park_first_vehicle_to_parkingLot_which_All_parking_lot_has_no_space()
    {
        var vehicle1 = new Vehicle(LICENSE_PLATE+1);
        var smartParkingBoy = new SmartParkingBoy(_emptyParkingLots);
        Assert.Throws<NoParkingSlotAvailableException>(()=>smartParkingBoy.ParkVehicle(vehicle1));
    }
    
    [Test]
    public void should_pick_up_correctly_when_parkingLot_has_this_vehicle()
    {
        var vehicle1 = new Vehicle(LICENSE_PLATE+1);
        var smartParkingBoy = new SmartParkingBoy(_parkingLots);
        smartParkingBoy.ParkVehicle(vehicle1);
        Assert.AreEqual(5.0d,smartParkingBoy.RetrieveVehicle(vehicle1.LicensePlate));
    }
    [Test]
    public void should_pick_up_unsuccessfully_when_parkingLot_not_has_this_vehicle()
    {
        var vehicle1 = new Vehicle(LICENSE_PLATE+1);
        var smartParkingBoy = new SmartParkingBoy(_emptyParkingLots);
        Assert.Throws<VehicleNotFoundException>(()=>smartParkingBoy.RetrieveVehicle(vehicle1.LicensePlate));
    }
}