using System.ComponentModel.DataAnnotations;

namespace BaseWebApi.Models
{
    public class Cow
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }

        public DateTime BirthDate { get; set; }

        public int NrOfCalves { get; set; }


    }
}
