using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptEvolution
{
    public record EventActionCollection
    {
        public List<EventAction>? EventActions { get; set; }
    }
    public record EventAction
    {
        [Required]
        public required Action Action { get; set; }
        [Required]
        public DateTimeOffset? Day { get; set; }
        [Required]
        public TimeRange? TimeRange { get; set; }
        [Required]
        public required string Description { get; set; }
        public string? Location { get; set; }
        [Required]
        public string[]? Participants { get; set; }
    }

    public record TimeRange
    {
        [Required]
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
    }


    public enum Action
    {
        UnknownAction,
        AddEventAction,
        RemoveEventAction,
        AddParticipantsAction,
        ChangeTimeRangeAction,
        ChangeDescriptionAction,
        FindEventsAction,
    }

    
}
