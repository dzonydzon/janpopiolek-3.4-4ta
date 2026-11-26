using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using System;

namespace TimerApp;

public partial class MainWindow : Window
{
    private enum Phase
    {
        Work,
        Break
    }

    private readonly DispatcherTimer _timer;
    private Phase _phase = Phase.Work;
    private int _remainingSeconds;
    private int _completedCycles;

    public MainWindow()
    {
        InitializeComponent();

        _remainingSeconds = GetWorkSeconds();
        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        _timer.Tick += TimerTick;

        WorkMinutes.ValueChanged += (_, _) =>
        {
            if (!_timer.IsEnabled && _phase == Phase.Work)
            {
                _remainingSeconds = GetWorkSeconds();
                UpdateDisplay();
            }
        };
        BreakMinutes.ValueChanged += (_, _) =>
        {
            if (!_timer.IsEnabled && _phase == Phase.Break)
            {
                _remainingSeconds = GetBreakSeconds();
                UpdateDisplay();
            }
        };

        UpdateDisplay();
    }

    private int GetWorkSeconds()
    {
        return (int)(WorkMinutes.Value ?? 25) * 60;
    }

    private int GetBreakSeconds()
    {
        return (int)(BreakMinutes.Value ?? 5) * 60;
    }

    private void StartButton_Click(object? sender, RoutedEventArgs e)
    {
        if (_remainingSeconds == 0)
        {
            _remainingSeconds = _phase == Phase.Work ? GetWorkSeconds() : GetBreakSeconds();
        }

        _timer.Start();
        PauseButton.Content = "Pauza";
        StartButton.IsEnabled = false;
    }

    private void PauseButton_Click(object? sender, RoutedEventArgs e)
    {
        if (_timer.IsEnabled)
        {
            _timer.Stop();
            PauseButton.Content = "Wznów";
            StartButton.IsEnabled = true;
        }
        else if (PauseButton.Content?.ToString() == "Wznów")
        {
            _timer.Start();
            PauseButton.Content = "Pauza";
            StartButton.IsEnabled = false;
        }
    }

    private void ResetButton_Click(object? sender, RoutedEventArgs e)
    {
        _timer.Stop();
        _phase = Phase.Work;
        _remainingSeconds = GetWorkSeconds();
        _completedCycles = 0;
        PauseButton.Content = "Pauza";
        StartButton.IsEnabled = true;
        UpdateDisplay();
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        _remainingSeconds--;

        if (_remainingSeconds <= 0)
        {
            if (_phase == Phase.Work)
            {
                _completedCycles++;
                _phase = Phase.Break;
                _remainingSeconds = GetBreakSeconds();
            }
            else
            {
                _phase = Phase.Work;
                _remainingSeconds = GetWorkSeconds();
            }
        }

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        var minutes = _remainingSeconds / 60;
        var seconds = _remainingSeconds % 60;

        PhaseText.Text = _phase == Phase.Work ? "PRACA" : "PRZERWA";
        TimeText.Text = $"{minutes}:{seconds:00}";
        CycleText.Text = $"Ukończone cykle: {_completedCycles}";
    }
}