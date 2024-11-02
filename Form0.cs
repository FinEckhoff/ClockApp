namespace ClockApp;
using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
public partial class Form0 : Form
{
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
        public string Option1 { get; set; }
        public int Option2 { get; set; }
        public bool Option3 { get; set; }
    }
    private Config currentConfig;
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

        n_upperRowPercentage.Value = currentConfig.Option2;

    }
    private void SaveConfig()
    {
        currentConfig = new Config();
        currentConfig.Option2 = (int)n_upperRowPercentage.Value;


        string json = JsonConvert.SerializeObject(currentConfig, Formatting.Indented);
        File.WriteAllText(configFilePath, json);

        MessageBox.Show("Configuration saved successfully.");
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
        SaveConfig();
    }
    private void choseColorTimeScore(object sender, EventArgs e)
    {
        ColorDialog cd = new ColorDialog();

        cd.ShowHelp = true;
        // Sets the initial color select to the current text color.
        if (cd.ShowDialog() == DialogResult.OK)
        {
            var tmp = cd.Color;
        }
    }

    private void choseColorTimeout(object sender, EventArgs e)
    {
        ColorDialog cd = new ColorDialog();

        cd.ShowHelp = true;
        // Sets the initial color select to the current text color.
        if (cd.ShowDialog() == DialogResult.OK)
        {
            var tmp = cd.Color;
        }
    }
     private void n_upperRowPercentageChanged(object sender, EventArgs e)
    {
        l_upperRowPercentage.Text = "Zeitanzeige Größe (Prozent): " + n_upperRowPercentage.Value + "%";
    }

}