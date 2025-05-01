using Dapper;
using RenombrarDocs.Core.Interfaces;
using System.Data;
using RenombrarDocs.Core.DTOs.DB;


namespace RenombrarDocs.Infraestructure.Repository
{
	public class AgiliceDataBaseRepository : IAgiliceDataBaseRepository
	{

		private readonly IDbConnection _connection;

		public AgiliceDataBaseRepository(IDbConnection connection)
		{
			_connection = connection;
		}
		public async Task<string> GetXml(string folio, string tipoDoc,string rutEmisor)
		{
			try
			{
				var idEmpresa = await GetIdEmpresa(rutEmisor);
				if(idEmpresa.Contains("ExceptionError"))
					return "ExceptionError";

				var idDocumento = await GetIdDocumento(folio,tipoDoc,idEmpresa);
				if (idDocumento.Contains("ExceptionError"))
					return "ExceptionError";

				var sql = String.Format(@"SELECT Xml FROM Dte.XmlDte WHERE DocumentoId={0} ", idDocumento);
				var xml = _connection.QueryAsync<XmlDto>(sql);

				return xml.Result.First().Xml;
			}
			catch (Exception ex)
			{
				return "ExceptionError" + ex.Message;
			}

		}
		public async Task<string> GetIdEmpresa(string rutEmisor)
		{
			try
			{
				var sql = String.Format(@"SELECT Id FROM Hub.Empresas WHERE Rut={0}",rutEmisor);
				var idEmpresa = await _connection.QueryAsync<IdEmpresaDto>(sql);
				return idEmpresa.First().Id;
			}
			catch (Exception ex)
			{
				return "ExceptionError" + ex.Message;
			}

		}
		public async Task<string> GetIdDocumento(string folio, string tipoDoc, string idEmpresa)
		{
			try
			{
				var sql = String.Format(@"SELECT Id FROM Dte.Documentos WHERE EmisorId={0} AND TipoDocumento={1} AND Folio={2}", idEmpresa, tipoDoc, folio);
				var idDocumento =await _connection.QueryAsync<IdDocumento>(sql);
				return idDocumento.First().Id;
			}
			catch (Exception ex)
			{
				return "ExceptionError" + ex.Message;
			}

		}
	}
}
