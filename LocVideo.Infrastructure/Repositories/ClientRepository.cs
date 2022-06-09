using Dapper;
using LocVideo.ApplicationCore;
using LocVideo.ApplicationCore.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using LocVideo.ApplicationCore.Dto;
using System.Linq;

namespace LocVideo.Infrastructure
{
    public class ClientRepository : IClientRepository
    {
        private readonly string _connectionString;

        public ClientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public async Task<ClientLoc> CreateClient (ClientLocDto clientLoc)
        {

            using (var connection = new SqlConnection(_connectionString))
            {

                var query = "INSERT INTO Clients (name, email, document, birthdate, phone) VALUES ( @name, @email , @document, @birthdate, @phone) SELECT CAST(SCOPE_IDENTITY() as int)";
                var parameters = new DynamicParameters();

                parameters.Add("name", clientLoc.Name, DbType.String);
                parameters.Add("email", clientLoc.Email, DbType.String);
                parameters.Add("document", clientLoc.Document, DbType.String);
                parameters.Add("birthdate", clientLoc.Birthdate, DbType.String);
                parameters.Add("phone", clientLoc.Phone, DbType.String);

                connection.Open();
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var created = new ClientLoc
                {
                    IdClient = id,
                    Name = clientLoc.Name,
                    Email = clientLoc.Email,
                    Document = clientLoc.Document,
                    Birthdate = clientLoc.Birthdate,
                    Phone = clientLoc.Phone
                };
                return created;
            }
        }

        public async Task<string> ExistCPF(string document, int clientId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                var query = "SELECT Clients.idClient AS IdClient, Clients.name AS Name, Clients.email AS Email, Clients.document AS Document, Clients.birthdate AS Birthdate, Clients.phone AS Phone FROM Clients WHERE Clients.document=@Document ";
                connection.Open();
                var parameters = new DynamicParameters();

                parameters.Add("@Document", document, DbType.String);

                var okClient = await connection.QueryAsync<ClientEmailCPFDto>(query, parameters);
                var validUser = okClient.FirstOrDefault();
                if (validUser == null)
                    return null;

                if (validUser.IdClient == clientId)
                    return null;

                return validUser.Document;
            }

        }

        public async Task<string> ExistEmail(string email, int clientId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                var query = "SELECT Clients.idClient AS IdClient, Clients.name AS Name, Clients.email AS Email, Clients.document AS Document, Clients.birthdate AS Birthdate, Clients.phone AS Phone FROM Clients WHERE Clients.email=@Email ";
                connection.Open();
                var parameters = new DynamicParameters();

                parameters.Add("@Email", email, DbType.String);

                var okUser = await connection.QueryAsync<ClientEmailCPFDto>(query, parameters);
                var validClient = okUser.FirstOrDefault();
                if (validClient == null)
                    return null;

                if (validClient.IdClient == clientId)
                    return null;

                return validClient.Email;
            }

        }

    }
}
