using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoccerPlayerApi.Model;

public partial class Player
{
    [Key]
    public int PlayerId { get; set; }

    public string? PlayerName { get; set; }

    public int? JeresyNumber { get; set; }
}
