namespace ClockApp;
using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

public partial class Form0 : Form
{
    public static Config currentConfig;
    public Form0()
    {
        InitializeComponent();

        this.KeyDown += Form0_KeyDown; // Attach KeyDown event handler
        this.KeyPreview = true; // Enable key events for the form
        this.AutoSize = true;
        this.Dock = DockStyle.Fill;
    }



    private void Form0_KeyDown(object sender, KeyEventArgs e)
    {

    }
    public class Config
    {
        public int n_upperRowPercentage { get; set; }
        public int n_scorePercentage { get; set; }
        public Color b_ColorTimeScore { get; set; }
        public Color b_ColorTimeout { get; set; }
        public int n_defaultTime { get; set; }
        public int n_TimeoutTime { get; set; }
    }
    
    private readonly string configFilePath = "config.json";

    private void LoadConfig()
    {
        if (File.Exists(configFilePath))
        {
            string json = File.ReadAllText(configFilePath);
            currentConfig = JsonConvert.DeserializeObject<Config>(json);




        }
        else
        {
            currentConfig = new Config();
        }

        // Set UI elements based on loaded config

        n_upperRowPercentage.Value = currentConfig.n_upperRowPercentage;

    }
    private void SaveConfig()
    {
        currentConfig = new Config();
        currentConfig.n_upperRowPercentage = n_upperRowPercentage.Value;
        currentConfig.n_scorePercentage = n_scorePercentage.Value;
        currentConfig.b_ColorTimeScore = b_ColorTimeScoretmp;
        currentConfig.b_ColorTimeout = b_ColorTimeouttmp;
        currentConfig.n_defaultTime = (int)n_defaultTime.Value;
        currentConfig.n_TimeoutTime = (int)n_TimeoutTime.Value;


        string json = JsonConvert.SerializeObject(currentConfig, Formatting.Indented);
        File.WriteAllText(configFilePath, json);

        MessageBox.Show("Configuration saved successfully.");
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
        SaveConfig();
        this.Close();
    }
    Color b_ColorTimeScoretmp = Color.Red; 
    private void choseColorTimeScore(object sender, EventArgs e)
    {
        ColorDialog cd = new ColorDialog();

        cd.ShowHelp = true;
        // Sets the initial color select to the current text color.
        if (cd.ShowDialog() == DialogResult.OK)
        {
            b_ColorTimeScoretmp = cd.Color;
        }
    }
    Color b_ColorTimeouttmp = Color.LightGray;
    private void choseColorTimeout(object sender, EventArgs e)
    {
        ColorDialog cd = new ColorDialog();

        cd.ShowHelp = true;
        // Sets the initial color select to the current text color.
        if (cd.ShowDialog() == DialogResult.OK)
        {
            b_ColorTimeouttmp = cd.Color;
        }
    }
     private void n_upperRowPercentageChanged(object sender, EventArgs e)
    {
        l_upperRowPercentage.Text = "Zeitanzeige Größe (Prozent): " + n_upperRowPercentage.Value + "%";
    }
    private void n_scorePercentageChanged(object sender, EventArgs e)
    {
        l_scorePercentage.Text = "Score Breite (Prozent): " + n_scorePercentage.Value + "%";
    }

}