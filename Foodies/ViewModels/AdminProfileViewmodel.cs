﻿namespace Foodies.ViewModels
{
    public class AdminProfileViewmodel: RegisterationViewModel
    {
        public string Id {  get; set; } 
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email {  get; set; }  
        public string? Password { get; set; }
        public string Phone { get; set; }
        public string PhoneNumber { get; set; }
        public int Resturantid {  get; set; }
    }
}