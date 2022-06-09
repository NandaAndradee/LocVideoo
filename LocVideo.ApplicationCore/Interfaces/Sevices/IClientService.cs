using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocVideo.ApplicationCore.Interfaces.Sevices
{
    public interface IClientService
    {
        Task<ClientLoc> CreateClient(ClientLocDto clientLoc);
        Task<string> ExistCPF(string document, int idClient);
        Task<string> ExistEmail(string email, int clientId);

    }
}
