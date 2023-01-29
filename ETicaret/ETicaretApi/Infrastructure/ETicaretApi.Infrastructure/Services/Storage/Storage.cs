using ETicaretApi.Infrastructure.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Infrastructure.Services.Storage
{
	public class Storage
	{
		protected delegate bool HasFile(string pathOrContainerName,string fileName);
		protected string FileRename(string pathOrContainerName,string fileName,HasFile hasFileMethod)
		{
			string extencion = Path.GetExtension(fileName);

			string nameWithoutExtencion = NameOperation.CharacterOperation(Path.GetFileNameWithoutExtension(fileName));
			string name = $"{nameWithoutExtencion}{extencion}";
			int count = 1;
			while (hasFileMethod(pathOrContainerName,name))
			{
				name = $"{nameWithoutExtencion}({count}){extencion}";
				count++;
			}
			return name;
		}
	}
}
