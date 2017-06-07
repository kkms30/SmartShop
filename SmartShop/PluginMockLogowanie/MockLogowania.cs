using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginMockLogowanie
{
    public class MockLogowania : IMockLogowania
    {
        public bool CheckLoginData(string log, string pas)
        {
            if (log.Equals("test") && pas.Equals("test"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
