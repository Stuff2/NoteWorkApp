using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWork.Modals
{
    public class NetWork
    {
        string id;
        string fpid;
        string spid;
        bool iscontacts;
        bool islinked;
        bool isface;
        bool isgmail;
        bool deleted;
        string meetwhen;
        string meetwhere;
        string firstimpression;
        string distinctive;
        string meetstate;
        string networks;
        

        [JsonProperty(PropertyName = "MeetWhen")]
        public string MeetWhen
        {
            get { return meetwhen; }
            set { meetwhen = value; }
        }

        [JsonProperty(PropertyName = "MeetWhere")]
        public string MeetWhere
        {
            get { return meetwhere; }
            set { meetwhere = value; }
        }

        [JsonProperty(PropertyName = "FirstImpression")]
        public string FirstImpression
        {
            get { return firstimpression; }
            set { firstimpression = value; }
        }

        [JsonProperty(PropertyName = "Distinctive")]
        public string Distinctive
        {
            get { return distinctive; }
            set { distinctive = value; }
        }

        [JsonProperty(PropertyName = "MeetState")]
        public string MeetState
        {
            get { return meetstate; }
            set { meetstate = value; }
        }

        [JsonProperty(PropertyName = "NetWorks")]
        public string NetWorks
        {
            get { return networks; }
            set { networks = value; }
        }

        [JsonProperty(PropertyName = "ID")]
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "FPID")]
        public string FPID
        {
            get { return fpid; }
            set { fpid = value; }
        }

        [JsonProperty(PropertyName = "SPID")]
        public string SPID
        {
            get { return spid; }
            set { spid = value; }
        }

        [JsonProperty(PropertyName = "IsContacts")]
        public bool IsContacts
        {
            get { return iscontacts; }
            set { iscontacts = value; }
        }

        [JsonProperty(PropertyName = "IsLinked")]
        public bool IsLinked
        {
            get { return islinked; }
            set { islinked = value; }
        }

        [JsonProperty(PropertyName = "IsFace")]
        public bool IsFace
        {
            get { return isface; }
            set { isface = value; }
        }

        [JsonProperty(PropertyName = "IsGmail")]
        public bool IsGmail
        {
            get { return isgmail; }
            set { isgmail = value; }
        }

        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
