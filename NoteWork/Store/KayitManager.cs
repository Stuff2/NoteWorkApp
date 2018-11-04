/*
 * To add Offline Sync Support:
 *  1) Add the NuGet package Microsoft.Azure.Mobile.Client.SQLiteStore (and dependencies) to all client projects
 *  2) Uncomment the #define OFFLINE_SYNC_ENABLED
 *
 * For more information, see: http://go.microsoft.com/fwlink/?LinkId=620342
 */
//#define OFFLINE_SYNC_ENABLED

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using NoteWork.Modals;
using System.Collections.ObjectModel;
using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace NoteWork.Store
{
    public partial class KayitManager
    {
        public static string ApplicationURL = @"";
        static KayitManager defaultInstance = new KayitManager();

        MobileServiceClient client;

        public Profile prof;
        public Login login;



        IMobileServiceTable<Login> loginTable;
        IMobileServiceTable<Profile> profileTable;
        IMobileServiceTable<NetWork> NetWorkTable;



        private KayitManager()
        {
            this.client = new MobileServiceClient(ApplicationURL);

            this.loginTable = client.GetTable<Login>();
            this.profileTable = client.GetTable<Profile>();
            this.NetWorkTable = client.GetTable<NetWork>();
        }

        public static KayitManager DefaultManager
        {

            get
            {
                return defaultInstance;
            }
            private set
            {
                defaultInstance = value;
            }
        }

        public MobileServiceClient CurrentClient
        {
            get { return client; }
        }

        public async Task<bool> MailControlAsync(string mail)
        {
            List<string> s = await loginTable.Where(item => item.Mail == mail).Select(item => item.Mail).ToListAsync();
            if (s.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }




        }

        public async Task<bool> NoControlAsync(Profile p, Profile a)
        {
            List<string> s = await NetWorkTable.Where(item => item.FPID == p.ID).Select(item => item.SPID).ToListAsync();
            ObservableCollection<Profile> items2 = new ObservableCollection<Profile>();
            ObservableCollection<Profile> items3 = new ObservableCollection<Profile>();
            foreach (var x in s)
            {
                items2.Add(await profileTable.LookupAsync(x));
            }
            for (var i = 0; i < items2.Count; i++)
            {
                if (items2.ElementAt(i).TelNo == a.TelNo)
                {
                    items3.Add(await profileTable.LookupAsync(items2.ElementAt(i).ID));
                }
            }
            if (items3.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public async Task<bool> LoginAsync(string mail, string pass)
        {

            List<Login> l = await loginTable.Where(item => item.Mail == mail && item.Password == pass).ToListAsync();

            List<Profile> p;
            if (l.Count == 0)
            {
                /*try
                {
                    await loginTable.PullAsync("l1", loginTable.CreateQuery().Where(item => item.Mail == mail && item.Password == pass));
                    l = await loginTable.Where(item => item.Mail == mail && item.Password == pass).ToListAsync();
                }
                catch (Exception e)
                { return false; }
                if (l.Count== 0)
                    return false;

                login = l.First();
                await profileTable.PullAsync("p1", profileTable.CreateQuery().Where(item => item.LID == login.ID));
                p = await profileTable.Where(item => item.LID == login.ID).ToListAsync();
                prof = p.First();
                //add sync
                return true;*/
                return false;

            }
            else
            {
                login = l.First();
                p = await profileTable.Where(item => item.LID == login.ID).ToListAsync();
                prof = p.First();
                return true;
            }


        }
        
        public async Task<ObservableCollection<Profile>> Search(string key)
        {

            string[] slist = key.Split(' ');
            List<Profile> prlist = new List<Profile>();
            for (var z = 0; z < slist.Length; z++)
            {
                if (!string.IsNullOrWhiteSpace(slist[z].ToLower()))
                {

                    prlist.AddRange(await profileTable.Where(items => items.FirstName.ToLower().Contains(slist[z].ToLower()) || items.LastName.ToLower().Contains(slist[z].ToLower())).ToListAsync());
                }
            };

            return (ObservableCollection<Profile>)prlist.Distinct().OrderBy(item => item.FirstName);

        }

        public async Task<ObservableCollection<Profile>> GetProfileAsync()
        {
            try
            {
                ObservableCollection<Profile> z = new ObservableCollection<Profile>(await profileTable.Where(items1 => items1.LID != null).ToEnumerableAsync());

                return z;
            }
            catch (Exception msioe)
            {
                return null;
            }

        }

        public async Task SaveLoginAsync(Profile item, Login item2)
        {
            await loginTable.InsertAsync(item2);
            item.LID = item2.ID;
            profileTable.InsertAsync(item);
        }

        public async Task SaveLoginAsync2(Profile item, NetWork x)
        {
            await profileTable.InsertAsync(item);
            
            x.FPID = prof.ID;
            x.SPID = item.ID;
           
            await NetWorkTable.InsertAsync(x);
        }

        public async Task SaveLoginAsync3(Profile item, NetWork x)
        {

            x.FPID = prof.ID;
            x.SPID = item.ID;

            await NetWorkTable.InsertAsync(x);
        }

        public async Task UpdateProfile(Profile item)
        {
            await profileTable.UpdateAsync(item);
        }

        public async Task UpdateLogin(Login item)
        {
            await loginTable.UpdateAsync(item);
        }

        public async Task UpdateNetWork(NetWork item)
        {
            await NetWorkTable.UpdateAsync(item);
        }
        
        public async Task<Tuple<ObservableCollection<Profile>, List<NetWork>>> GetNetWorksAsync(Profile baskaProfil)
        {
            try
            {
                List<NetWork> z = await NetWorkTable.Where(items => items.FPID == baskaProfil.ID && items.Deleted == false).ToListAsync();//değiştirilmiş girdi
                
                ObservableCollection<Profile> items2 = new ObservableCollection<Profile>();
                foreach (var x in z)
                {
                    items2.Add(await profileTable.LookupAsync(x.SPID));
                }
                return  new Tuple<ObservableCollection<Profile>, List<NetWork>>(items2,z) ;
            }
            catch (Exception msioe)
            {

            }
            return null;
        }

        public async Task<bool> IsNetWork(Profile item)
        {
            List<NetWork> z = await NetWorkTable.Where(items => items.FPID == prof.ID && items.SPID == item.ID && items.Deleted == false).ToListAsync();
            if (z.Count > 0)
            {
                return true;
            }
            else
                return false;
        }  

        public async Task SaveNetWorkAsync(Profile item, int count)
        {
            NetWork x = null;
            if (count == 0)
            {
                x = new NetWork
                {
                    FPID = prof.ID,
                    SPID = item.ID,
                    IsFace = true,
                    IsContacts = false,
                    IsGmail = false,
                    IsLinked = false

                };

            }

            if (count == 1)
            {
                x = new NetWork
                {
                    FPID = prof.ID,
                    SPID = item.ID,
                    IsFace = false,
                    IsContacts = true,
                    IsGmail = false,
                    IsLinked = false

                };

            }

            if (count == 2)
            {
                x = new NetWork
                {
                    FPID = prof.ID,
                    SPID = item.ID,
                    IsFace = false,
                    IsContacts = false,
                    IsGmail = true,
                    IsLinked = false

                };

            }

            if (count == 3)
            {
                x = new NetWork
                {
                    FPID = prof.ID,
                    SPID = item.ID,
                    IsFace = false,
                    IsContacts = false,
                    IsGmail = false,
                    IsLinked = true

                };

            }


            NetWorkTable.InsertAsync(x);


        }

        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            return client;
        }

        public async Task<List<ListProfile.Datas>> Get(string url)
        {
            try { 
                var httpClient = await GetClient();
            var response = await httpClient.GetStringAsync(url);
            var ret = JsonConvert.DeserializeObject<ListProfile>(response);
            if (ret == null)
                return new List<ListProfile.Datas>();
            List<ListProfile.Datas> c = ret.datas;

            if (ret.paging.next != null)
            {
                c.AddRange(await Get(ret.paging.next));
            }

            return c; }

                 catch(Exception e){
                return null;
            }
            }

        public async Task<ListProfile> GetFacebookProfile(string accessToken)
            {
                var httpClient = await GetClient();

                var requestUrl = "https://graph.facebook.com/v2.8/me/taggable_friends?fields=first_name,last_name,middle_name,picture&access_token="
                    + accessToken;

                var userJson = await httpClient.GetStringAsync(requestUrl);

                var profile = JsonConvert.DeserializeObject<ListProfile>(userJson);
                return profile;


            }

        /*public async Task SyncAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                await this.client.SyncContext.PushAsync();
                await this.NetWorkTable.PullAsync("nt1", this.NetWorkTable.CreateQuery().Where(item=>item.FPID==prof.ID));
                foreach (var x in await NetWorkTable.ToListAsync())
                {
                    await this.profileTable.PullAsync("p2", this.profileTable.CreateQuery().Where(item=> item.ID==x.SPID));


                }
               
                await this.NotesIDTable.PullAsync("ni1", this.NotesIDTable.CreateQuery().Where(item=>item.NTID==prof.ID) );
                foreach(var x in await NotesIDTable.ToListAsync())
                {
                    await this.NoteTable.PullAsync("n1", this.NoteTable.CreateQuery().Where(item => item.NID ==x.NTID));

                }
                //await this.NoteTable.PullAsync("n1", this.NoteTable.CreateQuery().Where(item=> item.NID==));
                

            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult != null)
                {
                    syncErrors = exc.PushResult.Errors;
                }
            }

          
            if (syncErrors != null)
            {
                foreach (var error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        //Update failed, reverting to server's copy.
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        // Discard local change.
                        await error.CancelAndDiscardItemAsync();
                    }

                   
                }
            }
        }*/
        
        public async Task DeleteNetWorkAsync(Profile item)
        {
            List<NetWork> z = await NetWorkTable.Where(items => items.FPID == prof.ID && items.SPID == item.ID).ToListAsync();//değiştirilmiş girdi
            z.First().Deleted = true;
            
            NetWorkTable.DeleteAsync(z.First());
              
        }

        public async Task DeleteProfilAsync()
        {
            profileTable.DeleteAsync(prof);
            loginTable.DeleteAsync(login);
        }
    }
}



