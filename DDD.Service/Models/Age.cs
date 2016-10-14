namespace DDD.Service.Models
{
    public class Age
    {
        public virtual int Years { get; set; }

        public virtual int Months { get; set; }

        public virtual int Days { get; set; }

        public virtual string AgeString { get; set; }
    }
}
