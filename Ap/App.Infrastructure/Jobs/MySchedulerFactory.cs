#region

using Quartz;
using Quartz.Impl;
using Yozian.DependencyInjectionPlus.Attributes;

#endregion

namespace App.Infrastructure.Jobs
{
    /// <summary>
    /// 
    /// </summary>
    [SingletonService(typeof(ISchedulerFactory))]
    public class MySchedulerFactory : StdSchedulerFactory
    {
    }
}
