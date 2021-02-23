using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Rate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Value { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
