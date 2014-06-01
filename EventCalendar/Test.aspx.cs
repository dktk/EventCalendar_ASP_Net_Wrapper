using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventCalendar
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar.StartDate = new DateTime(2013, 5, 21);
            var events = new[] { new CalendarEvent
                                    {
                                        Date = new DateTime(2013, 5, 2),
                                        Description = "Something happened that day",
                                        Title = "The 2nd of May",
                                        Url = "http://www.path.com/2013/5/2"
                                    },

                                    new CalendarEvent
                                    {
                                        Date = new DateTime(2013, 5, 7),
                                        Description = "Something happened that day",
                                        Title = "The 7th of May",
                                        Url = "http://www.path.com/2013/5/7"
                                    },

                                    new CalendarEvent
                                    {
                                        Date = new DateTime(2013, 5, 12),
                                        Description = "Something happened that day",
                                        Title = "The 12th of May",
                                        Url = "http://www.path.com/2013/5/12"
                                    },

                                    new CalendarEvent
                                    {
                                        Date = new DateTime(2013, 5, 22),
                                        Description = "Something happened that day",
                                        Title = "The 22nd of May",
                                        Url = "http://www.path.com/2013/5/22"
                                    }
            };
            Calendar.CalendarEvents = events;
            Calendar.LanguageCode = 1048;

            DataBind();
        }
    }
}