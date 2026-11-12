using Entities.DTOs;
using Entities.Models;
using System.Collections.Generic;

namespace Services.Contracts
{
    public interface IStatusService
    {
        public IEnumerable<StatusDto> GetAllStatus(bool trackChanges);

        public StatusDto? GetOneStatusById(int id, bool trackChanges);

        public StatusDto? CreateOneStatus(StatusCreateDto dto);

        public bool UpdateStatus(int id, StatusUpdateDto dto);

        public bool DeleteStatus(int id, bool trackChanges);
        StatusUpdateDto? GetStatusForUpdate(int id, bool trackChanges);
    }
}