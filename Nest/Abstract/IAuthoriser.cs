using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Abstract {
    public interface IAuthoriser {
        bool Authenticate(string username, string password);
    }
}
