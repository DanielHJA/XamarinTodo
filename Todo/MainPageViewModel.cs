using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Realms;
using Xamarin.Forms;

namespace Todo
{
    public class MainPageViewModel<T>: BindableObject where T : RealmObject
    {

        RealmManager<T> manager = new RealmManager<T>();
        private ObservableCollection<T> _Items { get; set; }
        public ObservableCollection<T> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                if (value != _Items)
                {
                    _Items = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainPageViewModel(){
            var token = manager.realm.All<T>().SubscribeForNotifications((sender, changes, error) =>
            {
                Read();
            });
        }

        public void Read() {
            Items = manager.Read();
        }

        public void ToggleCompleted(TodoObject item) {
            manager.UpdateTodo(item, item.name, !item.completed, item.date);
        }

        public void Delete(T item) {
            manager.Delete(item);
        }

    }
}
