using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using KoiAnime_REST_Server.koianimeDataSetTableAdapters;
using KoiAnime_REST_Server.Libs;
using Newtonsoft.Json;

namespace KoiAnime_REST_Server.RestResources
{
    [RestResource]
    public class UserResource
    {
        koianimeDataSetTableAdapters.accountTableAdapter accountTableAdapter = new accountTableAdapter();

        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/createUser")]
        public IHttpContext CreateUser(IHttpContext context)
        {
            //http://localhost:5550/createUser?username=test&password=pollas
            var username = context.Request.QueryString["username"];
            var password = context.Request.QueryString["password"];
            var email = context.Request.QueryString["email"];

            accountTableAdapter.Insert(username, password, email, DateTime.Now);

            context.Response.SendResponse(Encoding.UTF8.GetBytes(""));
            return context;
        }

        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/getUser")]
        public IHttpContext GetUser(IHttpContext context)
        {
            var username = context.Request.QueryString["username"];

            DataTable dt = accountTableAdapter.GetDataByUsername(username);

            koianimeDataSet.accountRow accountRow = (koianimeDataSet.accountRow) dt.Rows[0];

            User u = new User(accountRow);

            string json = JsonConvert.SerializeObject(u);
            context.Response.SendResponse(json);
            return context;
        }

    }
}
