using LocVideo.ApplicationCore.Interfaces;
using LocVideo.ApplicationCore.Interfaces.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocVideo.ApplicationCore.Services
{
    public class ClientService : IClientService

    {
        private IClientRepository _repository { get; set; }

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClientLoc> CreateClient(ClientLocDto clientLoc)
        {
            var idClient = 0;
            var existDocument = await ExistCPF(clientLoc.Document, idClient);
            if (existDocument == null)
                return null;

            var existEmail = await ExistEmail(clientLoc.Email, idClient);
            if (existEmail == null)
                return null;


            return await _repository.CreateClient(clientLoc);
        }

        public async Task<string> ExistCPF(string document, int idClient)
        {
            var result = await _repository.ExistCPF(document, idClient);

            if (result == document)
                 return null;
            

            return document;
        }

        public async Task<string> ExistEmail(string email, int clientId)
        {
            var result = await _repository.ExistEmail(email, clientId);

            if (result == email)
                return null;

            return email;
        }


    }
}
