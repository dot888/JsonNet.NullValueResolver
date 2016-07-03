"# JsonNet.NullValueResolver" 

### 在做APP后台接口开发时，经常遇到以下问题:
    1.字段为NULL的值，在序列化时，直接序列化为NULL值
    2.对象、对象数组为NULL时
    3.日期转时间戳处理
>

这些问题都容易引起APP端的崩溃 

### 理想的处理是:
    1.字符串为NULL时，返回：""
    2.对象为NULL时，返回：{}
    3.对象数组为NULL时，返回：[]

JsonNet.NullValueResolver就是为解决这些问题而来。

#### 测试类
    /// <summary>
    /// 测试类
    /// </summary>
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }

        public object Entity { get; set; }

        [JsonConverter(typeof(UnixTimeStampDateTimeConverter))]
        public DateTime TestDate { get; set; }

        public DateTime? NullableDate { get; set; }

        public bool? NullableBool { get; set; }
        public Guid? NullableGuid { get; set; }
    }
    
>
>

### 使用前的配置
            JsonConvert.DefaultSettings = (() =>
            {
                var settings = new JsonSerializerSettings();
                settings.ContractResolver = new NullValueResolver();
                return settings;
            });

>
>
其它操作不变，这样在序列化时，将能够自动处理NULL值这些问题，开发过程中，经常还会遇到要传时间戳的问题，比如给APP端传时间时传时间戳，APP端给Server端传数据时也要传时间戳，这个例子里也有写，可以很方便的进行自由转换。

### 示例代码：

        static void Main(string[] args)
        {
            var responseModel = new[] { new ResponseModel() };
            responseModel[0].IsSuccess = true;

            //Entity --> null
            responseModel[0].Entity = null;


            // JsonNet Configuration
            JsonConvert.DefaultSettings = (() =>
            {
                var settings = new JsonSerializerSettings();
                settings.ContractResolver = new NullValueResolver();
                return settings;
            });


            Console.WriteLine("Before Serialize：");
            Console.Write("TestDate:");
            responseModel[0].TestDate = DateTime.Now;
            Console.WriteLine(responseModel[0].TestDate);

            Console.WriteLine("----------------------------");

            //serialize object to json
            var jsonResult = JsonConvert.SerializeObject(responseModel);
            Console.WriteLine(jsonResult);


            Console.WriteLine("----------------------------");

            //deserialize json string to object
            var inputJsonResult = JsonConvert.DeserializeAnonymousType(jsonResult, responseModel);
            Console.WriteLine("After Deserialized：");
            Console.Write("TestDate:");
            Console.WriteLine(inputJsonResult[0].TestDate);

            Console.ReadLine();
        }
