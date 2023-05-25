﻿namespace Api.Customers
{
    public class CustomerDto
    {
        public Guid? Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
    }
}
