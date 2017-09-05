using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace RemotingInterface
{
    public interface DesktopInterface
    {
        String HelloMethod(String Name);
        String GoodByeMethod();
        MemoryStream GetBitmap();
    }
}
