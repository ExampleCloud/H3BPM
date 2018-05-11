### H3BPM Remoting 示例程序

## OThinker.H3.Example.RemotingServer 服务端

用于开启Remoting服务，有两种方式。

* RegisterRemoting()
注册一个单例模式的Remoting对象。

* RegisterH3Remoting()
H3BPM 采用的方式
将MarshalByRefObject类对象转化为ObjRef类对象，这个对象是存储生成代理以与远程对象通讯所需的所有相关信息。

## OThinker.H3.Example.RemotingClient

客户端调用示例

* InvokeRemoting()
直接获取远程对象并且执行远程对象方法。

* InvokeH3Remoting()
H3BPM 的执行方式。
本质上是获取了一个Vessel对象，再通过Vessel对象的 InvokerMethod_O() 方法来执行实际模块的方法（利用反射）

## OThinker.H3.Example.Model
定义远程对象模型类，以及接口类。