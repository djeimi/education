using TestProjectWithDB.Api;
using NUnit.Framework;
using RestSharp;
using TestProjectWithDB.Resources;
using System.Threading.Tasks;
using TestProjectWithDB.Models;
using System.Collections.Generic;
using TestProjectWithDB.SQLUtils;

namespace TestProjectWithDB
{
    public class Tests
    {
        [Test]
        public async Task Test1()
        {
            var response = await new Builder(Pathes.generalPath)
                .AddMethod(Method.Get)
                .Execute(System.Net.HttpStatusCode.OK);

            var receivedModel = DataUtils.JsonUtils.GetModel<List<Currency>>(response);
            string commandParameters = DataUtils.JsonUtils.ListModelToCommandParameters(receivedModel);

            DBRequest.ExecuteCommand("TRUNCATE TABLE [Currency]");

            string command = $"INSERT INTO [Currency] VALUES{commandParameters.Remove(commandParameters.Length-2)}";
            DBRequest.ExecuteCommand(command);

            List<Currency> dataFromDB = DataUtils.JsonUtils.GetListDataFromDB("SELECT * FROM [Currency]");

            Assert.IsTrue(DataUtils.JsonUtils.AreListsEqual(dataFromDB, receivedModel), "Data are not equal");
        }
        [Test]
        public async Task Test2()
        {
            var response = await new Builder(Pathes.generalPath)
                .AddPath("2")
                .AddMethod(Method.Get)
                .Execute(System.Net.HttpStatusCode.OK);

            var receivedModel = DataUtils.JsonUtils.ConvertToList(DataUtils.JsonUtils.GetModel<Currency>(response));

            string commandParameters = DataUtils.JsonUtils.ListModelToCommandParameters(receivedModel);

            DBRequest.ExecuteCommand("TRUNCATE TABLE [Currency]");

            string command = $"INSERT INTO [Currency] VALUES{commandParameters.Remove(commandParameters.Length - 2)}";
            DBRequest.ExecuteCommand(command);

            List<Currency> dataFromDB = DataUtils.JsonUtils.GetListDataFromDB("SELECT * FROM [Currency]");

            Assert.IsTrue(DataUtils.JsonUtils.AreListsEqual(dataFromDB, receivedModel), "Data are not equal");
        }
    }
}