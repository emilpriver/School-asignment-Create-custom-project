/**
* Schema file to be used in the project
*/
using System;

namespace im_bored {
    class Schema {
        
        // Default Database item Shema (structure)
        public class DatabaseItem
        {
            public int id { get; set; }
            public string title { get; set; }
            public string genre { get; set; }
            public string category { get; set; }
            public int length { get; set; }
            public string used { get; set; }
        }

        // Change objcet schema structure
        public class ChangeObject
        {
            //  Type is what we want to change. Category ex
            public string type { get; set; }
           
            //  This is the new value that will be used when we update a value
            public string value { get; set; }
        }
    }
}