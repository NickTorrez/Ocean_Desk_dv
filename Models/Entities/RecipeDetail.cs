using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class RecipeDetail
{
    public int RecipeDetailId { get; set; }

    public int RecipeId { get; set; }

    public int IngredientProductId { get; set; }

    public decimal Quantity { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Product IngredientProduct { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
