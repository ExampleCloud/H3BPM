using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OThinker.H3.Example.RemotingModel
{
    public class TalkerServer : MarshalByRefObject, ITalker
    {
        public string SaySomething()
        {
            return this.GetType().FullName;
        }
    }
}
