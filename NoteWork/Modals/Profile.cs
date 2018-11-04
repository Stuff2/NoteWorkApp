using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWork.Modals
{
    public class Profile
    {
        string id;
        string lid;
        bool Deleted;
        string firstname;
        string lastname;
        string company;
        string jobtitle;
        string city;
        string telno;
        string email;
        string faceAccount;
        string linkedAccount;
        string twitterAccount;
        string instaAccount;
        string noteid;
        string hometown;
        DateTime birthdate;
        string officeAddress;
        string assistantName;
        string previouscompanies;
        string profficiencies;
        string projects;
        string sertificates;
        string universities;
        string highschool;
        string familymembers;
        string homeAddress;
        string foundAssociates;
        string sports;
        string hobbies;
        string team;
        string travels;
        string jobstate;

        [JsonProperty(PropertyName = "ID")]
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "LID")]
        public string LID
        {
            get { return lid; }
            set { lid = value; }
        }

        [JsonProperty(PropertyName = "deleted")]
        public bool deleted
        {
            get { return Deleted; }
            set { Deleted = value; }
        }

        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        [JsonProperty(PropertyName = "LastName")]
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        [JsonProperty(PropertyName = "Company")]
        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        [JsonProperty(PropertyName = "JobTitle")]
        public string JobTitle
        {
            get { return jobtitle; }
            set { jobtitle = value; }
        }

        [JsonProperty(PropertyName = "City")]
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        [JsonProperty(PropertyName = "TelNo")]
        public string TelNo
        {
            get { return telno; }
            set { telno = value; }
        }

        [JsonProperty(PropertyName = "EMail")]
        public string EMail
        {
            get { return email; }
            set { email = value; }
        }

        [JsonProperty(PropertyName = "FaceAccount")]
        public string FaceAccount
        {
            get { return faceAccount; }
            set { faceAccount = value; }
        }

        [JsonProperty(PropertyName = "LinkedAccount")]
        public string LinkedAccount
        {
            get { return linkedAccount; }
            set { linkedAccount = value; }
        }

        [JsonProperty(PropertyName = "TwitterAccount")]
        public string TwitterAccount
        {
            get { return twitterAccount; }
            set { twitterAccount = value; }
        }

        [JsonProperty(PropertyName = "InstaAccount")]
        public string InstaAccount
        {
            get { return instaAccount; }
            set { instaAccount = value; }
        }

        [JsonProperty(PropertyName = "NoteID")]
        public string NoteID
        {
            get { return noteid; }
            set { noteid = value; }
        }

        [JsonProperty(PropertyName = "Hometown")]
        public string Hometown
        {
            get { return hometown; }
            set { hometown = value; }
        }

        [JsonProperty(PropertyName = "BirthDate")]
        public DateTime BirthDate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        [JsonProperty(PropertyName = "OfficeAddress")]
        public string OfficeAddress
        {
            get { return officeAddress; }
            set { officeAddress = value; }
        }

        [JsonProperty(PropertyName = "AssistantName")]
        public string AssistantName
        {
            get { return assistantName; }
            set { assistantName = value; }
        }

        [JsonProperty(PropertyName = "PreviousCompanies")]
        public string PreviousCompanies
        {
            get { return previouscompanies; }
            set { previouscompanies = value; }
        }

        [JsonProperty(PropertyName = "Profficiencies")]
        public string Profficiencies
        {
            get { return profficiencies; }
            set { profficiencies = value; }
        }

        [JsonProperty(PropertyName = "Projects")]
        public string Projects
        {
            get { return projects; }
            set { projects = value; }
        }

        [JsonProperty(PropertyName = "Sertificates")]
        public string Sertificates
        {
            get { return sertificates; }
            set { sertificates = value; }
        }

        [JsonProperty(PropertyName = "Universities")]
        public string Universities
        {
            get { return universities; }
            set { universities = value; }
        }

        [JsonProperty(PropertyName = "HighSchool")]
        public string HighSchool
        {
            get { return highschool; }
            set { highschool = value; }
        }

        [JsonProperty(PropertyName = "FamilyMembers")]
        public string FamilyMembers
        {
            get { return familymembers; }
            set { familymembers = value; }
        }

        [JsonProperty(PropertyName = "HomeAddress")]
        public string HomeAddress
        {
            get { return homeAddress; }
            set { homeAddress = value; }
        }

        [JsonProperty(PropertyName = "FoundAssociates")]
        public string FoundAssociates
        {
            get { return foundAssociates; }
            set { foundAssociates = value; }
        }

        [JsonProperty(PropertyName = "Sports")]
        public string Sports
        {
            get { return sports; }
            set { sports = value; }
        }

        [JsonProperty(PropertyName = "Hobbies")]
        public string Hobbies
        {
            get { return hobbies; }
            set { hobbies = value; }
        }

        [JsonProperty(PropertyName = "Team")]
        public string Team
        {
            get { return team; }
            set { team = value; }
        }

        [JsonProperty(PropertyName = "Travels")]
        public string Travels
        {
            get { return travels; }
            set { travels = value; }
        }

        [JsonProperty(PropertyName = "JobState")]
        public string JobState
        {
            get { return jobstate; }
            set { jobstate = value; }
        }
    }
}
