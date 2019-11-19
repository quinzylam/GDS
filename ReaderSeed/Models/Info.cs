using SQLite;

namespace GDS.External.Seed.Models
{
    [Table("info")]
    public class Info
    {
        [PrimaryKey]
        [Column("name")]
        public string Name { get; set; }

        [Column("value")]
        public string Value { get; set; }
    }
}