using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OThinker.H3.Example.RemotingModel
{
    class AppManager : IAppManager
    {
        public string name;

        public string Name {
            get { return name; }
        }
            public string GetAppName(string id)
        {
            return "服务器端返回的应用名称,应用Id"+id;
        }
    }

 
}
