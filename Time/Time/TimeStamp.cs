using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeStamp
{
    class TimeStamp
    {

        private int _hours;
        private int _minutes;
        private int _seconds;

        private const int MIN_TIME = 0;

        //constructors
        public TimeStamp()
        {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
        }
        //Member Methods
        public TimeStamp ConvertFromSeconds(int SecondsToConvert)
        {
            _hours = SecondsToConvert / 3600;
            _minutes = SecondsToConvert / 60;
           _seconds = SecondsToConvert % 60;
            return this;
        }
        public int ConvertToSeconds()
        {
            return Hours * 3600 + Minutes * 60 + Seconds;
        }
        public void AddSeconds(int TheSeconds)
        {
            ConvertFromSeconds(TheSeconds);
            TheSeconds += ConvertToSeconds();
            
        }
        public void ReadFromConsole()
        {
            Console.WriteLine("Please enter number of hours ");
            GetValue("Error! hours cannot be negative ", 0);

            Console.WriteLine("Please enter number of minutes ");
            GetValue("Error! Please enter a number between 0..59 ", 0, 59);

            Console.WriteLine("Please enter number of seconds ");
            GetValue("Error! Please enter a number between 0..59 ", 0, 59);

        }
        private int GetValue(string errorMessage, int min, int max=int.MaxValue)
        {
            int input;
            bool validInput;
            validInput = int.TryParse(Console.ReadLine(), out input);
            while (validInput == false || input < min || input > max)
            {
                Console.WriteLine("Error! Please enter a number in between {0} and {1}", min, max);
                validInput = int.TryParse(Console.ReadLine(), out input);
            }
            return input;
        }
        public static TimeStamp AddTwoTimeStamps(TimeStamp TimeStampOne, TimeStamp TimeStampTwo)
        {
            TimeStamp t3 = new TimeStamp();
            int seconds = TimeStampOne.ConvertToSeconds() + TimeStampTwo.ConvertToSeconds();
            return t3.ConvertFromSeconds(seconds);
        }
        //Getters
        public int GetHours()
        {
            return _hours;
        }
        public int GetMinutes()
        {
            return _minutes;
        }
        public int GetSeconds()
        {
            return _seconds;
        }
        //Properties
        public int Hours
        {
            get
            {
                return _hours;
            }
            set
            {
                if (value < MIN_TIME)
                    throw new ArgumentException("Hours cannot be less then 0", "hours");
                else
                _hours = value;
            }
        }
        public int Minutes
        {
            get
            {
                return _minutes;
            }
            set
            {
                if (value < MIN_TIME)
                    throw new ArgumentException("Hours cannot be less then 0", "hours");
                else
                _minutes = value;
            }
        }
        public int Seconds
        {
            get
            {
                return _seconds;
            }
            set
            {
                if (value < MIN_TIME)
                    throw new ArgumentException("Hours cannot be less then 0", "hours");
                else
                _seconds = value;
            }
        }
        
        public override string ToString()
        {
            return string.Format($"{_hours:00}:{_minutes:00}:{_seconds:00}");
        }
    }
}
   