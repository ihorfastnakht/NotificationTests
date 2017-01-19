using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ToastNotification.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public IList<Test> ListItems { get; set; } = new List<Test>()
        {
            new Test() { Id = 1, Title = "Test1" },
            new Test() { Id = 2, Title = "Test2" },
            new Test() { Id = 3, Title = "Test3" },
        };

        private Test _testSelected;
        public Test TestSelected
        {
            get { return _testSelected; }
            set
            {
                if (value == _testSelected) return;

                foreach (var item in ListItems){
                    item.IsSelected = false;
                }
                _testSelected = value;
                //_testSelected.IsSelected = true;
                OnPropertyChanged(nameof(TestSelected));

                TestSelected.IsSelected = true;
                OnPropertyChanged(nameof(TestSelected));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property) =>
              PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public TestViewModel()
        {
            OnPropertyChanged(nameof(ListItems));
            OnPropertyChanged(nameof(TestCommand));
        }

        public ICommand TestCommand {
            get { return new Command(testEcecute); }
        }

        private void testEcecute(object obj)
        {
            if (obj != null)
            {
                var test = (Test)obj;
                Debug.WriteLine(test.Title.ToString());
            }
        }
    }

    public class Test : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Title { get; set; }

        private bool _selected = false;
        public bool IsSelected
        {
            get { return _selected; }
            set
            {
                this._selected = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
                Debug.WriteLine(this.Title + "   " + this.IsSelected.ToString());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
