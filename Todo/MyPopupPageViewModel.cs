using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Todo
{
    public class MyPopupPageViewModel : BindableObject
    {

        RealmManager<TodoObject> manager = new RealmManager<TodoObject>();
        public string activityName { get; set; }
        public DateTime activityDate { get; set; }

        public MyPopupPageViewModel()
        {
        }

        public void AddNewActivity()
        {
            TodoObject item = new TodoObject();
            item.name = activityName;
            item.date = new DateTimeOffset(activityDate);
            item.completed = false;
            manager.Create(item);
        }
    }
}
