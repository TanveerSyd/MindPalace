using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MindPalace
{
   public  class MindViewModel : INotifyPropertyChanged
    {

       public MindViewModel()
       {
           ButtonCommand = new RelayCommand(new Action<object>(ShowTask));
       }
       public void ShowTask(object obj)
       {
           CurrentIndex++;
       }
        public event PropertyChangedEventHandler PropertyChanged;
       
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        private int _curIndex;
        public int CurrentIndex 
        {
            get { return _curIndex; }

            set { 
                _curIndex = value;
                NotifyPropertyChanged("CurrentIndex");
                }
        }
        private string _searchText;
        public string  SearchText 
        {
            get { return _searchText; }

            set
            {
                _searchText=value;
                NotifyPropertyChanged("SearchText");
                var list = AllToDoItems.Where(item => item.Key.Contains(_searchText));
                AllToDoItems = new ObservableCollection<Task>(list);
            }
        }
       
        private ObservableCollection<Task> _allToDoItems;
        public ObservableCollection<Task> AllToDoItems
        {
            get { return _allToDoItems; }
            set
            {
                _allToDoItems = value;
                NotifyPropertyChanged("AllToDoItems");
            }
        }

        private ICommand m_ButtonCommand;
        public ICommand ButtonCommand
        {
            get
            {
                return m_ButtonCommand;
            }
            set
            {
                m_ButtonCommand = value;
            }
        }

    }
}
