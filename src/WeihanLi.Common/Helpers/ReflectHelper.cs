﻿using System;
using System.Linq;
using System.Reflection;

namespace WeihanLi.Common.Helpers
{
    public static class ReflectHelper
    {
        public static Assembly[] GetAssemblies()
        {
            Assembly[] assemblies = null;
#if NET45
            if (System.Web.Hosting.HostingEnvironment.IsHosted)
            {
                assemblies = System.Web.Compilation.BuildManager.GetReferencedAssemblies()
                                            .Cast<Assembly>().ToArray();
            }
#endif

            if (null == assemblies || assemblies.Length == 0)
            {
                assemblies = AppDomain.CurrentDomain.GetAssemblies();
            }

            return assemblies ?? ArrayHelper.Empty<Assembly>();
        }
    }
}
