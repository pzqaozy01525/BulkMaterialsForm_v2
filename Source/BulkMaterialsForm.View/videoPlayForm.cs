// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.View
// Type: BulkMaterialsForm.View.videoPlayForm

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using BulkMaterialsForm.Help;
using Vlc.DotNet.Forms;

namespace BulkMaterialsForm.View;

public class videoPlayForm : Form
{
	public string path;

	private VlcControl vlcControl1 = new VlcControl();

	private FileStream fileStream;

	private IContainer components;

	public videoPlayForm()
	{
		InitializeComponent();
		vlcControl1.BeginInit();
		vlcControl1.VlcLibDirectoryNeeded += OnVlcControlNeedsLibDirectory;
		vlcControl1.EndInit();
		base.Load += VideoPlayForm_Load;
		base.FormClosed += VideoPlayForm_FormClosed;
	}

	private void VideoPlayForm_FormClosed(object sender, FormClosedEventArgs e)
	{
		if (fileStream != null)
		{
			fileStream.Dispose();
		}
		if (vlcControl1 != null)
		{
			vlcControl1.Dispose();
		}
	}

	private void OnVlcControlNeedsLibDirectory(object sender, VlcLibDirectoryNeededEventArgs e)
	{
		string directoryName = new FileInfo(Assembly.GetEntryAssembly().Location).DirectoryName;
		e.VlcLibDirectory = new DirectoryInfo(Path.Combine(directoryName, "libvlc", (IntPtr.Size == 4) ? "win-x86" : "Vlcx64"));
		LogSave.HKLog(Path.Combine(directoryName, "libvlc", (IntPtr.Size == 4) ? "win-x86" : "Vlcx64"));
	}

	private void VideoPlayForm_Load(object sender, EventArgs e)
	{
		try
		{
			base.Controls.Add(vlcControl1);
			vlcControl1.Dock = DockStyle.Fill;
			fileStream = File.Open(path, FileMode.Open);
			vlcControl1.SetMedia(fileStream);
			vlcControl1.Play();
		}
		catch (Exception ex)
		{
			MessageBox.Show("播放视频失败：" + ex.Message, "播放错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		base.SuspendLayout();
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(800, 450);
		base.Name = "videoPlayForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "视频播放";
		base.ResumeLayout(false);
	}
}
