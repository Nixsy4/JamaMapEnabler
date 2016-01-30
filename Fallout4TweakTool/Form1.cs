using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Fallout4TweakTool;
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

            IniFile ini = new IniFile(FO4Prefs);
            ini.IniWriteValue("Launcher", "bEnableFileSelection", "1");

            IniFile ini2 = new IniFile(FO4Custom);
            ini.IniWriteValue("Archive", "bInvalidateOlderFiles", "1");
            ini.IniWriteValue("Archive", "sResourceDataDirsFinal", " ");

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

            /// <summary>
            /// INIFile Constructor.
            /// </summary>
            /// <PARAM name="INIPath"></PARAM>
            public IniFile(string INIPath)
            {
                path = INIPath;
            }
            /// <summary>
            /// Write Data to the INI File
            /// </summary>
            /// <PARAM name="Section"></PARAM>
            /// Section name
            /// <PARAM name="Key"></PARAM>
            /// Key Name
            /// <PARAM name="Value"></PARAM>
            /// Value Name
            public void IniWriteValue(string Section, string Key, string Value)
            {
                WritePrivateProfileString(Section, Key, Value, this.path);
            }

            /// <summary>
            /// Read Data Value From the Ini File
            /// </summary>
            /// <PARAM name="Section"></PARAM>
            /// <PARAM name="Key"></PARAM>
            /// <PARAM name="Path"></PARAM>
            /// <returns></returns>
            public string IniReadValue(string Section, string Key)
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(Section, Key, "", temp,
                                                255, this.path);
                return temp.ToString();

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            String FO4Custom = (FO4DocFolder + @"\Fallout4Custom.ini");

            IniFile ini = new IniFile(FO4Custom);
            ini.IniWriteValue("Display", "fPipboyScreenEmitIntensityPA", "1.0000");
            ini.IniWriteValue("Display", "fPipboyScreenEmitIntensity", "1.2500");
            ini.IniWriteValue("Pipboy", "bPipboyDisableFX", "1");
            System.Windows.Forms.MessageBox.Show("Intensitys set to PA:1.0000 PB:1.2500");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String FO4Custom = (FO4DocFolder + @"\Fallout4Custom.ini");

            IniFile ini = new IniFile(FO4Custom);
            ini.IniWriteValue("Display", "fPipboyScreenEmitIntensityPA", textBox1.Text);
            ini.IniWriteValue("Display", "fPipboyScreenEmitIntensity", textBox2.Text);
            ini.IniWriteValue("Pipboy", "bPipboyDisableFX", "1");
            System.Windows.Forms.MessageBox.Show("Intensitys set to PA:"+ textBox1.Text + " PB:" + textBox2.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String FO4Custom = (FO4DocFolder + @"\Fallout4Custom.ini");

            IniFile ini = new IniFile(FO4Custom);
            ini.IniWriteValue("Display", "bBorderless", "1");
            ini.IniWriteValue("Display", "bFull Screen", "0");
            ini.IniWriteValue("Display", "bTopMostWindow", "0");
            ini.IniWriteValue("Display", "bMaximizeWindow", "0");
            System.Windows.Forms.MessageBox.Show("Set Borderless fullscreen");
        }

    }
}
