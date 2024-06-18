using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace license_management_system_Sever_side.Models.Entities
{
    public class Notification
    {
        [Key, Column("id")]
        [DisplayName("Notification ID")]
        public int Id { get; set; }

        [Column("title"), MaxLength(100)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Column("text"), MaxLength(500)]
        [DisplayName("Text")]
        public string Text { get; set; }
        public DateTime Date { get; set; }=DateTime.Now;
    }
}
