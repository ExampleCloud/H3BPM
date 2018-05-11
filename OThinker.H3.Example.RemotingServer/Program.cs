using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using OThinker.H3.Example.Model;

namespace OThinker.H3.Example.RemotingServer
{
    class Program
    {
        static void Main(string[] args)
        {

            RegisterRemoting();
            RegisterH3Remoting();

            Console.ReadLine();

        }

        private static void RegisterRemoting() {
            //注册通道
            TcpServerChannel channel = new TcpServerChannel("Talker", 8090); //端口随便取
            ChannelServices.RegisterChannel(channel, true);

            //注册远程对象
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(TalkerServer),
                "Talker",
               WellKnownObjectMode.Singleton);
            Console.WriteLine("Talker 服务器端注册成功！");
        }

        private static void RegisterH3Remoting()
        {
            //注册通道
            TcpServerChannel channel = new TcpServerChannel("H3BPMSERVER", 8091); //端口随便取
            ChannelServices.RegisterChannel(channel, true);

            Vessel vessel = new Vessel();
            //注册远程对象
            RemotingServices.Marshal(vessel, "H3BPMSERVER");
         
            Console.WriteLine("H3BPMSERVER 服务器端注册成功！");
        }
    }
}
