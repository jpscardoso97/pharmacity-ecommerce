﻿namespace CustomerService.Data.Dto
{
    public class AddressDto
    { 
        public int Id { get; set; }

        public string AddressId { get; set; }

        public string DeliveryAddress { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }
    }
}