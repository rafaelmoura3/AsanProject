using AsanAPI.Data.DtoMaintenance;
using AsanAPI.Data.DtoTools;
using AsanAPI.Data.DtoProblem;
using AsanAPI.Models;
using AutoMapper;
using AsanAPI.Data.DtoToolPerPart;
using AsanAPI.Data.DtoSpaceShip;
using AsanAPI.Data.DtoSpaceShipTypeDto;
using AsanAPI.Data.DtoPartsPerShipType;
using AsanAPI.Data.DtoPart;
using AsanAPI.Data.DtoPartsPerShip;

namespace AsanAPI.Profiles
{
    public class AsanProfile : Profile
    {
        public AsanProfile()
        {
            //Problems
            CreateMap<CreateProblemDTO, Problem>().ReverseMap();
            CreateMap<Problem, ReadProblemDTO>().ReverseMap();
            CreateMap<UpdateProblemDTO, Problem>().ReverseMap();

            //Parts
            CreateMap<CreatePartDTO, Part>().ReverseMap();
            CreateMap<Part, ReadPartDTO>().ReverseMap();
            CreateMap<UpdatePartDTO, Part>().ReverseMap();

            //Tools
            CreateMap<CreateToolDto, Tool>().ReverseMap();
            CreateMap<Tool, ReadToolDto>().ReverseMap();
            CreateMap<UpdateToolDto, Tool>().ReverseMap();

            //Maintenance
            CreateMap<CreateMaintenanceDto, Maintenance>().ReverseMap();
            CreateMap<Maintenance, ReadMaintenanceDto>().ReverseMap();
            CreateMap<UpdateMaintenanceDto, Maintenance>().ReverseMap();

            //ToolPerPart
            CreateMap<CreateToolPerPartDto, ToolPerPart>().ReverseMap();
            CreateMap<ToolPerPart, ReadToolPerPartDto>().ReverseMap();
            CreateMap<UpdateToolPerPartDto, ToolPerPart>().ReverseMap();

            //SpaceShip
            CreateMap<CreateSpaceShipDto, SpaceShip>().ReverseMap();
            CreateMap<SpaceShip, ReadSpaceShipDto>().ReverseMap();
            CreateMap<UpdateSpaceShipDto, SpaceShip>().ReverseMap();

            //SpaceShipeType
            CreateMap<CreateSpaceShipTypeDto, SpaceShipType>().ReverseMap();
            CreateMap<SpaceShipType, ReadSpaceShipTypeDto>()
                .ForMember(destino => destino.CountSpaceShip, origem=>origem.MapFrom(fonte=>fonte.SpaceShip.Count));
            CreateMap<UpdateSpaceShipTypeDto, SpaceShipType>().ReverseMap();
            
            //SpaceShip
            CreateMap<CreateSpaceShipProblemDto, SpaceShipProblem>().ReverseMap();
            CreateMap<SpaceShipProblem, ReadSpaceShipProblemDto>().ReverseMap();
            CreateMap<UpdateSpaceShipProblemDto, SpaceShipProblem>().ReverseMap();

            //PartsPerShipType
            CreateMap<CreatePartsPerShipTypeDto, PartsPerShipType>().ReverseMap();
            CreateMap<PartsPerShipType, ReadPartsPerShipTypeDto>().ReverseMap();
            CreateMap<UpdatePartsPerShipTypeDto, PartsPerShipType>().ReverseMap();

            //PartsPerShips
            CreateMap<CreatePartsPerShipDto, PartsPerShip>().ReverseMap();
            CreateMap<PartsPerShip, ReadPartsPerShipDto>().ReverseMap();
            CreateMap<UpdatePartsPerShipDto, PartsPerShip>().ReverseMap();

        }
    }
}
