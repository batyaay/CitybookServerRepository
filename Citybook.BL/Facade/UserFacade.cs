using Citybook.Common.Model;
using Citybook.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citybook.BL.Facade
{
    public class UserFacade
    {
        public SaveUserResponse SaveUser(User user)
        {
            SaveUserResponse res = new SaveUserResponse();
            if (user == null)
            {
                res.IsSuccessful = false;
                res.ErrorMessage = "error, user to save is null";
            }
            else
            {
                string jsonData = JsonConvert.SerializeObject(user);
                res.IsSuccessful = new Data().SaveUser(jsonData, user.Tz);
            }
            return res;
        }
    }
}
