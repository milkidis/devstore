using DevStore.Entity;
using DevStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DevStore.API.ModelPresenter;

namespace DevStore.API.Controllers
{
    public class DeveloperController : ApiController
    {

        public JsonMessage<List<Developer>> GetPage(int page)
        {
            JsonMessage<List<Developer>> jsonReturn = new JsonMessage<List<Developer>>();
            try
            {
                DeveloperService devService = new DeveloperService();
                jsonReturn.BusinessObject = devService.page(page);
                jsonReturn.Success = "OK";
            }
            catch (Exception e)
            {
                jsonReturn.Success = "Error" + e.Message;
            }

            return jsonReturn;
        }

    }
}
