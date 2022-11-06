// Decompiled with JetBrains decompiler
// Type: Skript47.Form1
// Assembly: I3I x DDS Converter - By Skript47, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B38B01C-9CB6-40BA-8173-7168D2D06353
// Assembly location: C:\Users\Administrator\Downloads\Edit client\PointBlank Reader.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace Skript47
{
  public class Form1 : Form
  {
    private Button button1;
    private Button button3;
    private Button button4;
    private Button button5;
    private Button button6;
    private Button button9;
    private IContainer components = (IContainer) null;
    private ListView listView1;
    private string loginDate = "31.12.2022";
    private string loginName = "None";

    public Form1()
    {
      this.InitializeComponent();
      this.listView1.AllowDrop = true;
      this.listView1.FullRowSelect = true;
      this.listView1.View = View.Details;
      this.listView1.Columns.Add("File", 250, HorizontalAlignment.Left);
      this.listView1.Columns.Add("Type", 100, HorizontalAlignment.Left);
      this.listView1.Columns.Add("Size", 80, HorizontalAlignment.Left);
      this.listView1.Columns.Add("MipMaps", 80, HorizontalAlignment.Left);
      this.listView1.Columns.Add("Normal Map", -2, HorizontalAlignment.Left);
      this.listView1.DragEnter += new DragEventHandler(this.listView1_DragEnter);
      this.listView1.DragDrop += new DragEventHandler(this.listView1_DragDrop);
      this.FormClosed += new FormClosedEventHandler(this.Form1_FormClosed);
    }

    private void AddFilesToList(string[] files)
    {
      for (int index1 = 0; index1 < files.Length; ++index1)
      {
        bool flag = false;
        for (int index2 = 0; index2 < this.listView1.Items.Count; ++index2)
        {
          if (this.listView1.Items[index2].ToolTipText == files[index1])
            flag = true;
        }
        if (!flag)
        {
          if (Directory.Exists(files[index1]))
          {
            string[] files1 = Directory.GetFiles(files[index1], "*.dds");
            string[] files2 = Directory.GetFiles(files[index1], "*.i3i");
            this.AddFilesToList(files1);
            this.AddFilesToList(files2);
          }
          int num1;
          if (Path.GetExtension(files[index1]) == ".dds")
          {
            byte[] numArray = File.ReadAllBytes(files[index1]);
            if (numArray.Length > 128)
            {
              int num2 = (int) numArray[12] + (int) numArray[13] * 256;
              int num3 = (int) numArray[16] + (int) numArray[17] * 256;
              num1 = (int) numArray[28];
              int num4 = (int) numArray[87];
              string str1 = "No";
              string str2 = "Unknown";
              switch (num4)
              {
                case 49:
                  str2 = "DTX1";
                  break;
                case 51:
                  str2 = "DTX3";
                  break;
                case 53:
                  str2 = "DTX5";
                  break;
              }
              if (numArray[80] == (byte) 65 & numArray[88] == (byte) 32 & numArray[84] == (byte) 0 & numArray[85] == (byte) 0 & numArray[86] == (byte) 0 & numArray[87] == (byte) 0 & numArray[94] == byte.MaxValue & numArray[97] == byte.MaxValue & numArray[100] == byte.MaxValue & numArray[107] == byte.MaxValue)
                str2 = "A8B8G8R8";
              if (numArray[10] == (byte) 2 & numArray[80] == (byte) 64 & numArray[88] == (byte) 32 & numArray[84] == (byte) 0 & numArray[85] == (byte) 0 & numArray[86] == (byte) 0 & numArray[87] == (byte) 0 & numArray[94] == byte.MaxValue & numArray[97] == byte.MaxValue & numArray[100] == byte.MaxValue & numArray[107] == (byte) 0 & numArray[108] == (byte) 8 & numArray[109] == (byte) 16 & numArray[110] == (byte) 64)
                str2 = "X8R8G8B8";
              if (numArray[28] == (byte) 0 & numArray[80] == (byte) 64 & numArray[88] == (byte) 24 & numArray[84] == (byte) 0 & numArray[86] == (byte) 0 & numArray[85] == (byte) 0 & numArray[87] == (byte) 0 & numArray[94] == byte.MaxValue & numArray[97] == byte.MaxValue & numArray[100] == byte.MaxValue & numArray[107] == (byte) 0)
                str2 = "R8G8B8";
              if (num1 == 0)
                num1 = 1;
              string[] strArray = new string[4]
              {
                "_Norm",
                "_norm",
                "_Normal",
                "_normal"
              };
              foreach (string str3 in strArray)
              {
                if (Path.GetFileName(files[index1]).Contains(str3))
                  str1 = "Yes";
              }
              this.listView1.Items.Add(new ListViewItem(Path.GetFileName(files[index1]))
              {
                SubItems = {
                  str2,
                  num2.ToString() + " x " + num3.ToString(),
                  num1.ToString(),
                  str1
                },
                ToolTipText = files[index1]
              });
              this.button6.Focus();
              this.button6.Enabled = true;
            }
          }
          if (Path.GetExtension(files[index1]) == ".i3i")
          {
            byte[] numArray = File.ReadAllBytes(files[index1]);
            if (numArray.Length > 60)
            {
              int num5 = (int) numArray[8] + (int) numArray[9] * 256;
              int num6 = (int) numArray[6] + (int) numArray[7] * 256;
              num1 = (int) numArray[24];
              string str4 = "No";
              string str5 = "Unknown";
              if (numArray[10] == (byte) 128 & numArray[13] == (byte) 128)
                str5 = "DTX1";
              if (numArray[10] == (byte) 129 & numArray[13] == (byte) 160)
                str5 = "DTX1";
              if (numArray[10] == (byte) 2 & numArray[13] == (byte) 160)
                str5 = "DTX3";
              if (numArray[10] == (byte) 4 & numArray[13] == (byte) 160)
                str5 = "DTX5";
              if (numArray[10] == (byte) 2 & numArray[11] == (byte) 4 & numArray[13] == (byte) 0)
                str5 = "X8R8G8B8";
              if (numArray[10] == (byte) 6 & numArray[13] == (byte) 32)
                str5 = "A8R8G8B8";
              if (numArray[10] == (byte) 2 & numArray[11] == (byte) 3 & numArray[13] == (byte) 0)
                str5 = "R8G8B8";
              if (numArray[19] == (byte) 16)
                str4 = "Yes";
              this.listView1.Items.Add(new ListViewItem(Path.GetFileName(files[index1]))
              {
                SubItems = {
                  str5,
                  num5.ToString() + " x " + num6.ToString(),
                  num1.ToString(),
                  str4
                },
                ToolTipText = files[index1]
              });
              this.button1.Focus();
              this.button1.Enabled = true;
            }
          }
        }
      }
    }

    private static byte[] AppendTwoByteArrays(byte[] arrayA, byte[] arrayB)
    {
      byte[] dst = new byte[arrayA.Length + arrayB.Length];
      Buffer.BlockCopy((Array) arrayA, 0, (Array) dst, 0, arrayA.Length);
      Buffer.BlockCopy((Array) arrayB, 0, (Array) dst, arrayA.Length, arrayB.Length);
      return dst;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.DeleteUnexistedFiles();
      int num1 = 0;
      for (int index = 0; index < this.listView1.Items.Count; ++index)
      {
        if (Path.GetExtension(this.listView1.Items[index].ToolTipText) == ".i3i")
          ++num1;
      }
      if (num1 <= 0)
        return;
      for (int index1 = 0; index1 < this.listView1.Items.Count; ++index1)
      {
        string str = Path.GetDirectoryName(this.listView1.Items[index1].ToolTipText) + "\\" + Path.GetFileNameWithoutExtension(this.listView1.Items[index1].ToolTipText);
        int num2 = 60;
        if (File.Exists(this.listView1.Items[index1].ToolTipText) && Path.GetExtension(this.listView1.Items[index1].ToolTipText) == ".i3i")
        {
          byte[] numArray1 = File.ReadAllBytes(str + ".i3i");
          int int32 = Convert.ToInt32(numArray1[26].ToString("X2"), 16);
          int length = (int) new FileInfo(str + ".i3i").Length - (num2 + int32);
          byte[] numArray2 = new byte[25];
          byte[] arrayB = new byte[length];
          for (int index2 = 0; index2 < 25; ++index2)
            numArray2[index2] = numArray1[index2];
          for (int index3 = num2 + int32; index3 < length; ++index3)
            arrayB[index3 - (num2 + int32)] = numArray1[index3];
          byte[] arrayA = new byte[128]
          {
            (byte) 68,
            (byte) 68,
            (byte) 83,
            (byte) 32,
            (byte) 124,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 7,
            (byte) 16,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 2,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 2,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 32,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 4,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 68,
            (byte) 88,
            (byte) 84,
            (byte) 49,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 16,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0
          };
          byte[] numArray3 = new byte[0];
          int num3 = (int) numArray2[8] + (int) numArray2[9] * 256;
          int num4 = (int) numArray2[6] + (int) numArray2[7] * 256;
          int num5 = (int) numArray2[24];
          int num6 = (int) numArray2[10];
          arrayA[16] = numArray2[6];
          arrayA[12] = numArray2[8];
          arrayA[17] = numArray2[7];
          arrayA[13] = numArray2[9];
          arrayA[28] = numArray2[24];
          if (this.listView1.Items[index1].SubItems[1].Text == "DTX1")
            arrayA[87] = (byte) 49;
          if (this.listView1.Items[index1].SubItems[1].Text == "DTX1")
            arrayA[87] = (byte) 49;
          if (this.listView1.Items[index1].SubItems[1].Text == "DTX3")
            arrayA[87] = (byte) 51;
          if (this.listView1.Items[index1].SubItems[1].Text == "DTX5")
            arrayA[87] = (byte) 53;
          if (this.listView1.Items[index1].SubItems[1].Text == "X8R8G8B8")
          {
            arrayA[10] = (byte) 2;
            arrayA[80] = (byte) 64;
            arrayA[88] = (byte) 32;
            arrayA[84] = (byte) 0;
            arrayA[85] = (byte) 0;
            arrayA[86] = (byte) 0;
            arrayA[87] = (byte) 0;
            arrayA[94] = byte.MaxValue;
            arrayA[97] = byte.MaxValue;
            arrayA[100] = byte.MaxValue;
            arrayA[107] = (byte) 0;
            arrayA[108] = (byte) 8;
            arrayA[109] = (byte) 16;
            arrayA[110] = (byte) 64;
          }
          if (this.listView1.Items[index1].SubItems[1].Text == "A8R8G8B8")
          {
            arrayA[28] = (byte) 0;
            arrayA[80] = (byte) 65;
            arrayA[88] = (byte) 32;
            arrayA[84] = (byte) 0;
            arrayA[86] = (byte) 0;
            arrayA[85] = (byte) 0;
            arrayA[87] = (byte) 0;
            arrayA[94] = byte.MaxValue;
            arrayA[97] = byte.MaxValue;
            arrayA[100] = byte.MaxValue;
            arrayA[107] = byte.MaxValue;
            arrayA[108] = (byte) 2;
          }
          if (this.listView1.Items[index1].SubItems[1].Text == "R8G8B8")
          {
            arrayA[28] = (byte) 0;
            arrayA[80] = (byte) 64;
            arrayA[88] = (byte) 24;
            arrayA[84] = (byte) 0;
            arrayA[86] = (byte) 0;
            arrayA[85] = (byte) 0;
            arrayA[87] = (byte) 0;
            arrayA[94] = byte.MaxValue;
            arrayA[97] = byte.MaxValue;
            arrayA[100] = byte.MaxValue;
            arrayA[107] = (byte) 0;
          }
          byte[] bytes = Form1.AppendTwoByteArrays(arrayA, arrayB);
          if (this.listView1.Items[index1].SubItems[1].Text != "Unknown")
          {
            if (File.Exists(str + ".dds"))
              File.Delete(str + ".dds");
            using (File.Create(str + ".dds"))
              ;
            File.WriteAllBytes(str + ".dds", bytes);
          }
          else
            --num1;
        }
      }
      this.button1.Enabled = false;
      this.button6.Enabled = false;
      this.listView1.Items.Clear();
      if (num1 > 0)
      {
        SystemSounds.Asterisk.Play();
        int num7 = (int) MessageBox.Show(num1.ToString() + " files successfully converted!", "Done!");
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.button1.Enabled = false;
      this.button6.Enabled = false;
      this.listView1.Items.Clear();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      try
      {
        Process.Start("https://www.facebook.com/ahmadjaeee");
      }
      catch
      {
      }
    }

    private void button4_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
        return;
      string[] files1 = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.dds");
      string[] files2 = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.i3i");
      this.AddFilesToList(files1);
      this.AddFilesToList(files2);
    }

    private void button5_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("Restored by AMDex");
    }

    private void button6_Click(object sender, EventArgs e)
    {
      this.DeleteUnexistedFiles();
      int num1 = 0;
      for (int index = 0; index < this.listView1.Items.Count; ++index)
      {
        if (Path.GetExtension(this.listView1.Items[index].ToolTipText) == ".dds")
          ++num1;
      }
      if (num1 <= 0)
        return;
      for (int index1 = 0; index1 < this.listView1.Items.Count; ++index1)
      {
        string directoryName = Path.GetDirectoryName(this.listView1.Items[index1].ToolTipText);
        string withoutExtension = Path.GetFileNameWithoutExtension(this.listView1.Items[index1].ToolTipText);
        string str1 = directoryName + "\\" + withoutExtension;
        int num2 = 128;
        if (File.Exists(this.listView1.Items[index1].ToolTipText) && Path.GetExtension(this.listView1.Items[index1].ToolTipText) == ".dds")
        {
          byte[] numArray1 = File.ReadAllBytes(str1 + ".dds");
          int length1 = (int) new FileInfo(str1 + ".dds").Length - num2;
          byte[] numArray2 = new byte[128];
          byte[] sourceArray = new byte[length1];
          for (int index2 = 0; index2 < 128; ++index2)
            numArray2[index2] = numArray1[index2];
          for (int index3 = num2; index3 < length1 + 128; ++index3)
            sourceArray[index3 - 128] = numArray1[index3];
          byte[] arrayA1 = new byte[60]
          {
            (byte) 73,
            (byte) 51,
            (byte) 73,
            (byte) 66,
            (byte) 5,
            (byte) 0,
            (byte) 0,
            (byte) 2,
            (byte) 0,
            (byte) 2,
            (byte) 128,
            (byte) 6,
            (byte) 0,
            (byte) 128,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 4,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 0
          };
          byte[] bytes1 = Encoding.ASCII.GetBytes("");
          byte[] arrayA2 = Form1.AppendTwoByteArrays(arrayA1, bytes1);
          arrayA2[26] = (byte) bytes1.Length;
          byte[] numArray3 = new byte[0];
          int num3 = (int) numArray2[12] + (int) numArray2[13] * 256;
          int num4 = (int) numArray2[16] + (int) numArray2[17] * 256;
          int num5 = (int) numArray2[28];
          int num6 = (int) numArray2[87];
          if (num5 == 0)
            numArray2[28] = (byte) 1;
          arrayA2[6] = numArray2[16];
          arrayA2[7] = numArray2[17];
          arrayA2[8] = numArray2[12];
          arrayA2[9] = numArray2[13];
          arrayA2[24] = numArray2[28];
          if (this.listView1.Items[index1].SubItems[1].Text == "DTX1")
          {
            arrayA2[10] = (byte) 128;
            arrayA2[13] = (byte) 128;
          }
          if (this.listView1.Items[index1].SubItems[1].Text == "DTX3")
          {
            arrayA2[10] = (byte) 2;
            arrayA2[13] = (byte) 160;
          }
          if (this.listView1.Items[index1].SubItems[1].Text == "DTX5")
          {
            arrayA2[10] = (byte) 4;
            arrayA2[13] = (byte) 160;
          }
          if (this.listView1.Items[index1].SubItems[1].Text == "A8B8G8R8")
          {
            arrayA2[10] = (byte) 6;
            arrayA2[11] = (byte) 4;
            arrayA2[13] = (byte) 32;
          }
          if (this.listView1.Items[index1].SubItems[1].Text == "X8R8G8B8")
          {
            arrayA2[10] = (byte) 2;
            arrayA2[11] = (byte) 4;
            arrayA2[13] = (byte) 0;
          }
          if (this.listView1.Items[index1].SubItems[1].Text == "R8G8B8")
          {
            arrayA2[10] = (byte) 2;
            arrayA2[11] = (byte) 3;
            arrayA2[13] = (byte) 0;
          }
          string[] strArray = new string[4]
          {
            "_Norm",
            "_norm",
            "_Normal",
            "_normal"
          };
          foreach (string str2 in strArray)
          {
            if (Path.GetFileName(withoutExtension).Contains(str2))
              arrayA2[19] = (byte) 16;
          }
          byte[] numArray4 = sourceArray;
          if (num5 > 4 && this.listView1.Items[index1].SubItems[1].Text != "R8G8B8")
          {
            int length2 = 0;
            for (int index4 = 0; index4 < 4; ++index4)
            {
              if (this.listView1.Items[index1].SubItems[1].Text == "DTX1")
                length2 += num3 * num4 / 2;
              if (this.listView1.Items[index1].SubItems[1].Text == "DTX3" | this.listView1.Items[index1].SubItems[1].Text == "DTX5")
                length2 += num3 * num4;
              if (this.listView1.Items[index1].SubItems[1].Text == "A8B8G8R8" | this.listView1.Items[index1].SubItems[1].Text == "X8R8G8B8")
                length2 += num3 * num4 * 4;
              num3 /= 2;
              num4 /= 2;
            }
            numArray4 = new byte[length2];
            Array.Copy((Array) sourceArray, 0, (Array) numArray4, 0, length2);
            arrayA2[24] = (byte) 4;
          }
          byte[] bytes2 = Form1.AppendTwoByteArrays(arrayA2, numArray4);
          if (this.listView1.Items[index1].SubItems[1].Text != "Unknown")
          {
            if (File.Exists(str1 + ".i3i"))
              File.Delete(str1 + ".i3i");
            using (File.Create(str1 + ".i3i"))
              ;
            File.WriteAllBytes(str1 + ".i3i", bytes2);
          }
          else
            --num1;
        }
      }
      this.button1.Enabled = false;
      this.button6.Enabled = false;
      this.listView1.Items.Clear();
      if (num1 > 0)
      {
        SystemSounds.Asterisk.Play();
        int num7 = (int) MessageBox.Show(num1.ToString() + " files successfully converted!", "Done!");
      }
    }

    private void DeleteUnexistedFiles()
    {
      for (int index = 0; index < this.listView1.Items.Count; ++index)
      {
        if (!File.Exists(this.listView1.Items[index].ToolTipText))
        {
          this.listView1.Items.RemoveAt(index);
          index = 0;
        }
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

    private void Form1_Load(object sender, EventArgs e)
    {
      this.button1.Enabled = false;
      this.button6.Enabled = false;
      this.button9.Focus();
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.button1 = new Button();
      this.button3 = new Button();
      this.button9 = new Button();
      this.button4 = new Button();
      this.button5 = new Button();
      this.button6 = new Button();
      this.listView1 = new ListView();
      this.SuspendLayout();
      this.button1.BackColor = SystemColors.Control;
      this.button1.Location = new Point(7, 291);
      this.button1.Name = "button1";
      this.button1.Size = new Size(97, 30);
      this.button1.TabIndex = 1;
      this.button1.Text = "Convert To DDS";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button3.Location = new Point(211, 291);
      this.button3.Name = "button3";
      this.button3.Size = new Size(97, 30);
      this.button3.TabIndex = 3;
      this.button3.Text = "Clear All";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.button2_Click);
      this.button9.Location = new Point(520, 291);
      this.button9.Name = "button9";
      this.button9.Size = new Size(97, 30);
      this.button9.TabIndex = 9;
      this.button9.Text = "Homepage";
      this.button9.UseVisualStyleBackColor = true;
      this.button9.Click += new EventHandler(this.button3_Click);
      this.button4.Location = new Point(314, 291);
      this.button4.Name = "button4";
      this.button4.Size = new Size(97, 30);
      this.button4.TabIndex = 4;
      this.button4.Text = "Open Directory";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new EventHandler(this.button4_Click);
      this.button5.Location = new Point(417, 291);
      this.button5.Name = "button5";
      this.button5.Size = new Size(97, 30);
      this.button5.TabIndex = 5;
      this.button5.Text = "About";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new EventHandler(this.button5_Click);
      this.button6.Location = new Point(108, 291);
      this.button6.Name = "button6";
      this.button6.Size = new Size(97, 30);
      this.button6.TabIndex = 2;
      this.button6.Text = "Convert To I3I";
      this.button6.UseVisualStyleBackColor = true;
      this.button6.Click += new EventHandler(this.button6_Click);
      this.listView1.Location = new Point(7, 6);
      this.listView1.MultiSelect = false;
      this.listView1.Name = "listView1";
      this.listView1.ShowItemToolTips = true;
      this.listView1.Size = new Size(610, 280);
      this.listView1.TabIndex = 13;
      this.listView1.TabStop = false;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = View.Details;
      this.AllowDrop = true;
      this.ClientSize = new Size(624, 326);
      this.Controls.Add((Control) this.listView1);
      this.Controls.Add((Control) this.button6);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.button9);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MaximumSize = new Size(640, 365);
      this.MinimumSize = new Size(640, 365);
      this.Name = nameof (Form1);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Restored By AMDex";
      this.Load += new EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
    }

    private void listView1_DragDrop(object sender, DragEventArgs e) => this.AddFilesToList((string[]) e.Data.GetData(DataFormats.FileDrop));

    private void listView1_DragEnter(object sender, DragEventArgs e)
    {
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
        return;
      e.Effect = DragDropEffects.All;
    }
  }
}
