using Plugin.Contacts;
using Plugin.Contacts.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NoteWork
{
    public class asdasd : ContentPage
    {
        public asdasd()
        {
            var kayitol = new Image() { Source = "ara111.png" };

            var b = new StackLayout
            {
                Children = {
                    kayitol,

                },

            };

            
            if ( CrossContacts.Current.RequestPermission().IsCompleted)
            {

                List<Contact> contacts = null;
                CrossContacts.Current.PreferContactAggregation = false;//recommended
                                                                       //run in background
                Task.Run(() =>
                {
                    if (CrossContacts.Current.Contacts == null)
                        return;

                    contacts = CrossContacts.Current.Contacts
                    .ToList();

                    
                    var a = new ListView();

                    a.ItemsSource = contacts;
                    

                    b.Children.Add(a);
                });
            }




            Content = b;
            
        }
    }
}
