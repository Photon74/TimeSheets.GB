using System.Collections.Generic;

namespace TimeSheets.GB.Validation.Interfaces
{
    public interface IValidationService<T> where T : class
    {
        IReadOnlyList<IOperationFailure> ValidateEntity(T entity);
    }
}
