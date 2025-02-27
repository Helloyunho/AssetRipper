﻿using AssetRipper.Core.Interfaces;
using System.Diagnostics;

namespace AssetRipper.Core.Project
{
	public static class ExportIdHandler
	{
		public static long GetMainExportID(IUnityObjectBase asset)
		{
			return GetMainExportID((uint)asset.ClassID, 0);
		}

		public static long GetMainExportID(uint classID)
		{
			return GetMainExportID(classID, 0);
		}

		public static long GetMainExportID(IUnityObjectBase asset, uint value)
		{
			return GetMainExportID((uint)asset.ClassID, value);
		}

		public static long GetMainExportID(uint classID, uint value)
		{
			if (classID > 100100)
			{
				if (value != 0)
				{
					throw new ArgumentException("Unique asset type with non unique modifier", nameof(value));
				}
				return classID;
			}

			Debug.Assert(value < 100000, $"Value {value} for main export ID must have no more than 5 digits");
			return (classID * 100000) + value;
		}
	}
}
