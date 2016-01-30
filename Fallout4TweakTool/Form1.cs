using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Fallout4TweakTool
{
    public partial class Form1 : Form
    {
        String FO4DocFolder = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Fallout4");
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String FO4Prefs = (FO4DocFolder + @"\Fallout4Prefs.ini");
            String FO4Custom = (FO4DocFolder + @"\Fallout4Custom.ini");
            setReadOff();

            IniFile ini = new IniFile(FO4Prefs);
            ini.IniWriteValue("Launcher", "bEnableFileSelection", "1");
            IniFile ini2 = new IniFile(FO4Custom);
            ini.IniWriteValue("Archive", "bInvalidateOlderFiles", "1");
            ini.IniWriteValue("Archive", "sResourceDataDirsFinal", " ");
            setReadON();

        }

        public class IniFile
        {
            public string path;

            [DllImport("kernel32")]
            private static extern long WritePrivateProfileString(string section,
                string key, string val, string filePath);
            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string section,
                     string key, string def, StringBuilder retVal,
                int size, string filePath);

            public IniFile(string INIPath)
            {
                path = INIPath;
            }

            public void IniWriteValue(string Section, string Key, string Value)
            {
                WritePrivateProfileString(Section, Key, Value, this.path);
            }

            public string IniReadValue(string Section, string Key)
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(Section, Key, "", temp,
                                                255, this.path);
                return temp.ToString();

            }
        }

        public void setReadOff()
        {
            File.SetAttributes((FO4DocFolder + @"\Fallout4Prefs.ini"), ~FileAttributes.ReadOnly);
            File.SetAttributes((FO4DocFolder + @"\Fallout4Custom.ini"), ~FileAttributes.ReadOnly);
            File.SetAttributes((FO4DocFolder + @"\Fallout4.ini"), ~FileAttributes.ReadOnly);

        }

        public void setReadON()
        {
            File.SetAttributes((FO4DocFolder + @"\Fallout4Prefs.ini"), FileAttributes.ReadOnly);
            File.SetAttributes((FO4DocFolder + @"\Fallout4Custom.ini"), FileAttributes.ReadOnly);
            File.SetAttributes((FO4DocFolder + @"\Fallout4.ini"), FileAttributes.ReadOnly);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            String FO4Custom = (FO4DocFolder + @"\Fallout4Custom.ini");

            IniFile ini = new IniFile(FO4Custom);
            setReadOff();
            ini.IniWriteValue("Display", "fPipboyScreenEmitIntensityPA", "1.0000");
            ini.IniWriteValue("Display", "fPipboyScreenEmitIntensity", "1.2500");
            ini.IniWriteValue("Pipboy", "bPipboyDisableFX", "1");
            setReadON();
            System.Windows.Forms.MessageBox.Show("PipBoy Fx Disabled. Intensitys set to PA:1.0000 PB:1.2500");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String FO4Custom = (FO4DocFolder + @"\Fallout4Custom.ini");

            IniFile ini = new IniFile(FO4Custom);
            setReadOff();
            ini.IniWriteValue("Display", "fPipboyScreenEmitIntensityPA", textBox1.Text);
            ini.IniWriteValue("Display", "fPipboyScreenEmitIntensity", textBox2.Text);
            ini.IniWriteValue("Pipboy", "bPipboyDisableFX", "1");
            setReadON();
            System.Windows.Forms.MessageBox.Show("Intensitys set to PA:"+ textBox1.Text + " PB:" + textBox2.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String FO4Custom = (FO4DocFolder + @"\Fallout4Custom.ini");
            setReadOff();
            IniFile ini = new IniFile(FO4Custom);
            ini.IniWriteValue("Display", "bBorderless", "1");
            ini.IniWriteValue("Display", "bFull Screen", "0");
            ini.IniWriteValue("Display", "bTopMostWindow", "0");
            ini.IniWriteValue("Display", "bMaximizeWindow", "0");
            setReadON();
            System.Windows.Forms.MessageBox.Show("Set Borderless fullscreen");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String FO4Custom = (FO4DocFolder + @"\Fallout4Custom.ini");
            setReadOff();
            IniFile ini = new IniFile(FO4Custom);
            ini.IniWriteValue("gameplay", "fPlayerDisableSprintingLoadingCellDistance", "0");
            setReadON();
            System.Windows.Forms.MessageBox.Show("Cell reset Run Bug fix applied.");
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            String FO4Custom = (FO4DocFolder + @"\Fallout4Custom.ini");
            setReadOff();
            IniFile ini = new IniFile(FO4Custom);
            ini.IniWriteValue("General", "sIntroSequence", "0");
            ini.IniWriteValue("General", "fChancesToPlayAlternateIntro", "0");
            ini.IniWriteValue("General", "uMainMenuDelayBeforeAllowSkip", "0");
            setReadON();
            System.Windows.Forms.MessageBox.Show("Intro sequence disabled.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String FO4Custom = (FO4DocFolder + @"\Fallout4Custom.ini");
            setReadOff();
            IniFile ini = new IniFile(FO4Custom);
            ini.IniWriteValue("Display", "fDefault1stPersonFOV", textBox3.Text);
            String FO4Prefs = (FO4DocFolder + @"\Fallout4Prefs.ini");
            IniFile ini2 = new IniFile(FO4Prefs);
            ini2.IniWriteValue("Display", "fDefault1stPersonFOV", textBox3.Text);
            setReadON();
            System.Windows.Forms.MessageBox.Show("Set 1st Person FOV to " + textBox3.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String FO4Custom = (FO4DocFolder + @"\Fallout4Custom.ini");
            setReadOff();
            IniFile ini = new IniFile(FO4Custom);
            ini.IniWriteValue("Display", "fDefaultWorldFOV", textBox4.Text);
            String FO4Prefs = (FO4DocFolder + @"\Fallout4Prefs.ini");
            IniFile ini2 = new IniFile(FO4Prefs);
            ini2.IniWriteValue("Display", "fDefaultWorldFOV", textBox4.Text);
            setReadON();
            System.Windows.Forms.MessageBox.Show("Set 3rd Person FOV to " + textBox4.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.nexusmods.com/fallout4/mods/8877");
        }

    }
}
