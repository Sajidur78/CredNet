﻿using System;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[ComConversionLoss]
	
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct tagCALPWSTR
	{
		public uint cElems;

		[ComConversionLoss]
		public IntPtr pElems;
	}
}