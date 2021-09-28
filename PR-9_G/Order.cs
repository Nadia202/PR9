using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace PR_9_G
{
    [Table(Name = "Orders")]
    class Order
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "order_id")]
        public int order_id { get; set; }
        [Column(Name = "creater")]
        public DateTime creater { get; set; }
        [Column(Name = "customer_ids")]
        public int customer_id { get; set; }
        [Column(Name = "point_ids")]
        public int point_id { get; set; }
        [Column(Name = "sum")]
        public double sum { get; set; }
        [Column(Name = "status_ids")]
        public int status_id { get; set; }
        [Column(Name = "delivery_service_ids")]
        public int delivery_service_id { get; set; }
    }
}
