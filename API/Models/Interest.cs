using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models {
public class Interest {
    [Required]
    public string Type { get; set; }
    [Required]
    public string Description { get; set; }

}
}