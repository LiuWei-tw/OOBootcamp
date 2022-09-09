namespace OOBootcamp;

public class SmartParkingBoy
{
    private readonly List<ParkingLot> _parkingLots;
    public SmartParkingBoy(List<ParkingLot> parkingLots)
    {
        _parkingLots = parkingLots;
    }
    // 停车场 多个，A空位最多  一辆车要停  停A
    //     停车场 多个 ，A B C 。。。一样最多  一辆车要停  停A或B或C。。(停其中空位率最多的)
    // 停车场 多个，都无空位   一辆车要停   报异常
    public ParkingLot ParkVehicle(Vehicle vehicle)
    {
        var parkingLot = _parkingLots.OrderByDescending(e => e.AvailableCount).ThenByDescending(e => e.AvailableCount/(e.MaxCapacity+1)).First();
        if (parkingLot.ParkVehicle(vehicle))
        {
            return parkingLot;
        }

        throw new NoParkingSlotAvailableException("没空位");
    }
    public double RetrieveVehicle(string licensePlate)
    {
        var vehicle = new Vehicle(licensePlate);
        var parkingLot = _parkingLots.FirstOrDefault(parkingLot => parkingLot.HasVehicle(vehicle));
        if (parkingLot is not null)
        {
            return parkingLot.RetrieveVehicle(vehicle);
        }
        throw new VehicleNotFoundException(vehicle);
    }
}