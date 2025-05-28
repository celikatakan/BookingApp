using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Business.Operations.Setting
{
    public interface ISettinService
    {
        Task ToggleMaintenance();
        bool GetMaintenanceState();
    }
}
