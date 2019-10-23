using System;

namespace School.BaseObject
{
    public class BaseClass
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public void Create(string username)
        {
            CreatedBy = username;
            CreatedDate = DateTime.Now;
        }

        public void Update(string username)
        {
            UpdatedBy = username;
            UpdatedDate = DateTime.Now;
        }
    }
}