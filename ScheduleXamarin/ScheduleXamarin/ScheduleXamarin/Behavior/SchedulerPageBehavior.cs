using System;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace ScheduleXamarin
{
    public class SchedulerPageBehavior : Behavior<ContentPage>
    {
        SfSchedule schedule;
        Button scheduleViewButton;
        Label dayHeader, weekHeader;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.schedule = bindable.Content.FindByName<SfSchedule>("Schedule");
            this.scheduleViewButton = bindable.Content.FindByName<Button>("ScheduleViewButton");
            this.dayHeader = bindable.Content.FindByName<Label>("dayHeader");
            this.weekHeader = bindable.Content.FindByName<Label>("weekHeader");
            this.WireEvents();
        }

        private void WireEvents()
        {
            this.schedule.VisibleDatesChangedEvent += Schedule_VisibleDatesChangedEvent;
            this.scheduleViewButton.Clicked += ScheduleViewButton_Clicked;
        }

        /// <summary>
        /// Change schedule view and handle visibility of header views
        /// </summary>
        private void ScheduleViewButton_Clicked(object sender, EventArgs e)
        {
            if (schedule.ScheduleView == ScheduleView.WeekView)
            {
                schedule.ScheduleView = ScheduleView.DayView;
                dayHeader.IsVisible = true;
                weekHeader.IsVisible = false;
            }
            else
            {
                schedule.ScheduleView = ScheduleView.WeekView;
                dayHeader.IsVisible = false;
                weekHeader.IsVisible = true;
            }
        }

        private void Schedule_VisibleDatesChangedEvent(object sender, Syncfusion.SfSchedule.XForms.VisibleDatesChangedEventArgs e)
        {
            if (schedule.ScheduleView == ScheduleView.DayView)
            {
                dayHeader.Text = e.visibleDates[0].ToString("MMMM yyyy");
            }
            else if (schedule.ScheduleView == ScheduleView.WeekView)
            {
                weekHeader.Text = e.visibleDates[0].ToString("MMMM yyyy");
            }
        }
      
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            this.UnWireEvents();
        }

        private void UnWireEvents()
        {
            this.schedule.VisibleDatesChangedEvent -= Schedule_VisibleDatesChangedEvent;
            this.scheduleViewButton.Clicked -= ScheduleViewButton_Clicked;

        }
    }
}
