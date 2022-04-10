using Autofac;
using Autofac.Extras.DynamicProxy;
using System.Reflection;

namespace DMS.MPTEST.Common.ServiceExtensions
{
    public class AutofacModuleRegister : Autofac.Module
    {
        public string RootPath { get; set; }
        public List<string> DllFiles { get; set; }
        public AutofacModuleRegister(string rootPath, List<string> dllFiles)
        {
            RootPath = rootPath;
            DllFiles = dllFiles;
        }

        protected override void Load(ContainerBuilder builder)
        {
            foreach (var dllFile in DllFiles)
            {
                var basePath = AppContext.BaseDirectory;
                #region 接口服务注入
                var servicesDllFile = Path.Combine(RootPath, dllFile);
                if (!(File.Exists(servicesDllFile)))
                {
                    var msg = $"{servicesDllFile}未找到注入的服务文件";
                    throw new Exception(msg);
                }
                var assemblysServices = Assembly.LoadFrom(servicesDllFile);
                builder.RegisterAssemblyTypes(assemblysServices)
                       .AsImplementedInterfaces()//表示注册的类型，以接口的方式注册不包括IDisposable接口
                       .InstancePerLifetimeScope()//即为每一个依赖或调用创建一个单一的共享的实例
                       .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy,使用接口的拦截器，在使用特性 [Attribute] 注册时，注册拦截器可注册到接口(Interface)上或其实现类(Implement)上。使用注册到接口上方式，所有的实现类都能应用到拦截器。
                       .PropertiesAutowired();//开始属性注入

                #endregion
            }

        }
    }
}
