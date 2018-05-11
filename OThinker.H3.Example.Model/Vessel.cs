using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OThinker.H3.Example.Model
{
    public class Vessel : MarshalByRefObject, IVessel
    {

        public object InvokeMethod_O(string moduleName, string methodName, object[] parameters)
        {
            /*
                通过反射执行实际的模块。
                只有Vessel是一个注册了的远程对象。
                AppManger 并不是一个远程对象，这个对象一直存在于Remoting服务器端。
                这里便于实现就直接实现反射代码了。
                实际上H3BPM里关于这部分的实现更加复杂。
             */

            Type t = Type.GetType("OThinker.H3.Example.Model." + moduleName);
            object obj = System.Activator.CreateInstance(t);
            System.Reflection.MethodInfo method = t.GetMethod(methodName);//获得方法
            return method.Invoke(obj, parameters);//调用方法
        }
    }
}
