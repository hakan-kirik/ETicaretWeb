using NpgsqlTypes;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace ETicaretApi.API.Configurations.ColumnWriter
{
	public class UsernameColumnWriter : ColumnWriterBase
	{
		public UsernameColumnWriter(NpgsqlDbType dbType=NpgsqlDbType.Varchar, int? columnLength = null) : base(dbType, columnLength)
		{
		}

		public override object GetValue(LogEvent logEvent, IFormatProvider formatProvider = null)
		{
			var (username,value)=logEvent.Properties.FirstOrDefault(p=>p.Key=="user_name");
			return value?.ToString() ?? null;
		
		}
	}
}
