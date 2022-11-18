namespace Popkultulista.Core.Models.Base;

internal class Entity
{
    private int Id { get; set; }

    private DateTime CreatedAt { get; set; }

    private string? Author { get; set; }

    private bool IsDeleted { get; set; }

    private bool IsActive { get; set; }

    private bool IsBeingEdited { get; set; }

    private bool IsHistory { get; set; }

    internal T ShallowCopy<T>()
    {
        return (T)this.MemberwiseClone();
    }
}