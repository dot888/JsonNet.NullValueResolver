using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonNetNullValueResolver
{
    #region "集合类型提供器"
    /// <summary>
    /// 空集合值提供器
    /// Author: 毛文君
    /// Date:2016-07-03
    /// </summary>
    class EmptyCollectionValueProvider : IValueProvider
    {
        private IValueProvider innerProvider;
        private object defaultValue;

        public EmptyCollectionValueProvider(IValueProvider innerProvider, Type listType)
        {
            this.innerProvider = innerProvider;
            defaultValue = Activator.CreateInstance(listType, 0);
        }

        public void SetValue(object target, object value)
        {
            innerProvider.SetValue(target, value ?? defaultValue);
        }

        public object GetValue(object target)
        {
            return innerProvider.GetValue(target) ?? defaultValue;
        }
    }
    #endregion
}
