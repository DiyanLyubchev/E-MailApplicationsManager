using System.ComponentModel.DataAnnotations;

namespace E_MailApplicationsManager.Models.BaseEntitys
{
    public class BaseIdEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
