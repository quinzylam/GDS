using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GDS.Core.Models.Administration
{
    [DataContract]
    public class User : BaseModel
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public bool IsLoggedIn { get; set; }
    }
}