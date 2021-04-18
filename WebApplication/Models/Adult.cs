using System.ComponentModel.DataAnnotations;

namespace Models {
public class Adult : Person {
    [Required]
    public Job JobTitle { get; set; }

    public Adult()
    {
        JobTitle = new Job();
    }
}
}