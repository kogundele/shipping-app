using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingApp
{
    class Shippment
    {
        private DateTime arrived_at;
        private int package_id;
        private string address;
        private string city;
        private string state;
        private string zip;
        public Shippment()
        {
            this.arrived_at = new DateTime();
            this.package_id = 0;
            this.address = "";
            this.city = "";
            this.state = "";
            this.zip = "";
        }

        public Shippment(DateTime arrived_at, int package_id, string address, string city, string state, string zip)
        {
            this.arrived_at = arrived_at;
            this.package_id = package_id;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
        }

        public string Zip
        {
            get { return this.zip; }
            set { this.zip = value; }
        }

        public int PackageId
        {
            get { return this.package_id; }
            set { this.package_id = value; }
        }

        public DateTime ArrivedAt
        {
            get { return this.arrived_at; }
            set { this.arrived_at = value; }
        }

        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public string City
        {
            get { return this.city; }
            set { this.city = value; }
        }

        public string State
        {
            get { return this.state; }
            set { this.state = value; }
        }
    }
}
