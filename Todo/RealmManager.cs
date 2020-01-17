using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Realms;
using Xamarin.Forms;

namespace Todo
{
    public class RealmManager<T>: BindableObject where T : RealmObject
    {
        public Realm realm = Realm.GetInstance();

        public void Create(T item) {
            realm.Write(() =>
            {
                realm.Add(item);
            });
        }

        public ObservableCollection<T> Read()
        {
            List<T> items = realm.All<T>().ToList();
            ObservableCollection<T> list = new ObservableCollection<T>(items);
            return list;
        }

        public void UpdateTodo(TodoObject item, string name, bool completed, DateTimeOffset date)
        {
            realm.Write(() =>
            {
                item.name = name;
                item.completed = completed;
                item.date = date;
            });
        }

        public void Delete(T item)
        {
            realm.Write(() =>
            {
                realm.Remove(item);
            });
        }

    }
}
