namespace ClockApp;

partial class Form0
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    /// 
    private Label l_upperRowPercentage;
    private TrackBar n_upperRowPercentage;
    private Button b_ColorTimeScore;
    private Button b_ColorTimeout;

    private Label l_defaultTime;
    private NumericUpDown n_defaultTime;

    private Label l_TimeoutTime;
    private NumericUpDown n_TimeoutTime;


    private Button buttonSave;

    private void InitializeComponent()
    {
        
        this.l_upperRowPercentage = new Label();
        this.n_upperRowPercentage = new TrackBar();

        
        this.b_ColorTimeScore = new Button();

        this.b_ColorTimeout = new Button();

        this.l_defaultTime = new Label();
        this.n_defaultTime = new NumericUpDown();

        this.l_TimeoutTime = new Label();
        this.n_TimeoutTime = new NumericUpDown();

        this.buttonSave = new Button();
        ((System.ComponentModel.ISupportInitialize)(this.n_upperRowPercentage)).BeginInit();
        this.SuspendLayout();

        this.l_upperRowPercentage.Location = new System.Drawing.Point(20, 40);
        this.l_upperRowPercentage.Name = "l_upperRowPercentage";
        this.l_upperRowPercentage.Size = new System.Drawing.Size(240, 20);
        this.l_upperRowPercentage.Text = "Zeitanzeige Größe (Prozent): 65%";

        // n_upperRowPercentage
        this.n_upperRowPercentage.Location = new System.Drawing.Point(20, 60);
        this.n_upperRowPercentage.Name = "n_upperRowPercentage";
        this.n_upperRowPercentage.Size = new System.Drawing.Size(240, 20);
        this.n_upperRowPercentage.TabIndex = 1;
        this.n_upperRowPercentage.Maximum = 99;
        this.n_upperRowPercentage.Minimum = 1;
        this.n_upperRowPercentage.TickFrequency = 1;
        this.n_upperRowPercentage.Scroll += new System.EventHandler(this.n_upperRowPercentageChanged);
        this.n_upperRowPercentage.Value = 65;
        // c_TimeScore
        
        this.b_ColorTimeScore.Location = new System.Drawing.Point(20, 100);
        this.b_ColorTimeScore.Name = "b_ColorTimeScore";
        this.b_ColorTimeScore.Size = new System.Drawing.Size(240, 17);
        this.b_ColorTimeScore.TabIndex = 2;
        this.b_ColorTimeScore.Text = "Farbe auswählen (Zeit und Spielstand)";
        this.b_ColorTimeScore.Click += new System.EventHandler(this.choseColorTimeScore);

        this.b_ColorTimeout.Location = new System.Drawing.Point(20, 140);
        this.b_ColorTimeout.Name = "b_ColorTimeScore";
        this.b_ColorTimeout.Size = new System.Drawing.Size(240, 17);
        this.b_ColorTimeout.TabIndex = 2;
        this.b_ColorTimeout.Text = "Farbe auswählen (Zeitstrafe)";
        this.b_ColorTimeout.Click += new System.EventHandler(this.choseColorTimeout);


        this.l_defaultTime.Location = new System.Drawing.Point(20, 180);
        this.l_defaultTime.Name = "l_upperRowPercentage";
        this.l_defaultTime.Size = new System.Drawing.Size(240, 20);
        this.l_defaultTime.Text = "Spielzeit (Minuten)";

        this.n_defaultTime.Location = new System.Drawing.Point(20, 200);
        this.n_defaultTime.Name = "n_defaultTime";
        this.n_defaultTime.Size = new System.Drawing.Size(120, 20);
        this.n_defaultTime.Value = 12;

        this.l_TimeoutTime.Location = new System.Drawing.Point(20, 240);
        this.l_TimeoutTime.Name = "l_TimeoutTime";
        this.l_TimeoutTime.Size = new System.Drawing.Size(240, 20);
        this.l_TimeoutTime.Text = "Zeitstrafe (Minuten)";

        this.n_TimeoutTime.Location = new System.Drawing.Point(20, 260);
        this.n_TimeoutTime.Name = "n_TimeoutTime";
        this.n_TimeoutTime.Size = new System.Drawing.Size(120, 20);
        this.n_TimeoutTime.Value = 2;



        // buttonSave
        this.buttonSave.Location = new System.Drawing.Point(20, 400);
        this.buttonSave.Name = "buttonSave";
        this.buttonSave.Size = new System.Drawing.Size(75, 23);
        this.buttonSave.TabIndex = 3;
        this.buttonSave.Text = "Save";
        this.buttonSave.UseVisualStyleBackColor = true;
        this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);

        // ConfigForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(500, 500);
        this.Controls.Add(this.l_upperRowPercentage);
        this.Controls.Add(this.buttonSave);
        this.Controls.Add(this.b_ColorTimeScore);
        this.Controls.Add(this.b_ColorTimeout);
        this.Controls.Add(this.l_defaultTime);
        this.Controls.Add(this.n_defaultTime);

        this.Controls.Add(this.l_TimeoutTime);
        this.Controls.Add(this.n_TimeoutTime);

        this.Controls.Add(this.n_upperRowPercentage);
        
        this.Name = "ConfigForm";
        this.Text = "Configuration";
        ((System.ComponentModel.ISupportInitialize)(this.n_upperRowPercentage)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
}
