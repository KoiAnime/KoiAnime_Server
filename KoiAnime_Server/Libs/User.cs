using System;

namespace KoiAnime_REST_Server.Libs
{
    [Serializable]
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public DateTime date { get; set; }

        public User(koianimeDataSet.accountRow accountRow)
        {
            username = accountRow.username;
            password = accountRow.password;
            email = accountRow.email;
            date = accountRow.start_date_account;
        }

        public User(string user,string passwrd,string mail,DateTime dateTime)
        {
            username = user;
            password = passwrd;
            email = mail;
            date = dateTime;
        }
    }
}
