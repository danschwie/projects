using System;
using System.IO;
using MathLibrary.Utilities;
using ProjectEuler.Interfaces;

namespace ProjectEuler.Solutions
{
    public class Problem19 : IIntProblem
    {

        public int Solve()
        {
            string currentDay = "Tuesday";
            int numSundays = 0;

            for (int year = 1901; year <= 2000; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
                    {
                        if (currentDay == "Sunday" && day == 1)
                        {
                            numSundays++;
                        }

                        currentDay = GetNextDay(currentDay);
                    }
                }
            }

            return numSundays;
        }

        public string GetNextDay(string currentDay)
        {
            switch (currentDay)
            {
                case "Monday":
                    return "Tuesday";
                case "Tuesday":
                    return "Wednesday";
                case "Wednesday":
                    return "Thursday";
                case "Thursday":
                    return "Friday";
                case "Friday":
                    return "Saturday";
                case "Saturday":
                    return "Sunday";
                case "Sunday":
                    return "Monday";
            }

            return "";
        }
    }
}