using Newtonsoft.Json;
using System.Collections.Generic;
namespace NoteWork.Modals
{
    public class ListProfile
    {
        [JsonProperty("data")]
        public List<Datas> datas { get; set; }
        [JsonProperty("paging")]
        public Paging paging { get; set; }


        public class Datas
        {
            [JsonProperty("picture")]
            public Picture Picture { get; set; }

            [JsonProperty("first_name")]
            public string FirstName { get; set; }
            [JsonProperty("last_name")]
            public string LastName { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

        }

        public class Paging
        {
            [JsonProperty("cursors")]
            public Cursors cursors { get; set; }
            [JsonProperty("next")]
            public string next { get; set; }

        }

        public class Cursors
        {
            [JsonProperty("before")]
            public string Before { get; set; }
            [JsonProperty("after")]
            public string After { get; set; }

        }

        public class Picture
        {
            [JsonProperty("data")]
            public Data Data { get; set; }
        }

        public class Data
        {
            [JsonProperty("issilhouette")]
            public bool IsSilhouette { get; set; }
            [JsonProperty("url")]
            public string Url { get; set; }
        }

    }
}
