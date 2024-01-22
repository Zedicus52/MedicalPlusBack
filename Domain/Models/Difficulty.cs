using System;
using System.Collections.Generic;


namespace Domain.Models;

public partial class Difficulty
{
    public int IdDifficulty { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Problem> Problems { get; set; } = new List<Problem>();
}
