using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Categories
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryID { get; set; }

    [Required]
    [StringLength(15)]
    public string CategoryName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public byte[]? Picture { get; set; }
}