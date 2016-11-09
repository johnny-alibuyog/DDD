using System;

namespace DDD.Core.Services.People
{
    public class Age : ValueObject<Age>
    {
        public virtual int Years { get; protected set; }

        public virtual int Months { get; protected set; }

        public virtual int Days { get; protected set; }

        public virtual string AgeString
        {
            get
            {
                var ageString = string.Empty;
                if (Years == 1 && Months == 1)
                {
                    ageString = string.Format("1 Year 1 Month");
                }
                else if (Years == 1)
                {
                    ageString = string.Format("1 Year {0} Months", Months);
                }
                else if (Years < 1 && Months == 1 && Days == 1)
                {
                    ageString = string.Format("1 Month 1 Day");
                }
                else if (Years < 1 && Months == 1)
                {
                    ageString = string.Format("1 Month {0} Days", Days);
                }
                else if (Years < 1 && Months < 1 && Days == 1)
                {
                    ageString = string.Format("{0} Day", Days);
                }
                else if (Years < 1 && Months < 1)
                {
                    ageString = string.Format("{0} Days", Days);
                }
                else if (Years < 1 && Days == 1)
                {
                    ageString = string.Format("{0} Months {1} Day", Years * 12 + Months, Days);
                }
                else if (Years < 1)
                {
                    ageString = string.Format("{0} Months {1} Days", Years * 12 + Months, Days);
                }
                else if (Years >= 2 && Months == 1)
                {
                    ageString = string.Format("{0} Years {1} Month", Years, Months);
                }
                else // if (Years >= 2 && Months != 1)
                {
                    ageString = string.Format("{0} Years {1} Months", Years, Months);
                }
                return ageString;
            }
        }

        public Age() { }

        public Age(DateTime BirthDate)
        {
            this.Count(BirthDate);
        }

        public Age(DateTime BirthDate, DateTime CurrentDate)
        {
            this.Count(BirthDate, CurrentDate);
        }

        internal Age Count(DateTime BirthDate)
        {
            return this.Count(BirthDate, DateTime.Today);
        }

        internal Age Count(DateTime BirthDate, DateTime CurrentDate)
        {
            if ((CurrentDate.Year - BirthDate.Year) > 0 ||
                (((CurrentDate.Year - BirthDate.Year) == 0) && ((BirthDate.Month < CurrentDate.Month) ||
                  ((BirthDate.Month == CurrentDate.Month) && (BirthDate.Day <= CurrentDate.Day)))))
            {
                var daysInBirthdayMonth = DateTime.DaysInMonth(BirthDate.Year, BirthDate.Month);
                var daysRemain = CurrentDate.Day + (daysInBirthdayMonth - BirthDate.Day);

                if (CurrentDate.Month > BirthDate.Month)
                {
                    this.Years = CurrentDate.Year - BirthDate.Year;
                    this.Months = CurrentDate.Month - (BirthDate.Month + 1) + Math.Abs(daysRemain / daysInBirthdayMonth);
                    this.Days = (daysRemain % daysInBirthdayMonth + daysInBirthdayMonth) % daysInBirthdayMonth;
                }
                else if (CurrentDate.Month == BirthDate.Month)
                {
                    if (CurrentDate.Day >= BirthDate.Day)
                    {
                        this.Years = CurrentDate.Year - BirthDate.Year;
                        this.Months = 0;
                        this.Days = CurrentDate.Day - BirthDate.Day;
                    }
                    else
                    {
                        this.Years = (CurrentDate.Year - 1) - BirthDate.Year;
                        this.Months = 11;
                        this.Days = DateTime.DaysInMonth(BirthDate.Year, BirthDate.Month) - (BirthDate.Day - CurrentDate.Day);
                    }
                }
                else
                {
                    this.Years = (CurrentDate.Year - 1) - BirthDate.Year;
                    this.Months = CurrentDate.Month + (11 - BirthDate.Month) + Math.Abs(daysRemain / daysInBirthdayMonth);
                    this.Days = (daysRemain % daysInBirthdayMonth + daysInBirthdayMonth) % daysInBirthdayMonth;
                }
            }
            else
            {
                throw new ArgumentException("Birthday date must be earlier than current date");
            }
            return this;
        }

        public override string ToString()
        {
            return this.AgeString;
        }
    }
}
