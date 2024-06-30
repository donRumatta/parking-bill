namespace ParkingBill;

public static class Parking
{
    private const int EntranceFee = 2;

    private const int FirstHourCost = 3;

    private const int HourCost = 4;

    public static int CalculateCost(string timeEntered, string timeLeft)
    {
        var additionalHours = GetAdditionalHours(timeEntered, timeLeft);

        var cost = EntranceFee + FirstHourCost + HourCost * additionalHours;

        return cost;
    }

    private static int GetAdditionalHours(string timeEntered, string timeLeft)
    {
        var hourEntered = int.Parse(timeEntered.Split(":").First());
        var minuteEntered = int.Parse(timeEntered.Split(":").Last());
        
        var hourLeft = int.Parse(timeLeft.Split(":").First());
        var minuteLeft = int.Parse(timeLeft.Split(":").Last());

        var minutesSpent = (hourLeft - hourEntered) * 60 - minuteEntered + minuteLeft;
        
        // minus first hour
        var additionalMinutesSpent = minutesSpent - 60;
        
        // partial hour
        if (additionalMinutesSpent <= 0)
        {
            return 0;
        }

        var additionalHoursSpent = additionalMinutesSpent / 60;
        
        //check last partial hour
        if (additionalMinutesSpent - additionalHoursSpent * 60 > 0)
        {
            additionalHoursSpent += 1;
        }

        return additionalHoursSpent;
    }
}