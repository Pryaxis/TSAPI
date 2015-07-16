using System;
using System.IO;
using Terraria;

namespace Terraria.IO
{
	public class FileMetadata
	{
		public const ulong MAGIC_NUMBER = 27981915666277746L;

		public const int SIZE = 20;

		public FileType Type;

		public uint Revision;

		private FileMetadata()
		{
		}

		public static FileMetadata FromCurrentSettings(FileType type)
		{
			FileMetadata fileMetadatum = new FileMetadata()
			{
				Type = type,
				Revision = 0,
			};
			return fileMetadatum;
		}

		public void IncrementAndWrite(BinaryWriter writer)
		{
			FileMetadata revision = this;
			revision.Revision = revision.Revision + 1;
			this.Write(writer);
		}

		public static FileMetadata Read(BinaryReader reader, FileType expectedType)
		{
			FileMetadata fileMetadatum = new FileMetadata();
			fileMetadatum.Read(reader);
			if (fileMetadatum.Type != expectedType)
			{
				string[] name = new string[] { "Expected type \"", Enum.GetName(typeof(FileType), expectedType), "\" but found \"", Enum.GetName(typeof(FileType), fileMetadatum.Type), "\"." };
				throw new Exception("FileFormatException: " + string.Concat(name));
			}
			return fileMetadatum;
		}

		private void Read(BinaryReader reader)
		{
			ulong num = reader.ReadUInt64();
			if ((num & 72057594037927935L) != MAGIC_NUMBER)
			{
				throw new Exception("FileFormatException: Expected Re-Logic file format.");
			}
			byte num1 = (byte)(num >> 56 & (long)255);
			FileType fileType = FileType.None;
			FileType[] values = (FileType[])Enum.GetValues(typeof(FileType));
			int num2 = 0;
			while (num2 < (int)values.Length)
			{
				if ((byte)values[num2] != num1)
				{
					num2++;
				}
				else
				{
					fileType = values[num2];
					break;
				}
			}
			if (fileType == FileType.None)
			{
				throw new Exception("FileFormatException: Found invalid file type.");
			}
			this.Type = fileType;
			this.Revision = reader.ReadUInt32();
			ulong num3 = reader.ReadUInt64();
		}

		public void Write(BinaryWriter writer)
		{
			writer.Write(MAGIC_NUMBER | (ulong)this.Type << 56);
			writer.Write(this.Revision);
		}
	}
}