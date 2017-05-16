using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginMockLogowanie
{
    public interface IMockLogowania
    {
        bool CheckLoginData(string log, string pas);
    }
}
