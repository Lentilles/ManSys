﻿namespace ManSys.Models
{

    /// <summary>
    /// Only for managers from different companies
    /// </summary>
    /// 
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}