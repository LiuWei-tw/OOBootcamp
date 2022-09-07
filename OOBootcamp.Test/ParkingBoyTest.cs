using System.Collections.Generic;
using NUnit.Framework;

namespace OOBootcamp.Test;

public class ParkingBoyTest
{
    
    private const string LICENSE_PLATE = "MAT-001";
    private const int MAX_CAPACITY = 2;
    private ParkingLot _parkingLot1 = null!;
    private ParkingLot _parkingLot2 = null!;
    private ParkingLot _parkingLot3 = null!;
    private List<ParkingLot> _parkingLots = null;
    
    [SetUp]
    public void Setup()
    {
        _parkingLots = new List<ParkingLot>();
        _parkingLot1 = new ParkingLot(1, 5, "cheap parking");
        _parkingLot2 = new ParkingLot(MAX_CAPACITY, 5, "cheap parking");
        _parkingLot3 = new ParkingLot(MAX_CAPACITY, 5, "cheap parking");
        _parkingLots.Add(_parkingLot1);
        _parkingLots.Add(_parkingLot2);
        _parkingLots.Add(_parkingLot3);
    }
    [Test]
    public void should_park_first_vehicle_to_first_parkingLot()
    {
        var vehicle = new Vehicle(LICENSE_PLATE);
        var graduateParkingBoy = new GraduateParkingBoy(_parkingLots,1);
        var num = graduateParkingBoy.Parking(vehicle);
        Assert.AreEqual(1,num);
    }
    [Test]
    public void should_park_second_parkingLot_when_first_has_no_space_And_this_is_twice_vehicle()
    {
        var vehicle1 = new Vehicle(LICENSE_PLATE+"1");
        var vehicle2 = new Vehicle(LICENSE_PLATE+"2");
        var graduateParkingBoy = new GraduateParkingBoy(_parkingLots,1);
        graduateParkingBoy.Parking(vehicle1);
        var num = graduateParkingBoy.Parking(vehicle2);
        Assert.AreEqual(2,num);
    }
    [Test]
    public void should_park_second_parkingLot_when_first_has_no_space_And_this_is_fourth_vehicle()
    {
        var vehicle1 = new Vehicle(LICENSE_PLATE+"1");
        var vehicle2 = new Vehicle(LICENSE_PLATE+"2");
        var vehicle3 = new Vehicle(LICENSE_PLATE+"3");
        var vehicle4 = new Vehicle(LICENSE_PLATE+"4");
        var graduateParkingBoy = new GraduateParkingBoy(_parkingLots,1);
        graduateParkingBoy.Parking(vehicle1);
        graduateParkingBoy.Parking(vehicle2);
        graduateParkingBoy.Parking(vehicle3);
        var num = graduateParkingBoy.Parking(vehicle4);
        Assert.AreEqual(2,num);
    }
    [Test]
    public void should_park_third_parkingLot_when_first_has_no_space_And_this_is_fifth_vehicle()
    {
        var vehicle1 = new Vehicle(LICENSE_PLATE+"1");
        var vehicle2 = new Vehicle(LICENSE_PLATE+"2");
        var vehicle3 = new Vehicle(LICENSE_PLATE+"3");
        var vehicle4 = new Vehicle(LICENSE_PLATE+"4");
        var vehicle5 = new Vehicle(LICENSE_PLATE+"5");
        var graduateParkingBoy = new GraduateParkingBoy(_parkingLots,1);
        graduateParkingBoy.Parking(vehicle1);
        graduateParkingBoy.Parking(vehicle2);
        graduateParkingBoy.Parking(vehicle3);
        graduateParkingBoy.Parking(vehicle4);
        var num = graduateParkingBoy.Parking(vehicle5);
        Assert.AreEqual(3,num);
    }
    
    [Test]
    public void should_throw_exception_when_has_no_space()
    {
        var vehicle1 = new Vehicle(LICENSE_PLATE + "1");
        var vehicle2 = new Vehicle(LICENSE_PLATE + "2");
        var vehicle3 = new Vehicle(LICENSE_PLATE + "3");
        var vehicle4 = new Vehicle(LICENSE_PLATE + "4");
        var vehicle5 = new Vehicle(LICENSE_PLATE + "5");
        var vehicle6 = new Vehicle(LICENSE_PLATE + "6");
        var graduateParkingBoy = new GraduateParkingBoy(_parkingLots, 1);
        graduateParkingBoy.Parking(vehicle1);
        graduateParkingBoy.Parking(vehicle2);
        graduateParkingBoy.Parking(vehicle3);
        graduateParkingBoy.Parking(vehicle4);
        graduateParkingBoy.Parking(vehicle5);
        Assert.Throws<NoParkingSlotAvailableException>((() => graduateParkingBoy.Parking(vehicle6)));
    }
    
    [Test]
    public void should_pick_up_correctly_when_pick_up_vehicle()
    {
        var vehicle1 = new Vehicle(LICENSE_PLATE + "1");
        var vehicle2 = new Vehicle(LICENSE_PLATE + "2");
        var vehicle3 = new Vehicle(LICENSE_PLATE + "3");
        var vehicle4 = new Vehicle(LICENSE_PLATE + "4");
        var vehicle5 = new Vehicle(LICENSE_PLATE + "5");
        var vehicle6 = new Vehicle(LICENSE_PLATE + "6");
        var graduateParkingBoy = new GraduateParkingBoy(_parkingLots, 1);
        graduateParkingBoy.Parking(vehicle1);
        graduateParkingBoy.Parking(vehicle2);
        graduateParkingBoy.Parking(vehicle3);
        var expected =graduateParkingBoy.Parking(vehicle4);
        graduateParkingBoy.Parking(vehicle5);
        var pickUpMoney = graduateParkingBoy.PickUp(vehicle4);
        Assert.AreEqual(5.0d,pickUpMoney);
        var actual = graduateParkingBoy.Parking(vehicle6);
        Assert.AreEqual(expected,actual);
    }
    [Test]
    public void should_throw_exception_when_pick_up_vehicle_do_not_exist()
    {
        var vehicle1 = new Vehicle(LICENSE_PLATE + "1");
        var vehicle2 = new Vehicle(LICENSE_PLATE + "2");
        var vehicle3 = new Vehicle(LICENSE_PLATE + "3");
        var vehicle4 = new Vehicle(LICENSE_PLATE + "4");
        var vehicle5 = new Vehicle(LICENSE_PLATE + "5");
        var vehicle6 = new Vehicle(LICENSE_PLATE + "6");
        var graduateParkingBoy = new GraduateParkingBoy(_parkingLots, 1);
        graduateParkingBoy.Parking(vehicle1);
        graduateParkingBoy.Parking(vehicle2);
        graduateParkingBoy.Parking(vehicle3);
        graduateParkingBoy.Parking(vehicle4);
        graduateParkingBoy.Parking(vehicle5);
        Assert.Throws<VehicleNotFoundException>((() => graduateParkingBoy.PickUp(vehicle6)));
    }
}