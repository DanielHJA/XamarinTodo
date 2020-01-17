using System;
using Realms;

namespace Todo
{
    public class TodoObject: RealmObject
    {

        public string name { get; set; }
        public bool completed { get; set; }
        public DateTimeOffset date { get; set; }

    }
}
