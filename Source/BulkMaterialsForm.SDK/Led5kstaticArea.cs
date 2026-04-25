// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SDK
// Type: BulkMaterialsForm.SDK.Led5kstaticArea

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace BulkMaterialsForm.SDK;

public class Led5kstaticArea
{
	public Led5kSDK.bx_5k_area_header header;

	public string text;

	public byte[] AreaToByteArray()
	{
		int num = Marshal.SizeOf(default(Led5kSDK.bx_5k_area_header));
		text = text.Replace("￦￦F", "\\F");
		List<byte[]> list = new List<byte[]>();
		int num2 = 0;
		string[] array = text.Split('\\');
		int num3 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (i > 0 && array[i].Length > 1)
			{
				if (array[i].Substring(0, 2).Equals("FK"))
				{
					num3 = 1;
					if (array[i].Length > 5)
					{
						byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(array[i].Substring(0, 5));
						byte[] array2 = new byte[bytes.Length + 1];
						array2[0] = 92;
						for (int j = 0; j < bytes.Length; j++)
						{
							array2[j + 1] = bytes[j];
						}
						list.Add(array2);
						num2 += array2.Length;
						string s = array[i].Remove(0, 5);
						byte[] bytes2 = Encoding.Unicode.GetBytes(s);
						for (int k = 0; k < bytes2.Length / 2; k++)
						{
							byte b = bytes2[k * 2];
							bytes2[k * 2] = bytes2[k * 2 + 1];
							bytes2[k * 2 + 1] = b;
						}
						list.Add(bytes2);
						num2 += bytes2.Length;
					}
					else
					{
						byte[] bytes3 = Encoding.GetEncoding("Unicode").GetBytes(array[i]);
						byte[] array3 = new byte[bytes3.Length + 1];
						array3[0] = 92;
						for (int l = 0; l < bytes3.Length; l++)
						{
							array3[l + 1] = bytes3[l];
						}
						list.Add(array3);
						num2 += array3.Length;
					}
				}
				else if (array[i].Substring(0, 2).Equals("FE") || array[i].Substring(0, 2).Equals("FO") || array[i].Substring(0, 2).Equals("WF") || array[i].Substring(0, 2).Equals("WC"))
				{
					num3 = 0;
					byte[] bytes4 = Encoding.GetEncoding("GBK").GetBytes(array[i]);
					byte[] array4 = new byte[bytes4.Length + 1];
					array4[0] = 92;
					for (int m = 0; m < bytes4.Length; m++)
					{
						array4[m + 1] = bytes4[m];
					}
					list.Add(array4);
					num2 += array4.Length;
				}
				else if (array[i].Substring(0, 1).Equals("C") || array[i].Substring(0, 1).Equals("D") || array[i].Substring(0, 1).Equals("B") || array[i].Substring(0, 1).Equals("T"))
				{
					if (num3 == 1)
					{
						byte[] bytes5 = Encoding.GetEncoding("GBK").GetBytes(array[i].Substring(0, 2));
						byte[] array5 = new byte[bytes5.Length + 1];
						array5[0] = 92;
						for (int n = 0; n < bytes5.Length; n++)
						{
							array5[n + 1] = bytes5[n];
						}
						list.Add(array5);
						num2 += array5.Length;
						string s2 = array[i].Remove(0, 2);
						byte[] bytes6 = Encoding.Unicode.GetBytes(s2);
						for (int num4 = 0; num4 < bytes6.Length / 2; num4++)
						{
							byte b2 = bytes6[num4 * 2];
							bytes6[num4 * 2] = bytes6[num4 * 2 + 1];
							bytes6[num4 * 2 + 1] = b2;
						}
						list.Add(bytes6);
						num2 += bytes6.Length;
					}
					else
					{
						byte[] bytes7 = Encoding.GetEncoding("GBK").GetBytes(array[i]);
						byte[] array6 = new byte[bytes7.Length + 1];
						array6[0] = 92;
						for (int num5 = 0; num5 < bytes7.Length; num5++)
						{
							array6[num5 + 1] = bytes7[num5];
						}
						list.Add(array6);
						num2 += array6.Length;
					}
				}
				else if (array[i].Substring(0, 1).Equals("n"))
				{
					if (num3 == 1)
					{
						byte[] bytes8 = Encoding.GetEncoding("GBK").GetBytes(array[i].Substring(0, 1));
						byte[] array7 = new byte[bytes8.Length + 1];
						array7[0] = 92;
						for (int num6 = 0; num6 < bytes8.Length; num6++)
						{
							array7[num6 + 1] = bytes8[num6];
						}
						list.Add(array7);
						num2 += array7.Length;
						string s3 = array[i].Remove(0, 1);
						byte[] bytes9 = Encoding.Unicode.GetBytes(s3);
						for (int num7 = 0; num7 < bytes9.Length / 2; num7++)
						{
							byte b3 = bytes9[num7 * 2];
							bytes9[num7 * 2] = bytes9[num7 * 2 + 1];
							bytes9[num7 * 2 + 1] = b3;
						}
						list.Add(bytes9);
						num2 += bytes9.Length;
					}
					else
					{
						byte[] bytes10 = Encoding.GetEncoding("GBK").GetBytes(array[i]);
						byte[] array8 = new byte[bytes10.Length + 1];
						array8[0] = 92;
						for (int num8 = 0; num8 < bytes10.Length; num8++)
						{
							array8[num8 + 1] = bytes10[num8];
						}
						list.Add(array8);
						num2 += array8.Length;
					}
				}
				else if (num3 == 1)
				{
					byte[] bytes11 = Encoding.GetEncoding("GBK").GetBytes(array[i]);
					byte[] array9 = new byte[bytes11.Length + 1];
					array9[0] = 92;
					for (int num9 = 0; num9 < bytes11.Length; num9++)
					{
						array9[num9 + 1] = bytes11[num9];
					}
					list.Add(array9);
					num2 += array9.Length;
				}
				else
				{
					byte[] bytes12 = Encoding.GetEncoding("GBK").GetBytes(array[i]);
					byte[] array10 = new byte[bytes12.Length + 1];
					array10[0] = 92;
					for (int num10 = 0; num10 < bytes12.Length; num10++)
					{
						array10[num10 + 1] = bytes12[num10];
					}
					list.Add(array10);
					num2 += array10.Length;
				}
			}
			else if (i > 0)
			{
				byte[] bytes13 = Encoding.GetEncoding("GBK").GetBytes(array[i]);
				byte[] array11 = new byte[bytes13.Length + 1];
				array11[0] = 92;
				for (int num11 = 0; num11 < bytes13.Length; num11++)
				{
					array11[num11 + 1] = bytes13[num11];
				}
				list.Add(array11);
				num2 += array11.Length;
			}
			else
			{
				byte[] bytes14 = Encoding.GetEncoding("GBK").GetBytes(array[i]);
				list.Add(bytes14);
				num2 += bytes14.Length;
			}
		}
		byte[] array12 = new byte[num2];
		int num12 = 0;
		for (int num13 = 0; num13 < list.Count(); num13++)
		{
			if (num13 > 0)
			{
				for (int num14 = 0; num14 < list[num13].Length; num14++)
				{
					array12[num12 + num14] = list[num13][num14];
				}
				num12 += list[num13].Length;
			}
			else
			{
				for (int num15 = 0; num15 < list[num13].Length; num15++)
				{
					array12[num15] = list[num13][num15];
				}
				num12 += list[num13].Length;
			}
		}
		int num16 = array12.Length + num + 4;
		header.DataLen = array12.Length;
		byte[] array13 = new byte[num16];
		byte[] bytes15 = BitConverter.GetBytes(num16);
		bytes15.CopyTo(array13, 0);
		int num17 = bytes15.Length;
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		Marshal.StructureToPtr(header, intPtr, fDeleteOld: false);
		Marshal.Copy(intPtr, array13, num17, num);
		Marshal.FreeHGlobal(intPtr);
		array12.CopyTo(array13, num17 + num);
		return array13;
	}

	public int getAreaLen()
	{
		int num = Marshal.SizeOf(default(Led5kSDK.bx_5k_area_header));
		text = text.Replace("￦￦F", "\\F");
		List<byte[]> list = new List<byte[]>();
		int num2 = 0;
		string[] array = text.Split('\\');
		int num3 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (i > 0 && array[i].Length > 1)
			{
				if (array[i].Substring(0, 2).Equals("FK"))
				{
					num3 = 1;
					if (array[i].Length > 5)
					{
						byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(array[i].Substring(0, 5));
						byte[] array2 = new byte[bytes.Length + 1];
						array2[0] = 92;
						for (int j = 0; j < bytes.Length; j++)
						{
							array2[j + 1] = bytes[j];
						}
						list.Add(array2);
						num2 += array2.Length;
						string s = array[i].Remove(0, 5);
						byte[] bytes2 = Encoding.Unicode.GetBytes(s);
						for (int k = 0; k < bytes2.Length / 2; k++)
						{
							byte b = bytes2[k * 2];
							bytes2[k * 2] = bytes2[k * 2 + 1];
							bytes2[k * 2 + 1] = b;
						}
						list.Add(bytes2);
						num2 += bytes2.Length;
					}
					else
					{
						byte[] bytes3 = Encoding.GetEncoding("Unicode").GetBytes(array[i]);
						byte[] array3 = new byte[bytes3.Length + 1];
						array3[0] = 92;
						for (int l = 0; l < bytes3.Length; l++)
						{
							array3[l + 1] = bytes3[l];
						}
						list.Add(array3);
						num2 += array3.Length;
					}
				}
				else if (array[i].Substring(0, 2).Equals("FE") || array[i].Substring(0, 2).Equals("FO") || array[i].Substring(0, 2).Equals("WF") || array[i].Substring(0, 2).Equals("WC"))
				{
					num3 = 0;
					byte[] bytes4 = Encoding.GetEncoding("GBK").GetBytes(array[i]);
					byte[] array4 = new byte[bytes4.Length + 1];
					array4[0] = 92;
					for (int m = 0; m < bytes4.Length; m++)
					{
						array4[m + 1] = bytes4[m];
					}
					list.Add(array4);
					num2 += array4.Length;
				}
				else if (array[i].Substring(0, 1).Equals("C") || array[i].Substring(0, 1).Equals("D") || array[i].Substring(0, 1).Equals("B") || array[i].Substring(0, 1).Equals("T"))
				{
					if (num3 == 1)
					{
						byte[] bytes5 = Encoding.GetEncoding("GBK").GetBytes(array[i].Substring(0, 2));
						byte[] array5 = new byte[bytes5.Length + 1];
						array5[0] = 92;
						for (int n = 0; n < bytes5.Length; n++)
						{
							array5[n + 1] = bytes5[n];
						}
						list.Add(array5);
						num2 += array5.Length;
						string s2 = array[i].Remove(0, 2);
						byte[] bytes6 = Encoding.Unicode.GetBytes(s2);
						for (int num4 = 0; num4 < bytes6.Length / 2; num4++)
						{
							byte b2 = bytes6[num4 * 2];
							bytes6[num4 * 2] = bytes6[num4 * 2 + 1];
							bytes6[num4 * 2 + 1] = b2;
						}
						list.Add(bytes6);
						num2 += bytes6.Length;
					}
					else
					{
						byte[] bytes7 = Encoding.GetEncoding("GBK").GetBytes(array[i]);
						byte[] array6 = new byte[bytes7.Length + 1];
						array6[0] = 92;
						for (int num5 = 0; num5 < bytes7.Length; num5++)
						{
							array6[num5 + 1] = bytes7[num5];
						}
						list.Add(array6);
						num2 += array6.Length;
					}
				}
				else if (array[i].Substring(0, 1).Equals("n"))
				{
					if (num3 == 1)
					{
						byte[] bytes8 = Encoding.GetEncoding("GBK").GetBytes(array[i].Substring(0, 1));
						byte[] array7 = new byte[bytes8.Length + 1];
						array7[0] = 92;
						for (int num6 = 0; num6 < bytes8.Length; num6++)
						{
							array7[num6 + 1] = bytes8[num6];
						}
						list.Add(array7);
						num2 += array7.Length;
						string s3 = array[i].Remove(0, 1);
						byte[] bytes9 = Encoding.Unicode.GetBytes(s3);
						for (int num7 = 0; num7 < bytes9.Length / 2; num7++)
						{
							byte b3 = bytes9[num7 * 2];
							bytes9[num7 * 2] = bytes9[num7 * 2 + 1];
							bytes9[num7 * 2 + 1] = b3;
						}
						list.Add(bytes9);
						num2 += bytes9.Length;
					}
					else
					{
						byte[] bytes10 = Encoding.GetEncoding("GBK").GetBytes(array[i]);
						byte[] array8 = new byte[bytes10.Length + 1];
						array8[0] = 92;
						for (int num8 = 0; num8 < bytes10.Length; num8++)
						{
							array8[num8 + 1] = bytes10[num8];
						}
						list.Add(array8);
						num2 += array8.Length;
					}
				}
				else if (num3 == 1)
				{
					byte[] bytes11 = Encoding.GetEncoding("GBK").GetBytes(array[i]);
					byte[] array9 = new byte[bytes11.Length + 1];
					array9[0] = 92;
					for (int num9 = 0; num9 < bytes11.Length; num9++)
					{
						array9[num9 + 1] = bytes11[num9];
					}
					list.Add(array9);
					num2 += array9.Length;
				}
				else
				{
					byte[] bytes12 = Encoding.GetEncoding("GBK").GetBytes(array[i]);
					byte[] array10 = new byte[bytes12.Length + 1];
					array10[0] = 92;
					for (int num10 = 0; num10 < bytes12.Length; num10++)
					{
						array10[num10 + 1] = bytes12[num10];
					}
					list.Add(array10);
					num2 += array10.Length;
				}
			}
			else if (i > 0)
			{
				byte[] bytes13 = Encoding.GetEncoding("GBK").GetBytes(array[i]);
				byte[] array11 = new byte[bytes13.Length + 1];
				array11[0] = 92;
				for (int num11 = 0; num11 < bytes13.Length; num11++)
				{
					array11[num11 + 1] = bytes13[num11];
				}
				list.Add(array11);
				num2 += array11.Length;
			}
			else
			{
				byte[] bytes14 = Encoding.GetEncoding("GBK").GetBytes(array[i]);
				list.Add(bytes14);
				num2 += bytes14.Length;
			}
		}
		byte[] array12 = new byte[num2];
		int num12 = 0;
		for (int num13 = 0; num13 < list.Count(); num13++)
		{
			if (num13 > 0)
			{
				for (int num14 = 0; num14 < list[num13].Length; num14++)
				{
					array12[num12 + num14] = list[num13][num14];
				}
				num12 += list[num13].Length;
			}
			else
			{
				for (int num15 = 0; num15 < list[num13].Length; num15++)
				{
					array12[num15] = list[num13][num15];
				}
				num12 += list[num13].Length;
			}
		}
		return array12.Length + num + 4;
	}
}
