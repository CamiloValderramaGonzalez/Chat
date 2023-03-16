using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Domain.Interfaces
{
    public interface IStockRepository
    {
        Task<string> GetStockData(string command);
    }
}
