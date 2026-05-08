using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace OptimiseTechnicalTest.Server.Models;
// Don't need a Dto as the things I want to display in the front end are the same as the database columns
public class Product
{
    [Key]    
    public string Code {get; set;} = String.Empty;
    public string FullDescription {get; set;} = String.Empty;
    public string Model {get; set;} = String.Empty;
    public string ProductGroup {get; set;} = String.Empty;
    public int StockLevel {get; set;}
}
