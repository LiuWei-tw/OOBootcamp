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
    public ParkingLot Parking(Vehicle vehicle)
    {
        var parkingLot = _parkingLots.OrderByDescending(e => e.AvailableCount).First();
        parkingLot.ParkVehicle(vehicle);
        return parkingLot;
    }
}