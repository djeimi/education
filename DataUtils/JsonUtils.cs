using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using TestProjectWithDB.Models;
using Dapper;
using TestProjectWithDB.SQLUtils;

namespace TestProjectWithDB.DataUtils
{
    public class JsonUtils
    {
        public static T GetModel<T>(RestResponse data)
        {
            return JsonConvert.DeserializeObject<T>(data.Content);
        }

        public static List<T> ConvertToList<T>(T data)
        {
            List<T> listOfCurrency = new();
            listOfCurrency.Add(data);
            return listOfCurrency;
        }

        public static string ParcingFromModel(Currency data)
        {
            string parameters = string.Empty;

            foreach (var prop in typeof(Currency).GetProperties())
            {
                if (prop.GetValue(data).GetType().Name.Equals(typeof(string).Name) || prop.GetValue(data).GetType().Name.Equals(typeof(DateTime).Name))
                {
                    if (prop.GetValue(data).ToString().Contains("'")) parameters += "'" + prop.GetValue(data).ToString().Replace("'", "''").Trim() + "', ";
                    else parameters += "'" + prop.GetValue(data).ToString().Trim() + "', ";
                }
                else parameters += prop.GetValue(data).ToString().Trim() + ", ";
            }
            return parameters;
        }

        public static string ModelToCommandParameters(Currency data)
        {
            return ParcingFromModel(data).Remove(ParcingFromModel(data).Length - 2);
        }

        public static string ListModelToCommandParameters(List<Currency> data)
        {
            string parameters = string.Empty;

            foreach (var element in data)
            {
                string subparameter = "(" + ParcingFromModel(element);
                parameters += subparameter.Remove(subparameter.Length-2) + "), ";
            }
            return parameters;
        }

        public static List<TestProjectWithDB.Models.Currency> GetListDataFromDB(string command)
        {
            List<Currency> dbList = DBRequest.ConnectionToDB().Query<TestProjectWithDB.Models.Currency>(command).AsList();
            List<Currency> updateDBList = new();

            foreach (var element in dbList)
            {
                Currency currency = new();
                foreach (var prop in typeof(Currency).GetProperties())
                {
                    if (prop.GetValue(element).GetType().Name.Equals(typeof(string).Name)) prop.SetValue(currency, prop.GetValue(element).ToString().Trim());
                    else prop.SetValue(currency, prop.GetValue(element));
                }
                updateDBList.Add(currency);
            }
            return updateDBList;
        }

        public static bool AreListsEqual(List<Currency> fromDB, List<Currency> sentData)
        {
            for (int i = 0; i < fromDB.Count; i++)
            {
                if (!EqualsCurrencyModel(fromDB[i], sentData[i])) return false;
            }
            return true;
        }

        public static bool EqualsCurrencyModel(Currency fromDB, Currency sentData)
        {
            foreach (var prop in typeof(Currency).GetProperties())
            {
                if (!prop.GetValue(sentData).ToString().Contains(prop.GetValue(fromDB).ToString()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
