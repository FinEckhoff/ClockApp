namespace ClockApp;
using System;
using System.Drawing;
using System.Net.Http.Headers;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private Timer countdownTimer;
    private int timeLeft; // in seconds
    private Label timeLabel;
    private int InitialTime = Form0.currentConfig.n_defaultTime; // 12 minutes in seconds
    private int leftScore = 0;
    private int rightScore = 0;

    private int InitialTimeout = Form0.currentConfig.n_TimeoutTime;
    private Label scoreLabel;
    private bool isFullscreen = false;
    private TableLayoutPanel layoutPanel;

    private Timer leftTimer, rightTimer;
    private int leftTimeLeft;
    private int rightTimeLeft;
    private Label leftTimerLabel, rightTimerLabel;
    private TableLayoutPanel bottomPanel;
    private float topRow = (float) Form0.currentConfig.n_upperRowPercentage;
    private float botRow = 100.0f - Form0.currentConfig.n_upperRowPercentage; 
    private float timeoutLabelSize = (100.0f - Form0.currentConfig.n_scorePercentage) / 2.0f;

    public Form1()
    {
        InitializeComponent();
        InitializeCountdown();
        this.KeyDown += Form1_KeyDown; // Attach KeyDown event handler
        this.KeyPreview = true; // Enable key events for the form
        this.AutoSize = true;
        this.Dock = DockStyle.Fill;
    }

    private void InitializeCountdown()
    {
        // Set the countdown time
        timeLeft = InitialTime;

        // Set up the form's appearance
        this.BackColor = Color.Black;
        this.FormBorderStyle = FormBorderStyle.Sizable;

        // Main layout panel that divides the form into two rows
        layoutPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 2,
            AutoSize = true,
            Margin = new Padding(0),
            Padding = new Padding(0),
        };
        layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, topRow)); // Top row for timeLabel
        layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, botRow)); // Bottom row for nested panel
        this.Controls.Add(layoutPanel);

        // Set up the label to display the countdown time
        timeLabel = new Label
        {
            ForeColor = Color.FromArgb(Form0.currentConfig.b_ColorTimeScore.ToArgb()),
            BackColor = Color.Black,
            
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.BottomCenter,
            Text = FormatTime(timeLeft),
            AutoSize = true,
            Padding = new Padding(0),
            Margin = new Padding(0),
        };
        layoutPanel.Controls.Add(timeLabel, 0, 0);

        // Create a nested panel for small timers and score in the lower row
        bottomPanel = new TableLayoutPanel
        {
            
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            Padding = new Padding(0),
            Margin = new Padding(0),
            
        };

        

        bottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, timeoutLabelSize)); // Left column for left timer
        bottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 - 2 * timeoutLabelSize)); // Center column for score
        bottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, timeoutLabelSize)); // Right column for right timer
        layoutPanel.Controls.Add(bottomPanel, 0, 1);

        // Set up the left timer label
        leftTimerLabel = new Label
        {
            ForeColor = Color.FromArgb(Form0.currentConfig.b_ColorTimeout.ToArgb()),
            BackColor = Color.Black,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.TopRight,
            Text = FormatTime(leftTimeLeft),
            AutoSize = true,
        };
        bottomPanel.Controls.Add(leftTimerLabel, 0, 0); // Top left cell in bottomPanel

        // Set up the right timer label
        rightTimerLabel = new Label
        {
            ForeColor = Color.FromArgb(Form0.currentConfig.b_ColorTimeout.ToArgb()),
            BackColor = Color.Black,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.TopLeft,
            Text = FormatTime(rightTimeLeft),
            AutoSize = true,
            
        };
        bottomPanel.Controls.Add(rightTimerLabel, 2, 0); // Top right cell in bottomPanel

        // Set up the label to display the score in the bottom row, centered in the middle column
        scoreLabel = new Label
        {
            ForeColor = Color.FromArgb(Form0.currentConfig.b_ColorTimeScore.ToArgb()),
            BackColor = Color.Black,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.TopCenter,
            Text = $"{leftScore} : {rightScore}",
            AutoSize = true,
            Padding = new Padding(0),
            //AutoSize = true, // Disable automatic resizing that may cause text wrapping
            //Font = new Font(scoreLabel.Font.FontFamily, 24, FontStyle.Bold) // Set a fixed font size
        };
        bottomPanel.Controls.Add(scoreLabel, 1, 0); // Bottom center cell in bottomPanel

        // Adjust font sizes for all labels
        AdjustFontSize();

        // Set up the main countdown timer
        countdownTimer = new Timer
        {
            Interval = 1000
        };
        countdownTimer.Tick += CountdownTimer_Tick;

        // Set up the left and right countdown timers
        leftTimer = new Timer
        {
            Interval = 1000
        };
        leftTimer.Tick += LeftTimer_Tick;
        leftTimerLabel.Hide();

        rightTimer = new Timer
        {
            Interval = 1000
        };
        rightTimer.Tick += RightTimer_Tick;
        rightTimerLabel.Hide();

        // Handle form resizing to adjust the font size
        this.Resize += (sender, e) => AdjustFontSize();
    }

    private void LeftTimer_Tick(object sender, EventArgs e)
    {
        if (leftTimeLeft > 0)
        {
            leftTimeLeft--;
            leftTimerLabel.Text = FormatTime(leftTimeLeft);
        }
        else
        {
            leftTimer.Stop();
            leftTimerLabel.Hide();

        }
    }

    // Tick event for right timer
    private void RightTimer_Tick(object sender, EventArgs e)
    {
        if (rightTimeLeft > 0)
        {
            rightTimeLeft--;
            rightTimerLabel.Text = FormatTime(rightTimeLeft);
        }
        else
        {
            rightTimer.Stop();
            rightTimerLabel.Hide();

        }
    }

    private void CountdownTimer_Tick(object sender, EventArgs e)
    {
        if (timeLeft > 0)
        {
            timeLeft--; // Decrease time by one second
            timeLabel.Text = FormatTime(timeLeft); // Update label text
        }
        else
        {   
            rightTimer.Stop();
            rightTimerLabel.Hide();
            leftTimer.Stop();
            leftTimerLabel.Hide();

            countdownTimer.Stop();
            timeLabel.Text = "Ende";
        }
    }

    private string FormatTime(int seconds)
    {
        int minutes = seconds / 60;
        int secs = seconds % 60;
        return $"{minutes:D2}:{secs:D2}";
    }

    private void AdjustFontSize()
{
    // Initial large font size
    int fontSize = Math.Min(timeLabel.Height, timeLabel.Width) / 2;
    int fontSize_score = Math.Min(scoreLabel.Height, scoreLabel.Width) / 2;
    // Create temporary font objects to measure text size
    using (var tempTimeFont = new Font(timeLabel.Font.FontFamily, fontSize, FontStyle.Bold))
    {
        // Measure the size of the time text with the current font size
        SizeF timeSize = TextRenderer.MeasureText(timeLabel.Text, tempTimeFont);
        

        // Decrease font size until both time and score fit within their areas
        while ((timeSize.Width > this.Width || timeSize.Height > this.Height * (topRow / botRow)
        
        ) && fontSize > 2)
        {
            Console.WriteLine(timeLabel.Width);
            fontSize--;
            timeSize = TextRenderer.MeasureText(timeLabel.Text, new Font(timeLabel.Font.FontFamily, fontSize, FontStyle.Bold));
            
        }
    }
    using (var tempScoreFont = new Font(scoreLabel.Font.FontFamily, fontSize_score, FontStyle.Bold))
    {
        SizeF scoreSize = TextRenderer.MeasureText(scoreLabel.Text, tempScoreFont);
        while ((scoreSize.Width > scoreLabel.Width * 0.95f || scoreSize.Height > this.Height *(botRow / topRow)
        
        ) && fontSize_score > 2)
        {
            fontSize_score--;
            scoreSize = TextRenderer.MeasureText(scoreLabel.Text, new Font(scoreLabel.Font.FontFamily, fontSize_score, FontStyle.Bold));
        }

    }




    float timeoutFontSize = fontSize_score * 0.75f;
    var tmpTimeoutLabel = leftTimerLabel.Visible ? leftTimerLabel : rightTimerLabel;
    
    using (var tempTimeoutFont = new Font(tmpTimeoutLabel.Font.FontFamily, timeoutFontSize, FontStyle.Bold))
    {
        // Measure the size of the time text with the current font size
       
        SizeF timeoutSize = TextRenderer.MeasureText(tmpTimeoutLabel.Text, tempTimeoutFont);

        
        while ((timeoutSize.Width > tmpTimeoutLabel.Width * 0.75f || timeoutSize.Height > tmpTimeoutLabel.Height* 0.75f) && timeoutFontSize > 1)
        {
            timeoutFontSize--;
            timeoutSize = TextRenderer.MeasureText(scoreLabel.Text, new Font(tmpTimeoutLabel.Font.FontFamily, timeoutFontSize, FontStyle.Bold));
        }
    }


   
    leftTimerLabel.Font = new Font(scoreLabel.Font.FontFamily, timeoutFontSize , FontStyle.Bold);
    rightTimerLabel.Font = new Font(scoreLabel.Font.FontFamily, timeoutFontSize , FontStyle.Bold);
    // Apply the calculated font size to both labels
    timeLabel.Font = new Font(timeLabel.Font.FontFamily, fontSize , FontStyle.Bold);
    scoreLabel.Font = new Font(scoreLabel.Font.FontFamily, fontSize_score, FontStyle.Bold);
}

    

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {

        if (e.Control && e.KeyCode == Keys.Left)
        {
            leftTimeLeft = InitialTimeout;
            leftTimer.Start();
            leftTimerLabel.Text = FormatTime(leftTimeLeft);
            
            leftTimerLabel.Show();
            leftTimer.Stop();
            if (countdownTimer.Enabled)
            {
                leftTimer.Start();
            }
            AdjustFontSize();
        }
        if (e.Control && e.KeyCode == Keys.Right)
        {
            rightTimeLeft = InitialTimeout;
            rightTimer.Start();
            rightTimerLabel.Text = FormatTime(rightTimeLeft);
            rightTimerLabel.Show();
            rightTimer.Stop();
            if (countdownTimer.Enabled)
            {
                rightTimer.Start();
            }
            AdjustFontSize();
        }

        if (e.KeyCode == Keys.F11)
        {
            ToggleFullscreen();
        }

        if (e.KeyCode == Keys.Space)
        {
            // Toggle the timer when Space is pressed
            if (countdownTimer.Enabled)
            {
                leftTimer.Stop();
                rightTimer.Stop();
                countdownTimer.Stop();
            }
            else
            {
                leftTimer.Start();
                rightTimer.Start();
                countdownTimer.Start();
            }
        }
        else if (e.KeyCode == Keys.Escape)
        {
            // Reset the timer when Esc is pressed
            countdownTimer.Stop();
            rightTimer.Stop();
            rightTimerLabel.Hide();
            leftTimer.Stop();
            leftTimerLabel.Hide();
            leftTimeLeft = InitialTimeout;
            rightTimeLeft = InitialTimeout;
            timeLeft = InitialTime;
            leftScore = 0;
            rightScore = 0;
            UpdateScore();
            timeLabel.Text = FormatTime(timeLeft);
        }
        else if (e.Control && e.KeyCode == Keys.Oemplus) // Ctrl + Plus
        {
            if (!countdownTimer.Enabled)
            {
                // Increase time by 1 minute
                InitialTime += 60;
                timeLabel.Text = FormatTime(InitialTime);
                timeLeft = InitialTime;
            }
        }
        else if (e.Control && e.KeyCode == Keys.OemMinus) // Ctrl + Minus
        {
            if (!countdownTimer.Enabled)
            {
                // Decrease time by 1 minute, but not below 0
                InitialTime = Math.Max(0, InitialTime - 60);
                timeLabel.Text = FormatTime(InitialTime);
                timeLeft = InitialTime;
            }
        }
        else if (e.Control && e.KeyCode == Keys.A) // Ctrl + A to increase left score
        {
            leftScore++;
            UpdateScore();
        }
        else if (e.Control && e.KeyCode == Keys.B) // Ctrl + B to increase right score
        {
            rightScore++;
            UpdateScore();
        }
        else if (e.Control && e.KeyCode == Keys.C) // Ctrl + C to reset the score
        {
            leftScore = 0;
            rightScore = 0;
            UpdateScore();
        }
        else if (e.Control && e.Shift && e.KeyCode == Keys.Left){
            leftTimer.Stop();
            leftTimerLabel.Hide();
            leftTimeLeft = InitialTimeout;
        }
        else if (e.Control && e.Shift && e.KeyCode == Keys.Right){
            rightTimer.Stop();
        rightTimerLabel.Hide();
            rightTimeLeft = InitialTimeout;
        }

        AdjustFontSize();
    }

    private void ToggleFullscreen()
    {
        if (isFullscreen)
        {
            // Exit fullscreen
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            this.TopMost = false; // Return to normal window layering
            isFullscreen = false;
        }
        else
        {
            // Enter fullscreen
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Normal; // Set to Normal before setting bounds
            this.Bounds = Screen.PrimaryScreen.Bounds; // Set the form to cover the entire screen
            this.TopMost = true; // Ensure the form is above other windows
            isFullscreen = true;
        }
    }


    private void UpdateScore()
    {
        scoreLabel.Text = $"{leftScore} : {rightScore}";
    }
}
