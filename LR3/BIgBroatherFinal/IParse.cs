using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIgBroatherFinal
{
    interface IParse
    {
        T Parse<T>() where T : new();
    }
}
