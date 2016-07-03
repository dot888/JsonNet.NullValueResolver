using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JsonNetNullValueResolver
{
    /// <summary>
    /// 空值解析器
    /// Author: 毛文君
    /// Date:2016-07-03
    /// </summary>
    public class NullValueResolver : DefaultContractResolver
    {
        protected override IValueProvider CreateMemberValueProvider(MemberInfo member)
        {
            var provider = base.CreateMemberValueProvider(member);

            if (member.MemberType == MemberTypes.Property)
            {
                Type propType = ((PropertyInfo)member).PropertyType;
                return ValueProviderFactory.GetValueProvider(provider, propType);
            }

            return provider;
        }
    }
}
