using System.ComponentModel.DataAnnotations;

namespace MVC_ICE_One.Models
{
    public class WorkItemModel
    {
        public int Id { get; set; }
        public string? WorkTitle { get; set; }
        public string? CreatorName { get; set; }

        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }
        public decimal Price
        {
            get; set;
        }
    }
}
