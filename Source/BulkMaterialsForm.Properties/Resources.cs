// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.Properties
// Type: BulkMaterialsForm.Properties.Resources

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;

namespace BulkMaterialsForm.Properties;

[GeneratedCode("ResourceGenerator", "1.0.0.0")]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				resourceMan = new ResourceManager("BulkMaterialsForm.Properties.Resources", typeof(Resources).Assembly);
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static Image _3dclusteredcolumn_32x32 => GetImage("_3dclusteredcolumn_32x32");

	internal static Image add_32x32 => GetImage("add_32x32");

	internal static Image apply_32x32 => GetImage("apply_32x32");

	internal static Image apply_32x321 => GetImage("apply_32x321");

	internal static Image apply_32x322 => GetImage("apply_32x322");

	internal static Image apply_32x323 => GetImage("apply_32x323");

	internal static Image apply_32x324 => GetImage("apply_32x324");

	internal static Image apply_32x325 => GetImage("apply_32x325");

	internal static Image backward_32x32 => GetImage("backward_32x32");

	internal static Image bookmark_32x32 => GetImage("bookmark_32x32");

	internal static Image cancel_32x32 => GetImage("cancel_32x32");

	internal static Image cancel_32x321 => GetImage("cancel_32x321");

	internal static Image cancel_32x322 => GetImage("cancel_32x322");

	internal static Image changechartseriestype_32x32 => GetImage("changechartseriestype_32x32");

	internal static Image chartyaxissettings_32x32 => GetImage("chartyaxissettings_32x32");

	internal static Image chartyaxissettings_32x321 => GetImage("chartyaxissettings_32x321");

	internal static Image close_32x32 => GetImage("close_32x32");

	internal static Image close_32x321 => GetImage("close_32x321");

	internal static Image convert_32x32 => GetImage("convert_32x32");

	internal static Image convert_32x321 => GetImage("convert_32x321");

	internal static Image convert_32x322 => GetImage("convert_32x322");

	internal static Image forward_32x32 => GetImage("forward_32x32");

	internal static Image greenyellow_32x32 => GetImage("greenyellow_32x32");

	internal static Image ide_32x32 => GetImage("ide_32x32");

	internal static Image iconsetredtoblack4_32x32 => GetImage("iconsetredtoblack4_32x32");

	internal static Image insert_32x32 => GetImage("insert_32x32");

	internal static Image label_32x32 => GetImage("label_32x32");

	internal static Image left_32x32 => GetImage("left_32x32");

	internal static Image managedatasource_32x32 => GetImage("managedatasource_32x32");

	internal static Image newcontact_32x32 => GetImage("newcontact_32x32");

	internal static Image nextcomment_32x32 => GetImage("nextcomment_32x32");

	internal static Image open_32x32 => GetImage("open_32x32");

	internal static Image open2_32x32 => GetImage("open2_32x32");

	internal static Image open2_32x321 => GetImage("open2_32x321");

	internal static Image open2_32x322 => GetImage("open2_32x322");

	internal static Image openhyperlink_32x32 => GetImage("openhyperlink_32x32");

	internal static Image paste_32x32 => GetImage("paste_32x32");

	internal static Image properties_32x32 => GetImage("properties_32x32");

	internal static Image reading_32x32 => GetImage("reading_32x32");

	internal static Image reading_32x321 => GetImage("reading_32x321");

	internal static Image record_32x32 => GetImage("record_32x32");

	internal static Image remove_32x32 => GetImage("remove_32x32");

	internal static Image remove_32x321 => GetImage("remove_32x321");

	internal static Image reverssort_32x32 => GetImage("reverssort_32x32");

	internal static Image sendbackward_32x32 => GetImage("sendbackward_32x32");

	internal static Image show_32x32 => GetImage("show_32x32");

	internal static Image show_32x321 => GetImage("show_32x321");

	internal static Image switchrowcolumn_32x32 => GetImage("switchrowcolumn_32x32");

	internal static Image tableofcontent_32x32 => GetImage("tableofcontent_32x32");

	internal static Image transit_32x32 => GetImage("transit_32x32");

	internal static Image verticalgridlinesnone_32x32 => GetImage("verticalgridlinesnone_32x32");

	internal static Image zoom_32x32 => GetImage("zoom_32x32");

	internal static Image zoom_32x321 => GetImage("zoom_32x321");

	internal Resources()
	{
	}

	internal static Image GetImage(string name)
	{
		try
		{
			object obj = ResourceManager.GetObject(name, resourceCulture);
			if (obj is Image result)
			{
				return result;
			}
			if (obj is byte[] buffer)
			{
				using MemoryStream stream = new MemoryStream(buffer);
				return Image.FromStream(stream);
			}
			return null;
		}
		catch (MissingManifestResourceException)
		{
			return null;
		}
		catch (Exception)
		{
			return null;
		}
	}
}
