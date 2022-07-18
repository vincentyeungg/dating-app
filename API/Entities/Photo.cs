using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    // rename the table in db to Photos
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        // need to FULLY DEFINE the relation between Photo and AppUser (1-M) relation
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}