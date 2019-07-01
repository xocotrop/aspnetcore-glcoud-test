using System.ComponentModel.DataAnnotations;

namespace Gcloud.Api.Repository.Entities
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}