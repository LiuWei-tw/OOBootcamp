namespace OOBootcamp;

public class GraduateParkingBoy
{
    private int Index { get; set; }

    private readonly List<ParkingLot> _parkingLots;
    public GraduateParkingBoy(List<ParkingLot> parkingLots,int index)
    {
        _parkingLots = parkingLots;
        Index = index;
    }
    // Write your logic here
    //一辆车 到达停车场 按顺序放入1
    //一辆车 上一辆车停入1 停入2  ，
    // 2停车场满了 停入3
    //一辆车 停车场都满了 通知都满了
    //一辆车 离开停车场 找到所属停车场 找到车 取出车
    //一辆车 离开停车场  找不到车 异常
    public int Parking(Vehicle vehicle)
    {
        var parkingLotCount = _parkingLots.Count;
        while (parkingLotCount > 0)
        {
            var current = Index % _parkingLots.Count == 0 ? _parkingLots.Count : Index % _parkingLots.Count;
            var currentParkingLot = _parkingLots[current-1];
            Index ++;
            if (currentParkingLot.ParkVehicle(vehicle))
            {
                return current;
            }
            parkingLotCount--;
        }
        throw new NoParkingSlotAvailableException("没空位");
    }

    public double PickUp(Vehicle vehicle)
    {
        foreach (var parkingLot in _parkingLots.Where(parkingLot => parkingLot.HasVehicle(vehicle)))
        {
            return parkingLot.RetrieveVehicle(vehicle);
        }

        throw new VehicleNotFoundException(vehicle);
    }
}