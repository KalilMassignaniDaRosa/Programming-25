namespace WeekDay.Models
{
    public class WeekDayModel
    {
        public string NumberToDay(int number)
        {
            string[] weekDaysArray = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
            string result;
            number--;

            switch (number)
            {
                case 0:
                    result = weekDaysArray[number];
                    break;
                case 1:
                    result = weekDaysArray[number];
                    break;
                case 2:
                    result = weekDaysArray[number];
                    break;
                case 3:
                    result = weekDaysArray[number];
                    break;
                case 4:
                    result = weekDaysArray[number];
                    break;
                case 5:
                    result = weekDaysArray[number];
                    break;
                case 6:
                    result = weekDaysArray[number];
                    break;
                default:
                    result = "Error! Insert a number between 1 and 7";
                    break;
            }

            return result;
        }
    }
}
