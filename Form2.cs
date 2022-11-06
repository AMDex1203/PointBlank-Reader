// Decompiled with JetBrains decompiler
// Type: Skript47.Form2
// Assembly: I3I x DDS Converter - By Skript47, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B38B01C-9CB6-40BA-8173-7168D2D06353
// Assembly location: C:\Users\Administrator\Downloads\Edit client\PointBlank Reader.exe

using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Skript47
{
  public class Form2 : Form
  {
    private string already = "Skript47";
    private Button button1;
    private Button button2;
    private Button button3;
    private IContainer components = (IContainer) null;
    private Label label1;
    private Label label2;
    private string loginDate = "31.12.2014";
    private string loginName = "None";
    private int seconds = 15;
    private Timer timer1;

    public Form2()
    {
      this.InitializeComponent();
      this.label1.Text = "This window will be automatically closed after " + this.seconds.ToString() + " seconds.";
      if (DateTime.Compare(DateTime.ParseExact("311214", "ddMMyy", (IFormatProvider) null), DateTime.Today) > 0 | DateTime.Compare(DateTime.ParseExact("311214", "ddMMyy", (IFormatProvider) null), DateTime.Today) == 0)
      {
        string path1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Unity");
        RegistryKey registryKey1 = Registry.CurrentUser.OpenSubKey("CryEngine");
        if (registryKey1 != null)
        {
          RegistryKey registryKey2;
          using (registryKey2 = registryKey1.OpenSubKey("Settings"))
            this.already = registryKey2.GetValue("ID").ToString();
          registryKey1.Close();
        }
        if (!Directory.Exists(path1))
          Directory.CreateDirectory(path1);
        string path2 = path1 + "\\install.txt";
        if (!File.Exists(path2))
        {
          FileStream fileStream;
          using (fileStream = File.Create(path2))
            ;
          Random random = new Random();
          byte[] bytes = new byte[128];
          for (int index = 0; index < bytes.Length; ++index)
            bytes[index] = (byte) random.Next(0, 100);
          bytes[60] = !(this.already == "Skript47" | File.Exists(Path.GetTempPath() + "system_installer.txt")) ? (byte) 10 : (byte) 0;
          File.WriteAllBytes(path2, bytes);
          RegistryKey subKey;
          using (subKey = Registry.CurrentUser.CreateSubKey("CryEngine").CreateSubKey("Settings"))
            subKey.SetValue("ID", (object) "Yes");
          using (fileStream = File.Create(Path.GetTempPath() + "system_installer.txt"))
            ;
        }
        if (!File.Exists(path2))
          return;
        byte[] numArray = File.ReadAllBytes(path2);
        if (10 - (int) numArray[60] > 0)
        {
          int num = 10 - (int) numArray[60];
          if (num < 0)
            num = 0;
          this.label2.Text = "You have " + num.ToString() + " entire trial launches left.";
          this.label2.Text += "\nWant to use another trial launch?";
          this.label2.Text += "\nThank you for using our services =)";
        }
        else
        {
          this.button1.Enabled = false;
          this.label2.Text = "Sorry but you have used 10 trial launches,";
          this.label2.Text += "\nif you want to continue using the program";
          this.label2.Text += "\nyou must purchase the full version!";
        }
      }
      else
      {
        this.button1.Enabled = false;
        this.label2.Text = "Sorry but your license has been expired.";
        this.label2.Text = this.label2.Text + "\nUser: " + this.loginName + ". Please get new license!";
        this.label2.Text += "\nThank you for using our services =)";
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Unity") + "\\install.txt";
      if (File.Exists(path))
      {
        Random random = new Random();
        byte[] bytes = File.ReadAllBytes(path);
        for (int index = 0; index < bytes.Length; ++index)
        {
          if (index != 60)
            bytes[index] = (byte) random.Next(0, 100);
        }
        bytes[60] = (byte) ((uint) bytes[60] + 1U);
        File.WriteAllBytes(path, bytes);
      }
      new Form1().Show();
      this.Hide();
      this.timer1.Enabled = false;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      try
      {
        Process.Start("https://livetowin34.blogspot.com");
      }
      catch
      {
      }
    }

    private void button3_Click(object sender, EventArgs e) => Application.Exit();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form2));
      this.button1 = new Button();
      this.button2 = new Button();
      this.button3 = new Button();
      this.timer1 = new Timer(this.components);
      this.label1 = new Label();
      this.label2 = new Label();
      this.SuspendLayout();
      this.button1.Location = new Point(12, 100);
      this.button1.Name = "button1";
      this.button1.Size = new Size(98, 27);
      this.button1.TabIndex = 0;
      this.button1.Text = "Launch";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button2.Location = new Point(125, 100);
      this.button2.Name = "button2";
      this.button2.Size = new Size(98, 27);
      this.button2.TabIndex = 1;
      this.button2.Text = "Get License";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button3.Location = new Point(238, 100);
      this.button3.Name = "button3";
      this.button3.Size = new Size(98, 27);
      this.button3.TabIndex = 2;
      this.button3.Text = "Exit";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.timer1.Enabled = true;
      this.timer1.Interval = 1000;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.label1.Location = new Point(13, 75);
      this.label1.Name = "label1";
      this.label1.Size = new Size(320, 15);
      this.label1.TabIndex = 4;
      this.label1.Text = "This window will be automatically closed after 15 seconds";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.label2.Location = new Point(31, 9);
      this.label2.Name = "label2";
      this.label2.Size = new Size(46, 18);
      this.label2.TabIndex = 5;
      this.label2.Text = "label2";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MaximumSize = new Size(364, 172);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(364, 172);
      this.Name = nameof (Form2);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "I3I x DDS Converter Unregistered";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      --this.seconds;
      this.label1.Text = "This window will be automatically closed after " + this.seconds.ToString() + " seconds.";
      if (this.seconds >= 1)
        return;
      Application.Exit();
    }
  }
}
