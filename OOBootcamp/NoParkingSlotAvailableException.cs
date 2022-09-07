namespace OOBootcamp;

public class NoParkingSlotAvailableException : Exception
{
    private string _message;
    public NoParkingSlotAvailableException(string message)
    {
        _message = message;
    }
}