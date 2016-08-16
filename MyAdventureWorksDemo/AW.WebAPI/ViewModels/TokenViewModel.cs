namespace AW.WebAPI.ViewModels
{
    using System;
    using System.Collections.Generic;
    public class TokenViewModel
    {
        public string AccessToken { get; set; }
        public string UserName { get; set; }
        public string Issued { get; set; }
        public string Expires { get; set; }
    }
}