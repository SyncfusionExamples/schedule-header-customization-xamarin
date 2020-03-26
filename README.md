# How to customize the schedule header in Xamarin.Forms Schedule (SfSchedule)

You can customize the header of [SfSchedule](https://help.syncfusion.com/xamarin/scheduler/overview?) in Xamarin.Forms by using [VisibileDatesChangedEvent](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.SfSchedule~VisibleDatesChangedEvent_EV.html?).

**XAML**

Set the [HeaderHeight](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.SfSchedule~HeaderHeight.html?) property to zero to hide the default header. Instead of the Schedule header labels used to show the Schedule header.

``` xml
<Grid Grid.Row="1">
    <Grid.RowDefinitions>
        <RowDefinition Height="0.1*"/>
        <RowDefinition Height="0.9*"/>
    </Grid.RowDefinitions>
    <Label BackgroundColor="White" x:Name="dayHeader" Padding="30,0,0,0" Grid.Row="0" TextColor="Black" VerticalTextAlignment="Center" />
    <Label BackgroundColor="White" x:Name="weekHeader" Grid.Row="0" IsVisible="False" TextColor="Black" VerticalTextAlignment="Center" HorizontalTextAlignment="Center"/>
    <schedule:SfSchedule x:Name="Schedule"
                            DataSource="{Binding Meetings}"
                            HeaderHeight="0"
                            Grid.Row="1"
                            Margin="0">
     </Grid>
</Grid>
```
**C#**

Header content updated in SfSchedule's VisibleDatesChangedEvent when changing the view.

``` c#
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
```
**C#**

Header visibility has been handled when [ScheduleView](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.SfSchedule~ScheduleView.html?) changed dynamically.

``` c#
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
```
