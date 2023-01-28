using ETicaretApi.Application.Services;
using ETicaretApi.Infrastructure.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Infrastructure.Services
{
	public class FileService : IFileService
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		public FileService(IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment= webHostEnvironment; 
		}
		public async Task<bool> CopyFileAsync(string path, IFormFile file)
		{
			try
			{
				await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
				await file.CopyToAsync(fileStream);
				await fileStream.FlushAsync();
				return true;
			}
			catch (Exception e)
			{
				//todo log
				throw;
			}
		}

		public string FileRenameAsync(string path,string fileName)
		{
			string extencion = Path.GetExtension(fileName);
		
			string nameWithoutExtencion=NameOperation.CharacterOperation(Path.GetFileNameWithoutExtension(fileName));
			string name = $"{nameWithoutExtencion}{extencion}";
			int count = 1;
			while (File.Exists($"{path}\\{name}"))
			{
				name = $"{nameWithoutExtencion}({count}){extencion}";
				count++;
			}
			return name;

		}

		public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
		{
			string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
			
			if(!Directory.Exists(uploadPath))
			{
				Directory.CreateDirectory(uploadPath);
			}
			List<(string fileName, string path)> datas = new();
			List<bool> results = new();
			bool result;
			foreach (IFormFile file in files)
			{
				
					string fileNewName = FileRenameAsync(uploadPath, file.FileName);

					result = await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
					results.Add(result);
					datas.Add((fileNewName, $"{path}\\{fileNewName}"));
			
			
			}

			if(results.TrueForAll(x => x.Equals(true)))
			{
				return datas;
			}
			return null;

			//todo  hata mekanizmasi geliştirilecek
		}
	}
}
