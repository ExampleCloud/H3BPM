using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using OThinker.H3.Example.Model;

namespace OThinker.H3.Example.RemotingClient
{
    class Program
    {
        static IVessel vessel;
        static ITalker talkerClient;
        static void Main(string[] args)
        {

            //注册通道
            TcpClientChannel channel = new TcpClientChannel();
            ChannelServices.RegisterChannel(channel, true);

            talkerClient = (ITalker)Activator.GetObject(
             typeof(ITalker), "tcp://localhost:8090/Talker");
            Console.WriteLine("talker 远程对象激活成功。！");

            vessel = (IVessel)Activator.GetObject(
             typeof(IVessel), "tcp://localhost:8091/H3BPMSERVER");
            Console.WriteLine("vessel 远程对象激活成功。！");

            while (true)
            {

                Console.WriteLine("1,直接执行简单Remoting调用。");
                Console.WriteLine("2,执行复杂Remoting调用。");

                string keyboard = Console.ReadLine();

                switch (keyboard)
                {
                    case "1":
                        InvokeRemoting();
                        break;
                    case "2":
                        InvokeH3Remoting();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void InvokeRemoting()
        {
           

            string result = talkerClient.SaySomething();

            Console.WriteLine(result);

            Console.ReadLine();
        }

        private static void InvokeH3Remoting()
        {

            IAppManager appManager = new AppManagerClient(vessel);
            Console.WriteLine("请输入应用ID");
            string keyboard = Console.ReadLine();
            string result = appManager.GetAppName(keyboard);

            Console.WriteLine(result);

            Console.ReadLine();

        }
    }
}
