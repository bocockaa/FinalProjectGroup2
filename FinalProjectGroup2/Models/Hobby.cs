using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectGroup2.Models
{
    [Table("Hobbies")]
    public class Hobby
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HobbyID { get; set; }

        public string HobbyName { get; set; }
        public string HobbyDescription { get; set; }

        public string HobbyCategory { get; set; }

        public string HobbyDifficulty { get; set; }


    }
}
