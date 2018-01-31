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

namespace KoiAnime_REST_Server
{
    [RestResource]
    public class TitleResource
    {
        private koianimeDataSetTableAdapters.titleTableAdapter titlesTable = new titleTableAdapter();

        [RestRoute(PathInfo = "/Gallery")]
        public IHttpContext Gallery(IHttpContext context)
        {
            DataTable dt = titlesTable.GetData();
            List<Title> lisTitles = new List<Title>();
            string json = null;
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Title t = new Title((koianimeDataSet.titleRow)dt.Rows[i], "Gallery");
                    lisTitles.Add(t);
                    json = JsonConvert.SerializeObject(lisTitles);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            context.Response.SendResponse(json);
            return context;
        }


        [RestRoute(PathInfo = "/TopRated")]
        public IHttpContext TopRated(IHttpContext context)
        {
            DataTable dt = titlesTable.GetData();
            List<Title> lisTitles = new List<Title>();
            string json = null;
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Title t = new Title((koianimeDataSet.titleRow)dt.Rows[i], "TopRated");
                    lisTitles.Add(t);
                    json = JsonConvert.SerializeObject(lisTitles);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            context.Response.SendResponse(json);
            return context;
        }

        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/GetTitle")]
        public IHttpContext GetTitle(IHttpContext context)
        {
            var titleid = context.Request.QueryString["titleid"];

            DataTable dt = titlesTable.GetDataByID(int.Parse(titleid));
            string json = null;

            try
            {
                Title t = new Title((koianimeDataSet.titleRow)dt.Rows[0], "Gallery");
                json = JsonConvert.SerializeObject(t);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            context.Response.SendResponse(json);
            return context;
        }
    }
}
