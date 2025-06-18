using AutoMapper;
using MF.Domain.Dtos;
using MF.Domain.Entities;
using MF.Domain.Interfaces.Repositories;
using MF.Domain.Interfaces.Services;

namespace MF.Application.Services
{
    public class ElaborationTypeService : Service<ElaborationType, ElaborationTypeDto>, IElaborationTypeService
    {
        public ElaborationTypeService(IElaborationTypeRepository elaborationTypeRepository, IMapper mapper)
            : base(elaborationTypeRepository, mapper)
        {
        }
        // Aquí puedes agregar métodos específicos para manejar tipos de elaboración si es necesario
        // Por ejemplo, un método para buscar por nombre o crear un nuevo tipo de elaboración
    }
}
