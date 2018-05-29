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
        [Key]
        [Required]
        public int DbId { get; set; }
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }

    }
    public class RealmRootobject
    {
        public Realm[] realms { get; set; }

    }





  

    

  






}

