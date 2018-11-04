using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using NoteWork.Modals;

namespace NoteWork.Store
{
    class TheManager
    {
       // public static string ApplicationURL = @"";

        static TheManager defaultInstance = new TheManager();
       // private static string mail, pass = null;
        MobileServiceClient client;


#if OFFLINE_SYNC_ENABLED
        IMobileServiceSyncTable<Login> LoginTable;
        const string offlineDbPath = @"localstore.db";
#else
        IMobileServiceTable<Login> LoginTable;
        IMobileServiceTable<Profile> ProfileTable;
        IMobileServiceTable<NetWork> NetWorkTable;
        IMobileServiceTable<Profile> NetWorkProfileTable;
#endif

        

        private TheManager()
        {
            this.client = new MobileServiceClient(KayitManager.ApplicationURL);

#if OFFLINE_SYNC_ENABLED
            var store = new MobileServiceSQLiteStore(offlineDbPath);
            store.DefineTable<Login>();

            //Initializes the SyncContext using the default IMobileServiceSyncHandler.
            this.client.SyncContext.InitializeAsync(store);

            this.LoginTable = client.GetSyncTable<Login>();
#else
            this.LoginTable = client.GetTable<Login>();
            
            this.ProfileTable = client.GetTable<Profile>();
            
            this.NetWorkTable = client.GetTable<NetWork>();

            this.NetWorkProfileTable = client.GetTable<Profile>();
#endif
        }

        public static TheManager DefaultManager()
        {
            //mail = EMail;
            //pass = Password;
            return defaultInstance;
        }

        public MobileServiceClient CurrentClient
        {
            get { return client; }
        }

        public bool IsOfflineEnabled
        {
            get { return LoginTable is Microsoft.WindowsAzure.MobileServices.Sync.IMobileServiceSyncTable<Login> &&
                         ProfileTable is Microsoft.WindowsAzure.MobileServices.Sync.IMobileServiceSyncTable<Profile> &&
                         NetWorkTable is Microsoft.WindowsAzure.MobileServices.Sync.IMobileServiceSyncTable<NetWork>; }
        }

//        public async Task<ObservableCollection<Login>> GetLoginsAsync(bool syncItems = false)
//        {
//            try
//            {
//#if OFFLINE_SYNC_ENABLED
//                if (syncItems)
//                {
//                    await this.SyncAsync();
//                }
//#endif
//                IEnumerable<Login> items = await LoginTable
//                   // .Where(Login => !Login.Done)
//                    .ToEnumerableAsync();
                
//                return new ObservableCollection<Login>(items);
//            }
//            catch (MobileServiceInvalidOperationException msioe)
//            {
               
//            }
           
//            return null;
//        }

        public async Task SaveTaskAsyncLogin(Login item)
        {
            if (item.ID == null)
            {
                await LoginTable.InsertAsync(item);
            }
            else
            {
                await LoginTable.UpdateAsync(item);
            }
        }
        public async Task SaveTaskAsyncProfile(Profile item)
        {
            if (item.ID == null)
            {
                await ProfileTable.InsertAsync(item);
            }
            else
            {
                await ProfileTable.UpdateAsync(item);
            }
        }
        public async Task SaveTaskAsyncNetWork(NetWork item)
        {
            if (item.ID == null)
            {
                await NetWorkTable.InsertAsync(item);
                ;
            }
            else
            {
                await NetWorkTable.UpdateAsync(item);
            }
        }

#if OFFLINE_SYNC_ENABLED
        public async Task SyncAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                await this.client.SyncContext.PushAsync();

                await this.LoginTable.PullAsync(
                    //The first parameter is a query name that is used internally by the client SDK to implement incremental sync.
                    //Use a different query name for each unique query in your program
                    "allLogins",
                    this.LoginTable.CreateQuery());
            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult != null)
                {
                    syncErrors = exc.PushResult.Errors;
                }
            }

            // Simple error/conflict handling. A real application would handle the various errors like network conditions,
            // server conflicts and others via the IMobileServiceSyncHandler.
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

                    Debug.WriteLine(@"Error executing sync operation. Item: {0} ({1}). Operation discarded.", error.TableName, error.Item["id"]);
                }
            }
        }
#endif

    }
}
