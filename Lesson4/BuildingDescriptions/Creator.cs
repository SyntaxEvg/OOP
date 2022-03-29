using Lesson4.BuildingDescriptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
	internal class Creator : BuildingDescription
	{
		public static Hashtable Builds = new Hashtable();

		private Creator() { }

		public static BuildingDescription CreateBuild()
		{
			BuildingDescription build = new Creator();
			Builds.Add(build.UniqueBuildingNumber, build);
			return build;
		}

		public static void Delete(int id)
		{
			if (Builds.ContainsKey(id))
				Builds.Remove(id);
		}
	}
}
