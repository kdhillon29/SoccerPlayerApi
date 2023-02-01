using System;
using System.Collections.Generic;

namespace SoccerPlayerApi.Model;

public partial class Player
{
    public int PlayerId { get; set; }

    public string? PlayerName { get; set; }

    public int? JeresyNumber { get; set; }
}
