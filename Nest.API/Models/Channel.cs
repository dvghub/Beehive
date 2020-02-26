using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest.Models;

namespace Nest.API.Models {
    public class Channel {
        public Channel() { }
        public Channel(int id) { Id = id; }

        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select a parent")]
        public Channel Parent { get; set; }
    }
}
