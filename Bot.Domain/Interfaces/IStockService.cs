using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Domain.Interfaces
{
    public interface IStockService
    {
        Task<string> GetStockData(string command);
    }
}
