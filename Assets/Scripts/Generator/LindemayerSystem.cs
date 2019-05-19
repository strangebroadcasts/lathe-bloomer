using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace TreeBuilder.Generator {
	/// <summary>
	/// LindemayerSystem implements a Lindemayer system.
	/// </summary>
	public class LindemayerSystem : ScriptableObject {
		public string Current = "X";
		public Dictionary<char, string> Rules = new Dictionary<char, string> {
			['X'] = "F+[[X]-X]-F[-FX]+X",
			['F'] = "FF"
		};
		
		
		public LindemayerSystem Iterate() {
			var next = new StringBuilder();
			foreach (var token in Current)
			{
				string result;
				if (Rules.TryGetValue(token, out result)) {
					next.Append(result);
				} else {
					next.Append(token);
				}
			}
			var ret = ScriptableObject.CreateInstance<LindemayerSystem>();
			ret.Current = next.ToString();
			return ret;
		}		
	}
}