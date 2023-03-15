using Producer.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer.Application.Interfaces
{
    public interface IPostService
    {
        void Post(Post post);
    }
}
