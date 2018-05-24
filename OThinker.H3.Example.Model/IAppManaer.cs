using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OThinker.H3.Example.RemotingModel
{
    /// <summary>
    /// App管理类
    /// </summary>
    public interface IAppManager
    {
        /// <summary>
        /// 获取App名称
        /// </summary>
        /// <param name="id">应用id</param>
        /// <returns>App名称</returns>
        string GetAppName(string id);

    }
}
