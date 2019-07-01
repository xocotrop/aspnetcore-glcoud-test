using System.ComponentModel.DataAnnotations;

namespace Gcloud.Api.Repository.Entities
{
    public class User : Entity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public int Age { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
    }
}