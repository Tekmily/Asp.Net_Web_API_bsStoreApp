using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public record BookDtoForInsertion :BookDtoForManipulation
    {
        [Required(ErrorMessage ="CategoryId is requird.")]
        public int CategoryId { get; init; }
    }

}
