using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace Golf_Club_Management.Models {
    public class TeeTime {
        public int Id { get; set; }

        
        [DataType(DataType.Date)]
        public DateOnly Date { get; set; }

        [Required]
        public string? Slot { get; set; }

        [Required]
        public int PlayerOneId { get; set; }

        [Required]
        public int PlayerTwoId { get; set; }

        [Required]
        public int PlayerThreeId { get; set; }

        [Required]
        public int PlayerFourId { get; set; }



    }

    public class TimeIn15MinIntervalsAttribute : ValidationAttribute {
        public override bool IsValid(object value) {
            DateTime time = (DateTime)value;
            return time.Minute % 15 == 0;
        }
    }
}
