using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CardView
{
    public class Contact : IDataErrorInfo
    {
        [Required]
        public string Name
        {
            get;
            set;
        }
        [Range(1, 100)]
        public int Age
        {
            get;
            set;
        }
        #region IDataErrorInfo Members
        public string Error
        {
            get { return this[String.Empty]; }
        }
        public string this[string columnName]
        {
            get
            {
                string result = String.Empty;
                if (columnName == "Name")
                {
                    if (string.IsNullOrEmpty(this.Name))
                    {
                        result = "Name is mandatory";
                    }
                }
                if (columnName == "Age")
                {
                    if (this.Age < 1 || this.Age > 100)
                    {
                        result = "Invalid Age";
                    }
                }
                return result;
            }
        }
        #endregion
    }
}
