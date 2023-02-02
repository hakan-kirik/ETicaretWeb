using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Exceptions
{
	public class AuthenticationErrorException : Exception
	{
		public AuthenticationErrorException():base("kimlik dogrulama hatası")
		{
		}

		public AuthenticationErrorException(string? message) : base(message)
		{
		}

		public AuthenticationErrorException(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}
