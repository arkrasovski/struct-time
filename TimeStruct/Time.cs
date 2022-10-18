using System.Xml.Linq;

namespace TimeStruct
{
    /// <summary>
    /// Represents the times in 24-hours format.
    /// </summary>
    /// <param name="hours">The variable for hours.</param>
    /// <param name="minutes">The variable for minutes.</param>
    /// <returns>Time in 24-hours format.</returns>
    public struct Time
    {
        private int hours;
        private int minutes;

        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> struct.
        /// </summary>
        /// <param name="hours">The variable for hours.</param>
        /// <param name="minutes">The variable for minutes.</param>
        public Time(int hours, int minutes)
        {
            ToTime(hours, minutes, out this.hours, out this.minutes);
        }


        private static void ToTime(int hours, int minutes, out int h, out int m)
        {
            if (minutes < 60 && minutes >= 0)
            {
                m = minutes;
            }
            else if (minutes >= 60)
            {
                while (minutes >= 60)
                {
                    minutes -= 60;
                    hours++;
                }

                m = minutes;
            }
            else
            {
                while (minutes < 0)
                {
                    minutes += 60;
                    if (hours == 0)
                    {
                        hours = 23;
                    }
                    else
                    {
                        hours--;
                    }
                }

                m = minutes;
            }

            if (hours < 24 && hours >= 0)
            {
                h = hours;
            }
            else if (hours >= 24)
            {
                while (hours >= 24)
                {
                    hours -= 24;
                }

                h = hours;
            }
            else
            {
                while (hours < 0)
                {
                    hours += 24;
                }

                h = hours;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> struct.
        /// </summary>
        /// <param name="minutes">The variable for minutes.</param>
        public Time(int minutes)
            : this(0, minutes)
        {
        }

        /// <summary>
        /// Gets the hours.
        /// </summary>
        public int Hours { get => this.hours; }

        /// <summary>
        /// Gets the minutes.
        /// </summary>
        public int Minutes { get => this.minutes; }

        /// <summary>
        /// Prints the time.
        /// </summary>
        /// <returns>The time in format hh:mm.</returns>
        // public override string ToString()
        public new string ToString()
        {
            return (this.hours > 9 ? this.hours : "0" + this.hours) + ":" + (this.minutes > 9 ? this.minutes : "0" + this.minutes);
        }

        /// <summary>
        /// Deconstruct method.
        /// </summary>
        /// <param name="hours">The variable for hours.</param>
        /// <param name="minutes">The variable for minutes.</param>
        public void Deconstruct(out int hours, out int minutes)
        {
            hours = this.hours;
            minutes = this.minutes;
        }
    }
}
