using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Realms;
using Xamarin.Forms;

namespace Todo
{
    public class MainPageViewModel<T>: BindableObject, INotifyPropertyChanged where T : RealmObject
    {

        RealmManager<T> manager = new RealmManager<T>();
        public ObservableCollection<T> Items { get; private set; }


        public MainPageViewModel(){
            var token = manager.realm.All<T>().SubscribeForNotifications((sender, changes, error) =>
            {
                Read();
            });
        }

        public void Read() {
            Items = manager.Read();
            OnPropertyChanged("Items");
        }

        public void ToggleCompleted(TodoObject item) {
            manager.UpdateTodo(item, item.name, !item.completed, item.date);
        }

        public void Delete(T item) {
            manager.Delete(item);
        }

    }
}
