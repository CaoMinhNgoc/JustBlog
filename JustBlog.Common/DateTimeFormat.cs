namespace JustBlog.Common
{
    public static class DateTimeFormat
    {
        public static string FriendlyFormat(this DateTime d)
        {
            var months = new string[] { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            TimeSpan timeSpan = DateTime.Now.Subtract(d);

            int dayDiff = (int)timeSpan.TotalDays;

            int secDiff = (int)timeSpan.TotalSeconds;


            if (dayDiff < 0)
            {
                return null;
            }

            if (dayDiff == 0)
            {

                if (secDiff < 60)
                {
                    return "a few seconds ago";
                }

                if (secDiff < 120)
                {
                    return "1 minute ago";
                }

                if (secDiff < 3600)
                {
                    return string.Format("{0} minutes ago",
                        Math.Floor((double)secDiff / 60));
                }

                if (secDiff < 7200)
                {
                    return "1 hour ago";
                }

                if (secDiff < 86400)
                {
                    return string.Format("{0} hours ago",
                        Math.Floor((double)secDiff / 3600));
                }
            }
            // 6.
            // Handle previous days.
            if (dayDiff == 1)
            {
                return $"yesterday at {(d.Hour % 12).ToString().PadLeft(2, '0')}:{d.Minute.ToString().PadLeft(2, '0')} {(d.Hour >= 12 ? "PM" : "AM")}";
            }
            if (dayDiff < 7)
            {
                return string.Format("{0} days ago",
                    dayDiff);
            }
            return $"{months[d.Month]} {d.Day} at {(d.Hour % 12).ToString().PadLeft(2, '0')}:{d.Minute.ToString().PadLeft(2, '0')} {(d.Hour >= 12 ? "PM" : "AM")}";
        }

        public static string DateTimePickerValue(this DateTime dateTime)
        {
            return $"{dateTime.Year}-{dateTime.Month.ToString().PadLeft(2, '0')}-{dateTime.Day.ToString().PadLeft(2, '0')}T{dateTime.Hour.ToString().PadLeft(2, '0')}:{dateTime.Second.ToString().PadLeft(2, '0')}";
        }
    }
}
