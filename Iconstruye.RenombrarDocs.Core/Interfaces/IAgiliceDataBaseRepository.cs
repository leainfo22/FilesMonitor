using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenombrarDocs.Core.Interfaces
{
	public interface IAgiliceDataBaseRepository
	{		
		public Task<string> GetXml(string folio, string tipoDoc, string rutEmisor);
	}
}
