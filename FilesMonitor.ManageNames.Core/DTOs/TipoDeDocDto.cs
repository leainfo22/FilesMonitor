using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenombrarDocs.Core.DTOs
{
	public class TipoDeDocDto
	{
		public Dictionary<string, string> tipoDeDoc =  new Dictionary<string, string>();
		public TipoDeDocDto() 
		{			
			tipoDeDoc.Add("FacturaElectronica", "33"); 
			tipoDeDoc.Add("FacturaElectronicaExenta", "34");
			tipoDeDoc.Add("NotaCreditoElectronica", "61");
			tipoDeDoc.Add("NotaDebitoElectronica", "56");
			tipoDeDoc.Add("BoletaElectronica","39");
			tipoDeDoc.Add("GuiaDespachoElectronica", "52");
			tipoDeDoc.Add("FacturaExportacionElectronica", "110");
			tipoDeDoc.Add("BoletaExentaElectronica", "41");
			tipoDeDoc.Add("FacturaCompraElectronica", "46"); 
		}
	}
}
