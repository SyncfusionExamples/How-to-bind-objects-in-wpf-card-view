using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardView
{
    public class ViewModel
    {
        public ObservableCollection<Contact> Contacts { get; set; }
        public ViewModel()
        {
            Contacts = new ObservableCollection<Contact>();
            PopulateData();
        }
        private void PopulateData()
        {
            Contacts.Add(new Contact() { Name = "John", Age = 26 });
            Contacts.Add(new Contact() { Name = "Mark", Age = 25 });
            Contacts.Add(new Contact() { Name = "Steven", Age = 26 });
        }
    }
}
