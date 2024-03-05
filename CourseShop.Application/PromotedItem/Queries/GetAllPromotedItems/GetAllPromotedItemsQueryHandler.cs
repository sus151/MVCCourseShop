using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.PromotedItem.Queries.GetAllPromotedItems
{
    public class GetAllPromotedItemsQueryHandler : IRequestHandler<GetAllPromotedItemsQuery, IEnumerable<GetAllPromotedItemsQuery>>
    {
        private readonly IPromotedItemRespository _promotedItemsRespository;
        private readonly IMapper _mapper;

        public GetAllPromotedItemsQueryHandler(IPromotedItemRespository promotedItemRespository, IMapper mapper)
        {
            _promotedItemsRespository = promotedItemRespository;
            _mapper = mapper;
            
        }

        public async Task<IEnumerable<GetAllPromotedItemsQuery>> Handle(GetAllPromotedItemsQuery request, CancellationToken cancellationToken)
        {
            var promotedItems = await _promotedItemsRespository.GetAllPromotedItems();
            var promotedItemsDto = _mapper.Map<IEnumerable<GetAllPromotedItemsQuery>>(promotedItems);
            return promotedItemsDto;
        }
    }
}
