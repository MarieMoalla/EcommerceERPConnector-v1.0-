using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceERPConnector_V1._0_.Models
{
    internal class Item
    {
        public KeyValuePair<string, dynamic> erpObj { get; set; }
        public string? manualInput { get; set; }
        public List<KeyValuePair<string, dynamic>>? ecommerceObjList { get; set; }
        public List<string>? constraints { get; set; }
        public KeyValuePair<string, dynamic> ecommerceObj { get; set; }
        public string? constraint { get; set; }
        public string? cinstraintValue { get; set; }
        public bool isEmpty { get; set; }
        public bool isRemoved { get; set; }
    }
}
