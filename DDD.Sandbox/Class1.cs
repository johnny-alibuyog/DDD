using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox
{
    public class Service1
    {

        public bool CanBook(Cargo cargo, Voyage voyage)
        {
            var maxBooking = voyage.Capacity * 1.1;
            if (voyage.BookedCargoSize + cargo.Size > maxBooking)
                return false;

            return true;
        }

    }

    public class Service2
    {
        private readonly OverbookingPolicy overbookingPolicy = new OverbookingPolicy();

        public bool CanBook(Cargo cargo, Voyage voyage)
        {
            if (!overbookingPolicy.IsAllowed(cargo, voyage))
                return false;

            return true;
        }

    }


    public class OverbookingPolicy
    {
        internal bool IsAllowed(Cargo cargo, Voyage voyage)
        {
            var maxBooking = voyage.Capacity * 1.1;
            if (voyage.BookedCargoSize + cargo.Size > maxBooking)
                return false;

            return true;
        }
    }

    public class Cargo
    {
        public int Size { get; internal set; }
    }

    public class Voyage
    {
        public int BookedCargoSize { get; internal set; }
        public double Capacity { get; internal set; }
    }
}
