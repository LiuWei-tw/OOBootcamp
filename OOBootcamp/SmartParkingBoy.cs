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
        var parkingLot = GetLargestAvailableSpaceParkingLot();
        
        if (parkingLot.AvailableCount > 0)
        {
            parkingLot.ParkVehicle(vehicle);
            return parkingLot;
        }
        throw new NoParkingSlotAvailableException("没空位");
    }

    private ParkingLot GetLargestAvailableSpaceParkingLot()
    {
        return _parkingLots.OrderByDescending(e => e.AvailableCount)
            .ThenByDescending(e => e.GetAvailableRate()).First();
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