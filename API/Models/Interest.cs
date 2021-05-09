using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models {
public class Interest {
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    [Required]
    public string Description { get; set; }

}
}