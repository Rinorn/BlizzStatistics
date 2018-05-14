using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Realm
    {   
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }


    public class RealmRootobject 
    {
        public Realm[] realms { get; set; }
       
    }

    

}

