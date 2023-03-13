using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Golf_Club_Management.Models {
    public class Golfer {

        public int Id { get; set; }

        [Required]
        public int MembershipNumber { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public int Handicap { get; set; }
    }
}
