using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace license_management_system_Sever_side.Models.Entities
{
    public class Notifications
    {
        [Key, Column("id")]
        [DisplayName("Notification ID")]
        public int Id { get; set; }

        [Column("title"), MaxLength(100)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Column("text"), MaxLength(1000)]
        [DisplayName("Text")]
        public string Text { get; set; }
    }
}
