<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Calendar.ascx.cs" Inherits="EventCalendar.Calendar" %>

<div id="<%# Id %>" data-container="calendar" data-start-day="<%# StartDate.Day %>" data-start-month="<%# StartDate.AddMonths(-1).Month %>" data-start-year="<%# StartDate.Year %>">
    <script type="text/x-data-settings">
        <%# Settings %>
    </script>
</div>