﻿using EKART.Models;

namespace EKART.DTO
{
    public class CustomerDTO
    {
        public string CustomerId { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string? ContactName { get; set; }

        public string? ContactTitle { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }

        public string? Fax { get; set; }

        public string? Password { get; set; }

       // public Role Role { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
     
    }
}
