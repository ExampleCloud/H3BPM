using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OThinker.H3.Example.Model
{
    public class AppManagerClient : IAppManager
    {
        public string ModuleName = "AppManager";

        private IVessel vessel;

        /// <summary>
        /// 构造器初始化Vessel对象
        /// </summary>
        /// <param name="vessel"></param>
        public AppManagerClient(IVessel vessel)
        {
            this.vessel = vessel;
        }

        /// <summary>
        /// 获取App名称
        /// </summary>
        /// <param id="id">应用id</param>
        /// <returns>app的名称</returns>
        public string GetAppName(string id)
        {

            return (string)this.vessel.InvokeMethod_O(ModuleName, "GetAppName", new object[] { id });
        }


    }
}
