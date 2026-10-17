using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class Recipe
{
    public int RecipeId { get; set; }

    public int ProductId { get; set; }

    public string? Instructions { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<RecipeDetail> RecipeDetails { get; set; } = new List<RecipeDetail>();
}
