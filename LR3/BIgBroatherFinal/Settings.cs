using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIgBroatherFinal   
{
    [Serializable]
    public  class Settings
    {
        public List<Portfolio> Folders { get; set; } = new List<Portfolio>();
    }
}
