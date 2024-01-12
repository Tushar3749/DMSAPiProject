using Microsoft.EntityFrameworkCore;

namespace DMS.Core.DTO.DayOperation
{
    [Keyless]
    public class ValidateDatabaseBackupLogDto
    {
        public string Message { get; set; }
    }
}
