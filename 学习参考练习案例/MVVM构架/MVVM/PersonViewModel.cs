using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        //构造函数
        public PersonViewModel() { }
        public PersonViewModel(string title1,string title2,IEnumerable<PersonModel> colletion) 
        {
            this.title1 = title1;
            this.title2 = title2;
            Collection = new ObservableCollection<PersonModel>();
            foreach(var item in colletion)
            {
                Collection.Add(item);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void EventHendler(string propertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        //提供属性
        string title1, title2;
        public string Title1
        { get { return title1; } set { title1 = value; EventHendler("Title1"); } }
        public string Title2
        { get { return title2; } set { title2 = value; EventHendler("Title2"); } }
        public ObservableCollection<PersonModel> Collection { get; set; }
    }
}
