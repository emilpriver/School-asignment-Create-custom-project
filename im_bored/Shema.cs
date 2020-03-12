/**
* Schema file to be used in the project
*/
using System;

namespace im_bored {
    // schema som används för att visa o ändra data
    class Schema {
        public class DatabaseItem
        {
            public int id { get; set; }
            public string title { get; set; }
            public string genre { get; set; }
            public string category { get; set; }
        }
    }
}