using UnityEngine;
using System.Collections;

namespace dllsubscript
{
	public class Subscript
	{
		public string ToSubscript(int someInt)
		{
			switch (someInt)
			{
				case 0:
					return "\x2080";
				case 1:
					return "\x2081";
				case 2:
					return "\x2082";
				case 3:
					return "\x2083";
				case 4:
					return "\x2084";
				case 5:
					return "\x2085";
				case 6:
					return "\x2086";
				case 7:
					return "\x2087";
				case 8:
					return "\x2088";
				case 9:
					return "\x2089";
				default:
					return "";
						
			}
		}
	}
}