using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoForWpfCore.HostObject
{
    #pragma warning disable CS0618
    [System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.AutoDual)]
    #pragma warning restore CS0618
    [System.Runtime.InteropServices.ComVisible(true)]
    public class WsC2WHostObject
    {
        public void WSClientFunction(string requestInfo)
        {
            Console.WriteLine(requestInfo);
        }
    }
}
