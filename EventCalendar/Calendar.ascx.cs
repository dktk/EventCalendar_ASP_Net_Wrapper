using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI;

namespace EventCalendar
{
    public partial class Calendar : UserControl
    {
        public string Id { get; set; }
        protected string Settings
        {
            get
            {
                var culture = LanguageCode == 0 ? CultureInfo.CurrentCulture : GetCulture(LanguageCode);
                var events = CalendarEvents == null ? Enumerable.Empty<CalendarEvent>() : CalendarEvents;

                return Newtonsoft.Json.JsonConvert.SerializeObject(new
                                                                    {
                                                                        monthNames = GetMonths(culture),
                                                                        dayNames = GetDays(culture),
                                                                        dayNamesShort = GetAbbreviatedDays(culture),
                                                                        jsonData = events.Select(@event => new
                                                                        {
                                                                            date = UnixTicks(@event.Date),
                                                                            description = @event.Description,
                                                                            url = @event.Url,
                                                                            title = @event.Title
                                                                        })
                                                                    });
            }
        }
        public int LanguageCode { get; set; }
        public DateTime StartDate { get; set; }
        public IEnumerable<CalendarEvent> CalendarEvents { get; set; }

        private const string JS = "<script src=\"{0}\" Type=\"text/javascript\"></script>";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (string.IsNullOrWhiteSpace(Id))
                {
                    Id = Guid.NewGuid().ToString();
                }
            }

            RegisterScripts(Page.ClientScript);
        }

        private static void RegisterScripts(ClientScriptManager manager)
        {
            RegisterScript(manager, "jquery.timeago.js", "js/jquery.timeago.js");
            RegisterScript(manager, "js/jquery.eventCalendar.js", "js/jquery.eventCalendar.js");
            RegisterScript(manager, "event-calendar.js", "calendar.js");
        }

        private static IEnumerable<string> GetMonths(CultureInfo cultureInfo)
        {
            return Enumerable
                        .Range(1, 12)
                        .Select(month => cultureInfo.DateTimeFormat.GetMonthName(month));
        }

        private static IEnumerable<string> GetAbbreviatedDays(CultureInfo cultureInfo)
        {
            string[] days = cultureInfo.DateTimeFormat.AbbreviatedDayNames;

            return Enumerable
                        .Range(0, 7)
                        .Select(day => days[day]);
        }

        private IEnumerable<string> GetDays(CultureInfo cultureInfo)
        {
            return Enumerable
                   .Range(0, 7)
                   .Select(day => cultureInfo.DateTimeFormat.GetDayName((DayOfWeek)day))
                   .Select(day => FirstCharToUpper(day));
        }

        private CultureInfo GetCulture(int culture)
        {
            return CultureInfo.GetCultureInfo(culture);
        }

        private static void RegisterScript(ClientScriptManager manager, string key, string path)
        {
            if (!manager.IsStartupScriptRegistered(key))
            {
                manager.RegisterStartupScript(typeof(string), key, string.Format(JS, path), false);
            }
        }

        private static string FirstCharToUpper(string input)
        {
            return input.First().ToString().ToUpper() + String.Join(string.Empty, input.Skip(1));
        }

        public static string UnixTicks(DateTime date)
        {
            DateTime startDate = new DateTime(1970, 1, 1);
            DateTime currentDate = date.ToUniversalTime();
            TimeSpan timeSpan = new TimeSpan(currentDate.Ticks - startDate.Ticks);

            return timeSpan.TotalMilliseconds.ToString();
        }
    }
}