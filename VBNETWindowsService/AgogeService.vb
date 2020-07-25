Public Class AgogeService

    Private eventId As Integer
    Private timer As System.Timers.Timer

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        EventLog1.WriteEntry("In OnStart")

        ' Set up a timer to trigger every minute.
        timer = New System.Timers.Timer()
        timer.Interval = 60000 ' 60 seconds
        AddHandler timer.Elapsed, AddressOf Me.OnTimer
        timer.Start()
    End Sub

    Private Sub OnTimer(sender As Object, e As Timers.ElapsedEventArgs)
        ' TODO: Insert monitoring activities here.
        EventLog1.WriteEntry("Service is running " & Now.ToString, EventLogEntryType.Information, eventId)
        eventId = eventId + 1
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        EventLog1.WriteEntry("In OnStop.")
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        If Not System.Diagnostics.EventLog.SourceExists("AgogeService") Then
            System.Diagnostics.EventLog.CreateEventSource("AgogeService", "AgogeServiceLog")
        End If

    End Sub
End Class
