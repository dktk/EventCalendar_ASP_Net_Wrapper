(function ($) {
    var container = $("*[data-container='calendar']");
    var settings = container.find("script[type='text/x-data-settings']").html();
    settings = settings ? JSON.parse(settings) : {};

    container.eventCalendar(settings);
})(jQuery);