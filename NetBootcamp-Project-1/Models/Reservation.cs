using System.ComponentModel.DataAnnotations.Schema;

namespace NetBootcamp_Project_1.Models
{
    public class Reservation : BaseModel
    {
        public DateTime EntryDate { get; set; }
        public DateTime ExitDate { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}
