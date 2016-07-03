using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonNetNullValueResolver
{
    /// <summary>
    /// 属性数据类型枚举
    /// Author: 毛文君
    /// Date:2016-07-03
    /// </summary>
    public enum PropertyDataType
    {
        Unknown = -1,
        StringType = 0,
        NumberType = 1,
        CollectionType = 2,
        BaseObject = 3

    }
}
