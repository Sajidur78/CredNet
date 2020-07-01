using System;

namespace CredNet.Interop
{
	[Flags]
	public enum FieldOptions
	{
		None = 0,
		PasswordReveal = 1,
		Email = 2,
		TouchKeyboardAutoInvoke = 4,
		NumbersOnly = 8,
		ShowKeyboard = 16
	}
}
