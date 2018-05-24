![调用逻辑图](https://upload-images.jianshu.io/upload_images/855297-3aa9a94be43696da.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

###统一验证服务器  H3BPM
调用逻辑图中的认证中心

功能模块隶属于 H3BPM,用户用户统一认证登陆。

View： /Views/SSOLogin/index.cshtml
Controller:  Controllers/SSOLoginController.cs

作用：对登陆做统一管理，登陆后会记录用户Session，再次访问会判断是否存在登陆状态，存在的话直接验证请求系统的单点登陆编码，并生成带**Token**的回调地址。

###回调处理  SSODemo
调用逻辑图中的业务系统

View： /Views/Login/index.cshtml
Controller:  Controllers/LoginController.cs

作用：对返回的**Token**进行处理，解析获得**UserCode**，再去处理自己系统的登陆逻辑，获取用户信息并完成登陆操作。

***

引入的SSOService：http://121.40.136.138:8010/Portal/WebServices/SSOService.asmx
引入BPM 测试环境的SSOService

SSOService [说明](http://wiki.h3yun.com/);