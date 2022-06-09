using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocVideo.ApplicationCore.Interfaces
{
    public interface IClientRepository
    {
        Task<ClientLoc> CreateClient(ClientLocDto clientLoc);
        Task<string> ExistCPF(string document, int clientId);
        Task<string> ExistEmail(string email, int clientId);

    }
}
