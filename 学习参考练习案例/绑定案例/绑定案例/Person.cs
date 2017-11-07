using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 绑定案例
{
    class Person:INotifyPropertyChanged
    {
        public string Name { get; set; }
        public char Gender { get; set; }
        string _birthdate;
        public string Birthdate 
        { 
            get
            {
                return _birthdate;
            }
            set
            {
                _birthdate = value;
                //通知前端修改更新数据
                Func("Birthdate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        //为事件提供处理方法
        private void Func(string bindingName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(bindingName));
            }
        }
    }
}
