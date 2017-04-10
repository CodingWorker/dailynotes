<!-- Application指令:设置应用程序的编程程序的专属指令，可以接受任何的k\v格式
    Language属性可以设置为任何一种标准语言名称
    -->
<%@ Application Language="C#" cc="ccaa"%>

<!-- 引入命名空间，从而使得该命名空间下的所有类和接口在本文件中可用 -->
<%@ Import Namespace="global.asax_study" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<!-- 绑定程序使用的程序集，在程序编译的过程中使用 
    name为程序集的名称，src只能使用相对路径
    如果需要绑定多个程序需要使用多个本条指令
    -->
<%@ Assembly Name="name" Src="relative/to/path" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

</script>
