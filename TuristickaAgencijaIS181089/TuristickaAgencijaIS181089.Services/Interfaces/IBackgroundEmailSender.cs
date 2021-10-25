using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TuristickaAgencijaIS181089.Services.Interfaces
{
    public interface IBackgroundEmailSender
    {
        Task DoWork();
    }
}
