using System;

namespace BulkMaterialsForm.SDK.DH;

public class DownloadMode
{
	public int number = 0;

	public int index = 0;

	public bool isload = false;

	public string sVideoFileName = "";

	public DateTime start { get; set; }

	public DateTime end { get; set; }

	public int Id { get; set; }

	public int m_DownloadID { get; set; }
}
