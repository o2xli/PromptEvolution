using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptEvolution.Tests.Models
{
    public class OrderCollection
    {
        [Required]
        public List<Order> Orders { set; get; }
    }

    public record Order
    {
        [Required]
        public OrderAction Action { get; set; }
        [Required]
        public OrderItemType OrderItemType { get; set; }       
        [Required]
        [Range(1, 99)]
        public int Quantity { get; set; }
        public Size Size { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string[] RemovedIngredients { get; set; }
        [Required]
        public string[] AddedIngredients { get; set; }

        
    }
    public enum OrderAction
    {
        UnknownAction,
        NewOrderAction,
        CancelOrderAction,
        AddIngredientsAction,
        RemoveIngredientsAction,
        ChangeQuantityAction,
    }

    public enum OrderItemType
    {
        Unknown,
        Pizza,
        Beer,
        Salad,
        NamedPizza
    }

    public enum Size
    {
        Small,
        Medium,
        Large,
        ExtraLarge,
        Half,
        Whole
    }

    
}
