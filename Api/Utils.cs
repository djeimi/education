using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using TestProjectWithDB.DataUtils;

namespace TestProjectWithDB.Api
{
    public class Utils
    {
        public static bool IsDataJson(RestResponse data)
        {
            return data.ContentType.Contains("json");
        }

        public static bool IsDataSorted<T>(RestResponse data, Func<T, int> func)
        {
            List<T> SortedData = JsonUtils.GetModel<List<T>>(data).OrderBy(func).ToList();

            return JsonUtils.GetModel<List<T>>(data).SequenceEqual(SortedData);
        }
    }
}
