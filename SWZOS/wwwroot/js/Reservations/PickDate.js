$(function () {

    const app = {
        async loadEvents(day) {
            const start = nav.visibleStart() > DayPilot.Date.now() ? nav.visibleStart() : DayPilot.Date.now();
            const end = nav.visibleEnd();

            const { data } = await DayPilot.Http.get(PickDateUrl.GetRange
                + "?pitchTypeId=" + pitchTypeId
                + "&start=" + start
                + "&end=" + end);

            if (day) {
                calendar.startDate = day;
            }
            calendar.events.list = data;
            calendar.update();

            nav.events.list = data;
            nav.update();
        },
        init() {
            app.loadEvents();
        }
    };

    const nav = new DayPilot.Navigator("nav", {
        selectMode: "week",
        showMonths: 3,
        skipMonths: 3,
        onTimeRangeSelected: (args) => {
            const weekStarts = DayPilot.Locale.find(nav.locale).weekStarts;
            const start = args.start.firstDayOfWeek(weekStarts);
            const end = args.start.addDays(7);
            app.loadEvents(start, end);
        }

    });
    nav.init();

    const calendar = new DayPilot.Calendar("calendar", {
        viewType: "Week",
        timeRangeSelectedHandling: "Disabled",
        eventMoveHandling: "Disabled",
        eventResizeHandling: "Disabled",
        eventArrangement: "SideBySide",
        onBeforeEventRender: (args) => {
            switch (args.data.status) {
                case "free":
                    args.data.backColor = "#3d85c6";  // blue
                    args.data.barHidden = true;
                    args.data.borderColor = "darker";
                    args.data.fontColor = "white";
                    args.data.toolTip = "Termin dostępny";
                    break;
                case "unavailable":
                    args.data.backColor = "#e69138";  // orange
                    args.data.barHidden = true;
                    args.data.borderColor = "darker";
                    args.data.fontColor = "white";
                    args.data.toolTip = "Termin niedostępny";
                    break;
                case "userReservation":
                    args.data.backColor = "#6aa84f";  // green
                    args.data.barHidden = true;
                    args.data.borderColor = "darker";
                    args.data.fontColor = "white";
                    args.data.toolTip = "Twoja rezerwacja";
                    break;
            }
        },
        onEventClick: async (args) => {
            if (args.e.data.status !== "free") {
                calendar.message("Nie możesz wybrać tego terminu, lub już złożyłeś na ten termin rezerwację");
                return;
            }

            window.location.href = PickDateUrl.AddReservation + "?pitchTypeId=" + pitchTypeId + "&start=" + args.e.start();

        }
    });
    calendar.init();

    app.init();
});