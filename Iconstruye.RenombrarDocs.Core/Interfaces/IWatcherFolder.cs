using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenombrarDocs.Core.Interfaces
{
	public interface IWatcherFolder
	{
		public Task Watcher(string pathIn, string pathOut,ILogger logger);
	}
}
