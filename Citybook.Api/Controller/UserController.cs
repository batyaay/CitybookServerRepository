using Citybook.BL.Facade;
using Citybook.Common.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Citybook.Api.Controller
{
    [System.Web.Http.RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [Route("SaveUser"), HttpPost()]
        public HttpResponseMessage SaveUser([FromBody]  JObject jsonReq)
        {
            SaveUserResponse res = new SaveUserResponse();
            User user = new User();

            if (jsonReq["FirstName"] == null || jsonReq["FirstName"].ToString() == ""
                || jsonReq["LastName"] == null || jsonReq["LastName"].ToString() == ""
                || jsonReq["Tz"] == null || jsonReq["Tz"].ToString() == ""
                || jsonReq["Birthdate"] == null || jsonReq["Birthdate"].ToString() == ""
                || jsonReq["HealthFund"] == null || jsonReq["HealthFund"].ToString() == ""
                || jsonReq["MaleOrFemale"] == null || jsonReq["MaleOrFemale"].ToString() == "")
            {
                res.IsSuccessful = false;
                res.ErrorMessage = "validation error";
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            
            user.FirstName = jsonReq["FirstName"].ToString();
            user.LastName = jsonReq["LastName"].ToString();
            user.Tz = jsonReq["Tz"].ToString();
            user.Birthdate = jsonReq["Birthdate"].ToString();
            user.HealthFund = jsonReq["HealthFund"].ToString();
            user.MaleOrFemale = jsonReq["MaleOrFemale"].ToString();
            user.Children = new List<Child>();

            if (jsonReq["Children"] != null && jsonReq["Children"].Count() > 0)
            {
                foreach (var child in jsonReq["Children"])
                {
                    user.Children.Add(new Child() {
                        Name = child["Name"].ToString(),
                        Tz = child["Tz"].ToString(),
                        Birthdate = child["Birthdate"].ToString()
                    });
                }
            }
            
            try
            {
                res = new UserFacade().SaveUser(user);
            }
            catch (Exception ex)
            {
                res.IsSuccessful = false;
                res.ErrorMessage = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }       
    }
}
