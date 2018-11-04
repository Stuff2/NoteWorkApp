using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWork.Modals
{
    public class Login
    {
        string id;
        string mail;
        string password;
        bool Deleted;

        [JsonProperty(PropertyName = "ID")]
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "Mail")]
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        [JsonProperty(PropertyName = "Password")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [JsonProperty(PropertyName = "deleted")]
        public bool deleted
        {
            get { return Deleted; }
            set { Deleted = value; }
        }

    }
}
