using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCredit.DAL
{
    public interface IDAL
    {
        Task<DataTable> ExecuteCommandAsync(string spName, string filter = "");
    }
}
