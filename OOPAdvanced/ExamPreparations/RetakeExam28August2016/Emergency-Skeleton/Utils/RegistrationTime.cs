namespace Emergency_Skeleton.Utils
{
    using Emergency_Skeleton.Interfaces.Utils;

    public class RegistrationTime : IRegistrationTime
    {
        private int hour;

        private int minutes;

        private int day;

        private int month;

        private int year;

        public RegistrationTime(string registrationTime)
        {
            this.InitializeData(this.ParseData(registrationTime));
        }


        private int[] ParseData(string registrationTime)
        {
            string[] registrationTimeArgs = registrationTime.Split(' ');

            string hourAndMinutes = registrationTimeArgs[0];
            string date = registrationTimeArgs[1];

            string[] hourAndMinuteTokens = hourAndMinutes.Split(':');
            string[] dateTokens = date.Split('/');

            int hour = int.Parse(hourAndMinuteTokens[0]);
            int minutes = int.Parse(hourAndMinuteTokens[1]);

            int day = int.Parse(dateTokens[0]);
            int month = int.Parse(dateTokens[1]);
            int year = int.Parse(dateTokens[2]);

            int[] parsedData = new int[5];

            parsedData[0] = hour;
            parsedData[1] = minutes;
            parsedData[2] = day;
            parsedData[3] = month;
            parsedData[4] = year;

            return parsedData;
        }

        private void InitializeData(int[] data)
        {
            this.hour = data[0];
            this.minutes = data[1];
            this.day = data[2];
            this.month = data[3];
            this.year = data[4];
        }

        public override string ToString()
        {
            string hour = this.hour < 10 ? "0" + this.hour : this.hour + "";
            string minutes = this.minutes < 10 ? "0" + this.minutes : this.minutes + "";
            string day = this.day < 10 ? "0" + this.day : this.day + "";
            string month = this.month < 10 ? "0" + this.month : this.month + "";

            string result = $"{hour}:{minutes} {day}/{month}/{this.year}";
            //string result = hour + ":" + minutes + " " + day + "/" + month + "/" + this.year;
            return result;
        }
    }
}
