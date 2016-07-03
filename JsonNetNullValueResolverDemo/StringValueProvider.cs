using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonNetNullValueResolver
{
    #region "字符串类型提供器"
    /// <summary>
    /// 字符串值类型提供器
    /// Author: 毛文君
    /// Date:2016-07-03
    /// </summary>
    class StringValueProvider : IValueProvider
    {
        private IValueProvider innerProvider;
        private object defaultValue;

        public StringValueProvider(IValueProvider innerProvider, Type stringType)
        {
            this.innerProvider = innerProvider;
            defaultValue = string.Empty;
        }

        public object GetValue(object target)
        {
            return innerProvider.GetValue(target) ?? defaultValue;
        }

        public void SetValue(object target, object value)
        {
            innerProvider.SetValue(target, value ?? defaultValue);
        }
    }
    #endregion
}
