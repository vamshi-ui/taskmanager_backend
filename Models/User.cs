using System;
using System.ComponentModel.DataAnnotations;
using TaskManager_Backend.Interfaces;

namespace TaskManager_Backend.Models;

public class User : IUser
{
    [Required]
    public string userName { get; set; }
    [Required]
    public string rollNo { get; set; }

    [Required]

    public string city { get; set; }
}
